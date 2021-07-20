using DialogueExtension.Api;
using DialogueExtension.Patches;
using DialogueExtension.Patches.Utility;
using DialogueExtension.Utilities;
using LightInject;
using StardewModdingAPI;

namespace DialogueExtension
{
  public class Initialization
  {
    public Initialization(IMod mod)
    {
      var container = new ServiceContainer();
      container.RegisterAssembly(GetType().Assembly);
      container.RegisterInstance(mod.Helper);
      container.RegisterInstance(mod.Monitor);
      container.Register<IHarmonyWrapper, HarmonyWrapper>();
      container.Decorate<IMonitor, Logger>();
      
      container.GetInstance<IHarmonyPatch>();
      container.GetInstance<IDialogueApi>();
    }
  }
}
