using DialogueExtension.Api;
using DialogueExtension.Patches;
using DialogueExtension.Patches.Parsing;
using DialogueExtension.Patches.Utility;
using DialogueExtension.Utilities;
using Harmony;
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
      container.Register<HarmonyInstance>();
      container.Decorate<IMonitor, Logger>();
      container.Register<IConditionRepository, ConditionRepository>(new PerContainerLifetime());
      container.Register<IDialogueLogic, DialogueLogic>();
      container.Register<IDialogueParser, VanillaDialogueParser>();
      container.Register<IHarmonyPatch, TryToRetrieveDialoguePatch>();
      container.Register<IDialogueApi, DialogueApi>(new PerContainerLifetime());

      container.GetInstance<IHarmonyPatch>();
      container.GetInstance<IDialogueApi>();
    }
  }
}
