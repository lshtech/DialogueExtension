using Netcode;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public interface IChunkWrapper : IWrappedType<Chunk>, INetObject<NetFields>
  {
    int debrisType { get; set; }
    float scale { get; set; }
    float alpha { get; set; }
    float getSpeed();
  }
}