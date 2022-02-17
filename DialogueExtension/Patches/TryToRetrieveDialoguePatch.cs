using System;
using DialogueExtension.Patches.Parsing;
using DialogueExtension.Patches.Utility;
using HarmonyLib;
using JetBrains.Annotations;
using StardewModdingAPI;
using StardewValley;
// ReSharper disable InconsistentNaming
// ReSharper disable RedundantAssignment

namespace DialogueExtension.Patches
{
  public class TryToRetrieveDialoguePatch : HarmonyPatch
  {
    private static IMonitor _monitor;
    public TryToRetrieveDialoguePatch(IMonitor monitor, IHarmonyWrapper wrapper, IDialogueLogic dialogueLogic) : base(monitor, wrapper)
    {
      _monitor = monitor;
      HarmonyWrapper.Patch(
       AccessTools.Method(typeof(NPC), "tryToRetrieveDialogue"),
       prefix: new HarmonyMethod(typeof(TryToRetrieveDialoguePatch), "Prefix"));

      _dialogueLogic = dialogueLogic;
    }
    
    protected override string PatchName => ".tryToRetrieveDialogue";
    private static IDialogueLogic _dialogueLogic;

    [UsedImplicitly]
    private static bool Prefix(ref NPC __instance, ref string preface, ref Dialogue __result)
    {
      if (Game1.dayOfMonth is < 1 or > 28)
        return true;

      var npc = __instance;
      try
      {
        __result = _dialogueLogic.GetDialogue(ref npc, !string.IsNullOrEmpty(preface));
        if (__result != null) _monitor.Log($"{npc.Name} | {__result.getCurrentDialogue()}");
        return false;
      }
      catch (Exception ex)
      {
        _monitor.Log(ex.Message);
        var friendship = Game1.player.friendshipData.TryGetValue(npc.Name, out var friendshipValue) ? friendshipValue.Points : 0;
        var spouse = string.IsNullOrEmpty(Game1.player.spouse) ? Game1.player.spouse : "none";
        _monitor.Log($"{npc.Name} | Year:{Game1.year} | Season:{Game1.currentSeason} | " +
                     $"Day:{Game1.dayOfMonth} | Friendship:{friendship} | Spouse:{spouse}");
        return true;
      }
    }
  }
}