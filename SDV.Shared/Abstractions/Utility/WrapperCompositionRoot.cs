using LightInject;

namespace SDV.Shared.Abstractions.Utility
{
  public class WrapperCompositionRoot : ICompositionRoot
  {
    public void Compose(IServiceRegistry serviceRegistry)
    {
      serviceRegistry
        .Register<IAnimatedSpriteWrapper, AnimatedSpriteWrapper>()
        .Register<IAnimationFrameWrapper, AnimationFrameWrapper>()
        .Register<ICharacterWrapper, CharacterWrapper>()
        .Register<IFarmerSpriteWrapper, FarmerSpriteWrapper>()
        .Register<IGameLocationWrapper, GameLocationWrapper>()
        .Register<IGameWrapper, GameWrapper>()
        .Register<IHorseWrapper, HorseWrapper>()
        .Register<IModDataDictionaryWrapper, ModDataDictionaryWrapper>()
        .Register<INPCWrapper, NPCWrapper>()
        .Register<IWrapperFactory, WrapperFactory>();
    }
  }
}