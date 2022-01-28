using Netcode;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public interface IProposalWrapper : IWrappedType<Proposal>
  {
    NetFields NetFields { get; }
  }
}