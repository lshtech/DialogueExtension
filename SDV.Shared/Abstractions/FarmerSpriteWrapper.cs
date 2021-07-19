using Microsoft.Xna.Framework;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public class FarmerSpriteWrapper : AnimatedSpriteWrapper, IFarmerSpriteWrapper, IWrappedType<FarmerSprite>
  {
    public FarmerSpriteWrapper(AnimatedSprite animatedSprite) : base(animatedSprite)
    {
    }

    public int CurrentToolIndex { get; set; }
    public bool PauseForSingleAnimation { get; set; }
    public int CurrentSingleAnimation { get; }
    public IAnimationFrameWrapper CurrentAnimationFrame { get; }
  
    public bool IsPlayingBasicAnimation(int direction, bool carrying) => false;

    public void setCurrentSingleFrame(int which, short interval = 32000, bool secondaryArm = false, bool flip = false)
    {
    }

    public void setCurrentFrame(int which)
    {
    }

    public void setCurrentFrame(int which, int offset)
    {
    }

    public void setCurrentFrame(int which, int offset, int interval, int numFrames, bool flip, bool secondaryArm)
    {
    }

    public void setCurrentFrameBackwards(int which, int offset, int interval, int numFrames, bool secondaryArm, bool flip)
    {
    }

    public void animate(int whichAnimation, GameTime time)
    {
    }

    public void animate(int whichAnimation, int milliseconds)
    {
    }

    public void checkForSingleAnimation(GameTime time)
    {
    }

    public void animateOnce(int whichAnimation, float animationInterval, int numberOfFrames)
    {
    }

    public void animateOnce(int whichAnimation, float animationInterval, int numberOfFrames,
      AnimatedSprite.endOfAnimationBehavior endOfBehaviorFunction)
    {
    }

    public void animateOnce(int whichAnimation, float animationInterval, int numberOfFrames,
      endOfAnimationBehavior endOfBehaviorFunction, bool flip, bool secondaryArm)
    {
    }

    public void animateOnce(IAnimationFrameWrapper[] animation, endOfAnimationBehavior endOfBehaviorFunction = null)
    {
    }

    public void animateOnce(int whichAnimation, float animationInterval, int numberOfFrames,
      endOfAnimationBehavior endOfBehaviorFunction, bool flip, bool secondaryArm, bool backwards)
    {
    }

    public void showFrameUntilDialogueOver(int whichFrame)
    {
    }

    public void animateBackwardsOnce(int whichAnimation, float animationInterval)
    {
    }

    public bool isUsingWeapon() => false;

    public int getWeaponTypeFromAnimation() => 0;

    public bool isOnToolAnimation() => false;

    public bool isPassingOut() => false;

    public int frameOfCurrentSingleAnimation() => 0;

    public void setCurrentSingleAnimation(int which)
    {
    }

    public void setOwner(Farmer owner)
    {
    }

    public void setCurrentAnimation(IAnimationFrameWrapper[] animation)
    {
    }

    public FarmerSprite GetBaseType { get; }
  }
}
