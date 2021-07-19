using StardewValley;

namespace SDV.Shared.Abstractions
{
  public class AnimationFrameWrapper : IAnimationFrameWrapper
  {
    public AnimationFrameWrapper(FarmerSprite.AnimationFrame animationFrame) => GetBasType = animationFrame;
    public FarmerSprite.AnimationFrame GetBasType { get; }
    public FarmerSprite.AnimationFrame AddFrameAction(AnimatedSprite.endOfAnimationBehavior callback) => default;

    public FarmerSprite.AnimationFrame AddFrameEndAction(AnimatedSprite.endOfAnimationBehavior callback) => default;
  }
}
