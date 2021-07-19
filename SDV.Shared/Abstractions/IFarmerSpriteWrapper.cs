﻿using Microsoft.Xna.Framework;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public interface IFarmerSpriteWrapper : IAnimatedSpriteWrapper
  {
    int CurrentToolIndex { get; set; }
    bool PauseForSingleAnimation { get; set; }
    int CurrentSingleAnimation { get; }
    IAnimationFrameWrapper CurrentAnimationFrame { get; }
    int CurrentFrame { get; set; }
    void setOwner(Farmer owner);
    void setCurrentAnimation(IAnimationFrameWrapper[] animation);
    void faceDirection(int direction);
    bool IsPlayingBasicAnimation(int direction, bool carrying);
    void setCurrentSingleFrame(int which, short interval = 32000, bool secondaryArm = false, bool flip = false);
    void setCurrentFrame(int which);
    void setCurrentFrame(int which, int offset);

    void setCurrentFrame(
      int which,
      int offset,
      int interval,
      int numFrames,
      bool flip,
      bool secondaryArm);

    void setCurrentFrameBackwards(
      int which,
      int offset,
      int interval,
      int numFrames,
      bool secondaryArm,
      bool flip);

    void animate(int whichAnimation, GameTime time);
    void animate(int whichAnimation, int milliseconds);
    void checkForSingleAnimation(GameTime time);
    void animateOnce(int whichAnimation, float animationInterval, int numberOfFrames);

    void animateOnce(
      int whichAnimation,
      float animationInterval,
      int numberOfFrames,
      AnimatedSprite.endOfAnimationBehavior endOfBehaviorFunction);

    void animateOnce(
      int whichAnimation,
      float animationInterval,
      int numberOfFrames,
      AnimatedSpriteWrapper.endOfAnimationBehavior endOfBehaviorFunction,
      bool flip,
      bool secondaryArm);

    void animateOnce(
      IAnimationFrameWrapper[] animation,
      AnimatedSpriteWrapper.endOfAnimationBehavior endOfBehaviorFunction = null);

    void animateOnce(
      int whichAnimation,
      float animationInterval,
      int numberOfFrames,
      AnimatedSpriteWrapper.endOfAnimationBehavior endOfBehaviorFunction,
      bool flip,
      bool secondaryArm,
      bool backwards);

    void showFrameUntilDialogueOver(int whichFrame);
    void animateBackwardsOnce(int whichAnimation, float animationInterval);
    bool isUsingWeapon();
    int getWeaponTypeFromAnimation();
    bool isOnToolAnimation();
    bool isPassingOut();
    void UpdateSourceRect();
    int frameOfCurrentSingleAnimation();
    void setCurrentSingleAnimation(int which);
    void StopAnimation();
  }
}