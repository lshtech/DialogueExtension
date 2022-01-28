using DialogueExtension.Api;
using DialogueExtension.Patches.Parsing;
using StardewValley;

namespace DialogueExtension.Patches.Utility
{
  public interface IImportVanillaConditions
  {
  }

  public class ImportVanillaConditions : IImportVanillaConditions
  {
    public ImportVanillaConditions(IDialogueApi api, IDialogueLogic logic)
    {
      _logic = logic;
      BuildConditions(api);
    }

    private readonly IDialogueLogic _logic;

    private void BuildConditions(IDialogueApi api)
    {
      api.AddCustomHeartLevelCondition(4, true, (conditions, i) =>
      {
        if (conditions.Season == Season.Fall &&
            conditions.DayOfWeek == DayOfWeek.Mon &&
            conditions.Npc.Name.Equals("Penny") &&
            Game1.MasterPlayer.mailReceived.Contains("pamHouseUpgrade"))
          return !_logic.CheckIfDialogueContainsKey(conditions.Npc,
            FluentDialogueBuilder.New(conditions).Season()
              .DayOfWeek().FirstOrSecondYear().Married().Build(null),
            out var dialogue)
            ? new Dialogue(conditions.Npc.Dialogue["Fall_Mon"], conditions.BaseNpc)
            : dialogue;

        return null;
      });
    }
  }
}
