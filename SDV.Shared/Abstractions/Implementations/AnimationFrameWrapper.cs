using StardewValley;

namespace SDV.Shared.Abstractions
{
  public class AnimationFrameWrapper : IAnimationFrameWrapper
  {
    public AnimationFrameWrapper(FarmerSprite.AnimationFrame animationFrame) => GetBasType = animationFrame;
    public FarmerSprite.AnimationFrame GetBasType { get; }

    public IAnimationFrameWrapper AddFrameAction(AnimatedSpriteWrapper.endOfAnimationBehavior callback) => null;

    public IAnimationFrameWrapper AddFrameEndAction(AnimatedSpriteWrapper.endOfAnimationBehavior callback) => null;
  }
}
