using System;
using System.Collections.Generic;
using DialogueExtension.Patches.Utility;
using StardewValley;

namespace DialogueExtension.Api
{
  public interface IDialogueApi
  {
    void AddCustomHeartLevelCondition(
      int heartLevel, bool levelAndHigher, Func<DialogueConditions, int, Dialogue> func);

    void AddRangeCustomHeartLevelCondition(
      IDictionary<(int hearts, bool andHigher), IEnumerable<Func<DialogueConditions, int, Dialogue>>> conditions);
  }
}
