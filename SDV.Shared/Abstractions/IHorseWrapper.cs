using System;
using StardewValley;
using StardewValley.Characters;
using Object = StardewValley.Object;

namespace SDV.Shared.Abstractions
{
  public interface IHorseWrapper : INPCWrapper, IWrappedType<Horse>
  {
    new Horse GetBaseType { get; }
    Guid HorseId { get; set; }
    Farmer rider { get; set; }
    Farmer getOwner();
    void squeezeForGate();
    void dismount(bool from_demolish = false);
    void nameHorse(string name);
    void SyncPositionToRider();
    bool collideWith(Object o);

    void receiveGift(Object o, Farmer giver, bool updateGiftLimitInfo, float friendshipChangeMultiplier,
      bool showResponse);
  }
}