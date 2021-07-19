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

  public class ConditionRepository : IConditionRepository
  {
    public IDictionary<(int hearts, bool andHigher), IList<Func<DialogueConditions, int, Dialogue>>> 
      HeartDialogueDictionary { get; set; }

    public ConditionRepository()
    {
      HeartDialogueDictionary = new Dictionary<(int hearts, bool andHigher), IList<Func<DialogueConditions, int, Dialogue>>>();
    }
  }
}
