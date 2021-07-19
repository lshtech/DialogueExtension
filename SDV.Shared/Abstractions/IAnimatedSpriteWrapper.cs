using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Netcode;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public interface IAnimatedSpriteWrapper
  {
    int CurrentFrame { get; set; }
    int SpriteWidth { get; set; }
    int SpriteHeight { get; set; }
    Rectangle SourceRect { get; set; }
    List<FarmerSprite.AnimationFrame> CurrentAnimation { get; set; }
    NetFields NetFields { get; }
    Texture2D Texture { get; }
    void LoadTexture(string textureName);
    int getHeight();
    int getWidth();
    void StopAnimation();
    void standAndFaceDirection(int direction);
    void faceDirectionStandard(int direction);
    void faceDirection(int direction);
    void AnimateRight(GameTime gameTime, int intervalOffset = 0, string soundForFootstep = "");
    void AnimateUp(GameTime gameTime, int intervalOffset = 0, string soundForFootstep = "");
    void AnimateDown(GameTime gameTime, int intervalOffset = 0, string soundForFootstep = "");
    void AnimateLeft(GameTime gameTime, int intervalOffset = 0, string soundForFootstep = "");
    bool Animate(GameTime gameTime, int startFrame, int numberOfFrames, float interval);

    bool AnimateBackwards(
      GameTime gameTime,
      int startFrame,
      int numberOfFrames,
      float interval);

    void setCurrentAnimation(List<FarmerSprite.AnimationFrame> animation);
    bool animateOnce(GameTime time);
    void UpdateSourceRect();
    void draw(SpriteBatch b, Vector2 screenPosition, float layerDepth);

    void draw(
      SpriteBatch b,
      Vector2 screenPosition,
      float layerDepth,
      int xOffset,
      int yOffset,
      Color c,
      bool flip = false,
      float scale = 1f,
      float rotation = 0.0f,
      bool characterSourceRectOffset = false);

    void drawShadow(SpriteBatch b, Vector2 screenPosition, float scale = 4f, float alpha = 1f);
    void drawShadow(SpriteBatch b, Vector2 screenPosition, float scale = 4f);
    AnimatedSprite Clone();
  }
}