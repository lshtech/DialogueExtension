using Harmony;
using StardewModdingAPI;

namespace DialogueExtension.Patches
{
  public abstract class HarmonyPatch : IHarmonyPatch
  {
    protected static IMonitor Logger;
    private readonly string _baseId = "elbe.DialogueExtension";

    protected HarmonyInstance HarmonyInstance;

    protected HarmonyPatch(IMonitor logger)
    {
      HarmonyInstance = HarmonyInstance.Create(_baseId + PatchName);
      Logger = logger;
    }

    protected abstract string PatchName { get; }
  }
}