using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley.Util;

namespace SDV.Shared.Abstractions
{
  public interface IBoundingBoxGroupWrapper : IWrappedType<BoundingBoxGroup>
  {
    bool Intersects(Rectangle rect);
    bool Contains(int x, int y);
    void Add(Rectangle rect);
    void ClearNonIntersecting(Rectangle rect);
    void Clear();
    void Draw(SpriteBatch b);
    bool IsEmpty();
  }
}