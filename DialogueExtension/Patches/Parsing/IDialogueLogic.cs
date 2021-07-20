using System;
using SDV.Shared.Abstractions;

namespace DialogueExtension.Patches.Parsing
{
  public interface IDialogueLogic
  {
    IDialogueWrapper GetDialogue(ref INPCWrapper npc, bool useSeason);
    bool CheckIfDialogueContainsKey(INPCWrapper npc, string key, out IDialogueWrapper dialogue, Func<bool> extraConditions = null);
  }
}