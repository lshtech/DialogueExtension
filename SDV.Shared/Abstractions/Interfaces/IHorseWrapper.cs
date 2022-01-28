using System;

namespace SDV.Shared.Abstractions
{
  public interface IHorseWrapper : INPCWrapper
  {
    Guid HorseId { get; set; }
    IFarmerWrapper rider { get; set; }
    IFarmerWrapper getOwner();
    void squeezeForGate();
    void dismount(bool from_demolish = false);
    void nameHorse(string name);
    void SyncPositionToRider();
    bool collideWith(IObjectWrapper o);
  }
}