using Netcode;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public interface IFriendshipWrapper : IWrappedType<Friendship>
  {
    int Points { get; set; }
    int GiftsThisWeek { get; set; }
    int GiftsToday { get; set; }
    IWorldDateWrapper LastGiftDate { get; set; }
    bool TalkedToToday { get; set; }
    bool ProposalRejected { get; set; }
    IWorldDateWrapper WeddingDate { get; set; }
    IWorldDateWrapper NextBirthingDate { get; set; }
    FriendshipStatus Status { get; set; }
    long Proposer { get; set; }
    bool RoommateMarriage { get; set; }
    NetFields NetFields { get; }
    int DaysMarried { get; }
    int CountdownToWedding { get; }
    int DaysUntilBirthing { get; }
    void Clear();
    bool IsDating();
    bool IsEngaged();
    bool IsMarried();
    bool IsDivorced();
    bool IsRoommate();
  }
}