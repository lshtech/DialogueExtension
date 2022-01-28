using Netcode;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public interface ILightSourceWrapper : IWrappedType<LightSource>
  {
    int Identifier { get; set; }
    long PlayerID { get; set; }
    NetFields NetFields { get; }
    ILightSourceWrapper Clone();
  }
}