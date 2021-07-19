using DialogueExtension.Patches.Utility;
using StardewModdingAPI;

namespace DialogueExtension.Patches
{
  public abstract class HarmonyPatch : IHarmonyPatch
  {
    protected static IMonitor Logger;
    private readonly string _baseId = "elbe.DialogueExtension";

    protected IHarmonyWrapper HarmonyWrapper;

    protected HarmonyPatch(IMonitor logger, IHarmonyWrapper harmonyWrapper)
    {
      HarmonyWrapper = harmonyWrapper;
      HarmonyWrapper.Create(_baseId + PatchName);
      Logger = logger;
    }

    protected abstract string PatchName { get; }
  }
}