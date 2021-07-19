using System;
using Harmony;

namespace DialogueExtension.Patches.Utility
{
  // ReSharper disable once UnusedMember.Global
  public class HarmonyInstanceFactory : IHarmonyInstanceFactory
  {
    private readonly Func<string, HarmonyInstance> _createHarmonyInstance;

    public HarmonyInstanceFactory(Func<string, HarmonyInstance> createHarmonyInstance)
    {
      _createHarmonyInstance = createHarmonyInstance;
    }

    public HarmonyInstance GetHarmonyInstance(string id) =>
      _createHarmonyInstance(id);
  }
}