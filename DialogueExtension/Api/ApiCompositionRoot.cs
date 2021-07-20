using LightInject;

namespace DialogueExtension.Api
{
  public class ApiCompositionRoot : ICompositionRoot
  {
    public void Compose(IServiceRegistry serviceRegistry)
    {
      serviceRegistry.Register<IDialogueApi, DialogueApi>(new PerContainerLifetime());
    }
  }
}
