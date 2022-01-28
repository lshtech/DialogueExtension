using System.Collections.Generic;
using System.IO;
using StardewValley.Network;

namespace SDV.Shared.Abstractions
{
  public class OutgoingMessageWrapper : IOutgoingMessageWrapper
  {
    public OutgoingMessageWrapper(OutgoingMessage item) => GetBaseItem = item;
    public OutgoingMessage GetBaseItem { get; }
    public byte MessageType { get; }
    public long FarmerID { get; }
    public IReadOnlyCollection<object> Data { get; }
    public IFarmerWrapper SourceFarmer { get; }
    public void Write(BinaryWriter writer)
    {
    }
  }
}
