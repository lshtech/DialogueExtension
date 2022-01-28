using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley.BellsAndWhistles;

namespace SDV.Shared.Abstractions
{
  public interface ICritterWrapper : IWrappedType<Critter>
  {
    Rectangle getBoundingBox(int xOffset, int yOffset);
    bool update(GameTime time, IGameLocationWrapper environment);
    void draw(SpriteBatch b);
    void drawAboveFrontLayer(SpriteBatch b);
  }
}