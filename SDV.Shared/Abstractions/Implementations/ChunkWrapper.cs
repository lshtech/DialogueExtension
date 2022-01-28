using Netcode;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public class ChunkWrapper : IChunkWrapper
  {
    public ChunkWrapper(Chunk item) => GetBaseType = item;
    public Chunk GetBaseType { get; }
    public int debrisType { get; set; }
    public float scale { get; set; }
    public float alpha { get; set; }
    public NetFields NetFields { get; }
    public float getSpeed() => 0;
  }
}
