using System;
using System.Collections.Generic;
using StardewValley;

namespace DialogueExtension.Patches.Utility
{
  public class ConditionRepository : IConditionRepository
  {
    public ConditionRepository() => HeartDialogueDictionary = 
      new Dictionary<(int hearts, bool andHigher), IList<Func<DialogueConditions, int, Dialogue>>>();

    public IDictionary<(int hearts, bool andHigher), IList<Func<DialogueConditions, int, Dialogue>>> 
      HeartDialogueDictionary { get; set; }
  }
}
