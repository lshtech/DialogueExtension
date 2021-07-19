using Harmony;

namespace DialogueExtension.Patches
{
  public interface IHarmonyInstanceFactory
  {
    HarmonyInstance GetHarmonyInstance(string id);
  }
}