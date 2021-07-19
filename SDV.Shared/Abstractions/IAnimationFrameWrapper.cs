using StardewValley;

namespace SDV.Shared.Abstractions
{
  public interface IAnimationFrameWrapper
  {
    FarmerSprite.AnimationFrame AddFrameAction(
      AnimatedSprite.endOfAnimationBehavior callback);

    FarmerSprite.AnimationFrame AddFrameEndAction(
      AnimatedSprite.endOfAnimationBehavior callback);
  }
}