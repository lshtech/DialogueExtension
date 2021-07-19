using DialogueExtension.Patches.Parsing;
using Harmony;
using StardewModdingAPI;
using StardewValley;

namespace DialogueExtension.Patches
{
  public class TryToRetrieveDialoguePatch : HarmonyPatch
  {
    public TryToRetrieveDialoguePatch(IMonitor monitor, IDialogueLogic dialogueLogic) : base(monitor)
    {
      HarmonyInstance.Patch(
       AccessTools.Method(typeof(NPC), "tryToRetrieveDialogue"),
       new HarmonyMethod(typeof(TryToRetrieveDialoguePatch), "Prefix"),
       new HarmonyMethod(typeof(TryToRetrieveDialoguePatch), "Postfix"));

      _dialogueLogic = dialogueLogic;
    }
    
    protected override string PatchName => ".tryToRetrieveDialogue";
    private static IDialogueLogic _dialogueLogic;

    

    // ReSharper disable once UnusedMember.Local
    private static bool Prefix(ref NPC __instance, ref string preface, ref Dialogue __result)
    {
      __result = _dialogueLogic.GetDialogue(ref __instance, !string.IsNullOrEmpty(preface));
      if (__result == null) Logger.Log("Value is null", LogLevel.Alert);
      else Logger.Log(__result.getCurrentDialogue(), LogLevel.Alert);
      return true;
    }

   
    // ReSharper disable once UnusedMember.Local
    private static void Postfix(ref NPC __instance, ref Dialogue __result)
    {
      if (__result == null) Logger.Log("Value is null", LogLevel.Alert);
      else Logger.Log(__result.getCurrentDialogue(), LogLevel.Alert);
    }
  }
}