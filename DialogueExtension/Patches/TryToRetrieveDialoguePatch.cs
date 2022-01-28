﻿using DialogueExtension.Patches.Parsing;
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
    public TryToRetrieveDialoguePatch(IMonitor monitor, IHarmonyWrapper wrapper, IDialogueLogic dialogueLogic) : base(monitor, wrapper)
    {
      HarmonyWrapper.Patch(
       AccessTools.Method(typeof(NPC), "tryToRetrieveDialogue"),
       new HarmonyMethod(typeof(TryToRetrieveDialoguePatch), "Prefix"),
       new HarmonyMethod(typeof(TryToRetrieveDialoguePatch), "Postfix"));

      _dialogueLogic = dialogueLogic;
    }
    
    protected override string PatchName => ".tryToRetrieveDialogue";
    private static IDialogueLogic _dialogueLogic;

    [UsedImplicitly]
    private static bool Prefix(ref NPC __instance, ref string preface, ref Dialogue __result)
    {
      var npc = __instance;
      __result = _dialogueLogic.GetDialogue(ref npc, !string.IsNullOrEmpty(preface));
      return true;
    }


    [UsedImplicitly]
    private static void Postfix(ref NPC __instance, ref Dialogue __result)
    {
      if (__result == null) Logger.Log("Value is null", LogLevel.Debug);
      else Logger.Log(__result.getCurrentDialogue(), LogLevel.Debug);
    }
  }
}