using System;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public class HorseWrapper : NPCWrapper, IHorseWrapper
  {

    public HorseWrapper(Character character) : base(character)
    {
    }

    public Guid HorseId { get; set; }
    public IFarmerWrapper rider { get; set; }
    public IFarmerWrapper getOwner() => null;

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

    public bool collideWith(IObjectWrapper o) => false;
  }
}