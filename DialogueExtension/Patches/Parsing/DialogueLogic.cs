using System;
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
      //_logger.Log("Entering GetDialogue", LogLevel.Info);
      foreach (var isMarried in new[] {true, false})
      {
        if (!Enum.TryParse<Season>(Game1.currentSeason, true, out var season)) continue;
        var conditions = new DialogueConditions(
          ref npc,
          Game1.year.ToString("00"),
          useSeason ? season : Season.Unknown,
          Game1.dayOfMonth,
          ParseDayOfWeek(ref npc, Game1.shortDayNameFromDayOfSeason(Game1.dayOfMonth)),
          isMarried ? MarriageAppend(Game1.player.spouse) : string.Empty,
          Game1.player.friendshipData.TryGetValue(npc.Name, out var friendshipValue)
            ? friendshipValue.Points
            : 0);

        Dialogue dialogue;
        _logger.Log(
          $"{conditions.Npc.Name} | {conditions.Year}|{conditions.Season}|{conditions.DayOfMonth}|{conditions.DayOfWeek}|{conditions.Friendship}",
          LogLevel.Info);
        if (FirstPassDialogue(conditions, out dialogue)) return dialogue;
        if (HeartDialogue(conditions, out dialogue)) return dialogue;
        if (NullIfTruePass(conditions)) return null;
        if (LastPassDialogue(conditions, out dialogue)) return dialogue;
      }

      //_logger.Log("Exiting GetDialogue", LogLevel.Info);
      return null;
    }

    private bool NullIfTruePass(DialogueConditions conditions)
    {
      //_logger.Log("Entering NullIfTruePass", LogLevel.Info);
      if (!conditions.Npc.Dialogue.ContainsKey(FluentDialogueBuilder
        .New(conditions).Season().DayOfWeek().Married().Build(_logger))) return true;

      return false;
    }

    private bool LastPassDialogue(DialogueConditions conditions, out Dialogue dialogue)
    {
      // _logger.Log("Entering LastPassDialogue", LogLevel.Info);
      if (conditions.Npc.Name.Equals("Caroline") && Game1.isLocationAccessible("CommunityCenter") &&
          (conditions.Season == Season.Summer && conditions.DayOfWeek == DayOfWeek.Mon))
      {
        dialogue = new Dialogue(conditions.Npc.Dialogue["summer_Wed"], conditions.Npc);
        return true;
      }

      if (CheckIfDialogueContainsKey(conditions.Npc,
        FluentDialogueBuilder.New(conditions).Season().DayOfWeek().Married().Build(_logger),
        out dialogue)) return true;

      if (CheckIfDialogueContainsKey(conditions.Npc,
        FluentDialogueBuilder.New(conditions).Season().DayOfWeek().FirstOrSecondYear().Married().Build(_logger),
        out dialogue)) return true;

      dialogue = null;
      return false;
    }

    public bool CheckIfDialogueContainsKey(NPC npc, string key,
      out Dialogue dialogue, Func<bool> extraConditions = null)
    {
      _logger.Log($"{key} | {(extraConditions?.Invoke() ?? true)}", LogLevel.Info);
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

    private DayOfWeek ParseDayOfWeek(ref NPC npc, string day)
    {
      if (npc.Name == "Pierre" &&
          (Game1.isLocationAccessible("CommunityCenter") ||
           Game1.player.HasTownKey) && day == "Wed")
        day = "Sat";

      return (DayOfWeek) Enum.Parse(typeof(DayOfWeek), day);
    }

    private bool FirstPassDialogue(DialogueConditions conditions, out Dialogue dialogue)
    {
      foreach (var useYear in new[] {false, true})
        if (CheckIfDialogueContainsKey(conditions.Npc,
          FluentDialogueBuilder.New(conditions).Season().DayOfWeek().Married().Year(useYear).Build(_logger),
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
            FluentDialogueBuilder.New(conditions).Season().DayOfMonth().Hearts(i).Married().Build(_logger),
            out dialogue)) return true;
        }

        dialogue = null;
        return false;
      }
    }
  }
}