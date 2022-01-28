namespace SDV.Shared.Abstractions
{
  public interface IAnimationFrameWrapper
  {
    IAnimationFrameWrapper AddFrameAction(
      AnimatedSpriteWrapper.endOfAnimationBehavior callback);

    IAnimationFrameWrapper AddFrameEndAction(
      AnimatedSpriteWrapper.endOfAnimationBehavior callback);
  }
}