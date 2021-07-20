using DialogueExtension.Patches.Parsing;
using LightInject;

namespace DialogueExtension.Patches.Utility
{
  public class PatchCompositionRoot : ICompositionRoot
  {
    public void Compose(IServiceRegistry serviceRegistry)
    {
      serviceRegistry
        .Register<IConditionRepository, ConditionRepository>(new PerContainerLifetime())
        .Register<IDialogueLogic, DialogueLogic>()
        .Register<IDialogueParser, VanillaDialogueParser>()
        .Register<IHarmonyPatch, TryToRetrieveDialoguePatch>();
    }
  }
}