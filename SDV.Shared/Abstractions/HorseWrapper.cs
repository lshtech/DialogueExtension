using System;
using StardewValley;
using StardewValley.Characters;
using Object = StardewValley.Object;

namespace SDV.Shared.Abstractions
{
  public class HorseWrapper : NPCWrapper, IHorseWrapper
  {

    public HorseWrapper(Horse character) : base(character)
    {
    }

    public Guid HorseId { get; set; }
    public Farmer rider { get; set; }
    public Farmer getOwner() => null;

    public void squeezeForGate()
    {
    }

    public void dismount(bool from_demolish = false)
    {
    }

    public void nameHorse(string name)
    {
    }

    public void SyncPositionToRider()
    {
    }

    public bool collideWith(Object o) => false;

    public void receiveGift(Object o, Farmer giver, bool updateGiftLimitInfo, float friendshipChangeMultiplier,
      bool showResponse)
    {
    }

    public new Horse GetBaseType { get; }
  }
}