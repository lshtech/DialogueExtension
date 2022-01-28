using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SDV.Shared.Abstractions
{
  public interface ILargeTerrainFeatureWrapper : ITerrainFeaturesWrapper
  {
    Rectangle getBoundingBox();
    void dayUpdate(IGameLocationWrapper l);
    bool tickUpdate(GameTime time, IGameLocationWrapper location);
    void draw(SpriteBatch b);
  }
}