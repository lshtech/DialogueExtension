using System.Collections.Generic;
using System.IO;
using StardewValley.Network;

namespace SDV.Shared.Abstractions
{
  public interface IOutgoingMessageWrapper
  {
    OutgoingMessage GetBaseItem { get; }
    byte MessageType { get; }
    long FarmerID { get; }
    IReadOnlyCollection<object> Data { get; }
    IFarmerWrapper SourceFarmer { get; }
    void Write(BinaryWriter writer);
  }
}