using System;
using System.Collections.Generic;
using StardewValley;

namespace DialogueExtension.Patches.Utility
{
  public interface IConditionRepository
  {
    IDictionary<(int hearts, bool andHigher),
      IList<Func<DialogueConditions, int, Dialogue>>> HeartDialogueDictionary { get; set; }
  }
}