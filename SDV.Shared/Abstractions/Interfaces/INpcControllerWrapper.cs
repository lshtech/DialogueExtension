using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public interface INPCControllerWrapper : IWrappedType<NPCController>
  {
    void destroyAtNextCrossroad();
    bool update(GameTime time, IGameLocationWrapper location, IEnumerable<INPCControllerWrapper> allControllers);
  }
}