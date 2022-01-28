using System.Collections.Generic;
using System.Reflection;
using StardewValley;

namespace DialogueExtension.Tests.MockWrappers
{
  public class ExtendNPC : NPC
  {
    public ExtendNPC()
    {
    }

    public Dictionary<string, string> SetDialogue
    {
      get => Dialogue;
      set
      {
        var dfield = typeof(NPC).GetField("dialogue", BindingFlags.NonPublic | BindingFlags.Instance);
        dfield.SetValue(this, value);
      }
    }
  }
}
