using System;
using StardewValley;

namespace DialogueExtension.Patches.Parsing
{
  public interface IDialogueLogic
  {
    Dialogue GetDialogue(ref NPC npc, bool useSeason);
    bool CheckIfDialogueContainsKey(NPC npc, string key, out Dialogue dialogue, Func<bool> extraConditions = null);
  }
}