using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley.TerrainFeatures;

namespace SDV.Shared.Abstractions
{
  public class LargeTerrainFeatureWrapper : TerrainFeaturesWrapper, ILargeTerrainFeatureWrapper
  {
    public LargeTerrainFeatureWrapper(TerrainFeature item) : base(item)
    {
    }

    public Rectangle getBoundingBox() => default;

    public void dayUpdate(IGameLocationWrapper l)
    {
    }

    public bool tickUpdate(GameTime time, IGameLocationWrapper location) => false;

    public void draw(SpriteBatch b)
    {
    }
  }
}
