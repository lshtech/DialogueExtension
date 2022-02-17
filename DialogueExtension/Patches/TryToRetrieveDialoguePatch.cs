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
      var npc = __instance;
      __result = _dialogueLogic.GetDialogue(ref npc, !string.IsNullOrEmpty(preface));
      if (__result != null) _monitor.Log($"{npc.Name} | {__result.getCurrentDialogue()}", LogLevel.Trace);
      return false;
    }
  }
}