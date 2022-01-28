using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley.BellsAndWhistles;

namespace SDV.Shared.Abstractions
{
  public class CritterWrapper : ICritterWrapper
  {
    public CritterWrapper(Critter item) => GetBaseType = item;
    public Critter GetBaseType { get; }
    public Rectangle getBoundingBox(int xOffset, int yOffset) => default;

    public bool update(GameTime time, IGameLocationWrapper environment) => false;

    public void draw(SpriteBatch b)
    {
    }

    public void drawAboveFrontLayer(SpriteBatch b)
    {
    }
  }
}
