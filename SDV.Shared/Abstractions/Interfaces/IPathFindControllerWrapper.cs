using Microsoft.Xna.Framework;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public interface IPathFindControllerWrapper : IWrappedType<PathFindController>
  {
    bool isPlayerPresent();
    bool update(GameTime time);
    void handleWarps(Rectangle position);
  }
}