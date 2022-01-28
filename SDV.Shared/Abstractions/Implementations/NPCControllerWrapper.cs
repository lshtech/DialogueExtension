using System.Collections.Generic;
using Microsoft.Xna.Framework;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public class NPCControllerWrapper : INPCControllerWrapper
  {
    public NPCControllerWrapper(NPCController item) => GetBaseType = item;

    public delegate void endBehavior();

    public NPCController GetBaseType { get; }
    public void destroyAtNextCrossroad()
    {
    }

    public bool update(GameTime time, IGameLocationWrapper location, IEnumerable<INPCControllerWrapper> allControllers) => false;
  }
}
