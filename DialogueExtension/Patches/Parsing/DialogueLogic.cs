using System;
using System.Collections.Generic;
using DialogueExtension.Patches.Utility;
using StardewModdingAPI;
using StardewValley;
using DayOfWeek = DialogueExtension.Patches.Utility.DayOfWeek;

namespace DialogueExtension.Patches.Parsing
{
  public class DialogueLogic : IDialogueLogic
  {
    private readonly IConditionRepository _conditionRepository;
    private IMonitor _logger;

    public DialogueLogic(IConditionRepository conditionRepository, IMonitor logger)
    {
      _conditionRepository = conditionRepository;
      _logger = logger;
    }

    public Dialogue GetDialogue(ref NPC npc, bool useSeason)
    {
      var checkInlaw = new List<bool>() {false};
      if (Game1.player.spouse != string.Empty)
        checkInlaw.Insert(0, true);
      foreach (var isMarried in checkInlaw)
      {
        var season = Season.Unknown;
        if (!string.IsNullOrEmpty(Game1.currentSeason))
          if (!Enum.TryParse<Season>(Game1.currentSeason, true, out season)) continue;

        var conditions = new DialogueConditions(
          npc,
          Game1.year.ToString("00"),
          useSeason ? season : Season.Unknown,
          Game1.dayOfMonth,
          ParseDayOfWeek(npc, Game1.shortDayNameFromDayOfSeason(Game1.dayOfMonth)),
          isMarried ? MarriageAppend(Game1.player.spouse) : string.Empty,
          Game1.player.friendshipData.TryGetValue(npc.Name, out Friendship friendshipValue)
            ? friendshipValue.Points
            : 0);

        Dialogue dialogue;
        if (FirstPassDialogue(conditions, out dialogue)) return dialogue;
        if (HeartDialogue(conditions, out dialogue)) return dialogue;
        if (NullIfTruePass(conditions)) continue;
        if (LastPassDialogue(conditions, out dialogue)) return dialogue;
      }

      return null;
    }

    private bool NullIfTruePass(DialogueConditions conditions)
    {
      if (!conditions.Npc.Dialogue.ContainsKey(FluentDialogueBuilder
        .New(conditions).Season().DayOfWeek().Married().Build(_logger))) return true;

      return false;
    }

    private bool LastPassDialogue(DialogueConditions conditions, out Dialogue dialogue)
    {
      if (conditions.Npc.Name.Equals("Caroline") && Game1.isLocationAccessible("CommunityCenter") &&
          (conditions.Season == Season.Summer && conditions.DayOfWeek == DayOfWeek.Mon))
      {
        dialogue = new Dialogue(
          conditions.Npc.Dialogue["summer_Wed"], conditions.Npc);
        return true;
      }

      if (CheckIfDialogueContainsKey(conditions.Npc,
        FluentDialogueBuilder.New(conditions).Season().DayOfWeek().FirstOrSecondYear().Married().Build(_logger),
        out dialogue)) return true;

      if (CheckIfDialogueContainsKey(conditions.Npc,
        FluentDialogueBuilder.New(conditions).Season().DayOfWeek().Married().Build(_logger),
        out dialogue)) return true;

      dialogue = null;
      return false;
    }

    public bool CheckIfDialogueContainsKey(NPC npc, string key,
      out Dialogue dialogue, Func<bool> extraConditions = null)
    {
      if (npc.Dialogue.ContainsKey(key) && (extraConditions?.Invoke() ?? true))
      {
        dialogue = new Dialogue(npc.Dialogue[key], npc);
        return true;
      }

      dialogue = null;
      return false;
    }

    private string MarriageAppend(string spouse) =>
      !string.IsNullOrEmpty(spouse) ? $"_inlaw_{spouse}" : string.Empty;

    private DayOfWeek ParseDayOfWeek(NPC npc, string day)
    {
      if (npc.Name == "Pierre" &&
          (Game1.isLocationAccessible("CommunityCenter") ||
           Game1.player.HasTownKey) && day == "Wed")
        day = "Sat";

      return (DayOfWeek) Enum.Parse(typeof(DayOfWeek), day);
    }

    private bool FirstPassDialogue(DialogueConditions conditions, out Dialogue dialogue)
    {
      if (conditions.Season == Season.Spring && conditions.DayOfMonth ==12)
        Console.Write(string.Empty);
      foreach (var useYear in new[] {false, true})
        if (CheckIfDialogueContainsKey(conditions.Npc,
          FluentDialogueBuilder.New(conditions).Season().DayOfMonth().Married().FirstOrSecondYear(useYear).Build(_logger),
          out dialogue, () => conditions.FirstOrSecondYear == 1))
          return true;
      dialogue = null;
      return false;
    }

    private bool HeartDialogue(DialogueConditions conditions, out Dialogue dialogue)
    {
      {
        for (var i = 14; i > 0; i--)
        {
          if (_conditionRepository.HeartDialogueDictionary.ContainsKey((i, true)))
            foreach (var func in _conditionRepository.HeartDialogueDictionary[(i, true)])
            {
              dialogue = func(conditions, i);
              if (dialogue != null) return true;
            }

          if (conditions.Hearts >= i && CheckIfDialogueContainsKey(conditions.Npc,
            FluentDialogueBuilder.New(conditions).Season().DayOfWeek().Hearts(i).FirstOrSecondYear().Married().Build(_logger),
            out dialogue)) return true;
          if (conditions.Hearts >= i && CheckIfDialogueContainsKey(conditions.Npc,
            FluentDialogueBuilder.New(conditions).Season().DayOfWeek().Hearts(i).Married().Build(_logger),
            out dialogue)) return true;
        }

        dialogue = null;
        return false;
      }
    }
  }
}