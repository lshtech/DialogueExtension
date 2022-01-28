using Netcode;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public interface IWarpWrapper : IWrappedType<Warp>
  {
    int X { get; }
    int Y { get; }
    int TargetX { get; set; }
    int TargetY { get; set; }
    string TargetName { get; set; }
    NetFields NetFields { get; }
  }
}