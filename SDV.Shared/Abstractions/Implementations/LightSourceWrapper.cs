using Netcode;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public class LightSourceWrapper : ILightSourceWrapper
  {
    public LightSourceWrapper(LightSource item) => GetBaseType = item;
    public LightSource GetBaseType { get; }
    public int Identifier { get; set; }
    public long PlayerID { get; set; }
    public NetFields NetFields { get; }
    public ILightSourceWrapper Clone() => null;
  }
}
