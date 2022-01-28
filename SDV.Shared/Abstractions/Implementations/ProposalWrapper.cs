using Netcode;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public class ProposalWrapper : IProposalWrapper
  {
    public ProposalWrapper(Proposal item) => GetBaseType = item;
    public Proposal GetBaseType { get; }
    public NetFields NetFields { get; }
  }
}
