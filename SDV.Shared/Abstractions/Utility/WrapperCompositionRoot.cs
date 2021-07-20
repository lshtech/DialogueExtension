using LightInject;
namespace SDV.Shared.Abstractions.Utility
{
  public class WrapperCompositionRoot : ICompositionRoot
  {
    public void Compose(IServiceRegistry serviceRegistry)
    {
      serviceRegistry
        .Register<IAnimatedSpriteWrapper>()
        .Register<IAnimationFrameWrapper>()
        .Register<ICharacterWrapper>()
        .Register<IFarmerSpriteWrapper>()
        .Register<IGameLocationWrapper>()
        .Register<IGameWrapper>()
        .Register<IHorseWrapper>()
        .Register<IModDataDictionaryWrapper>()
        .Register<INPCWrapper>()
        .Register<IServiceFactory, IWrapperFactory>((factory, serviceFactory) => new WrapperFactory(serviceFactory));
    }
  }
}
