using Microsoft.Xna.Framework;

namespace SDV.Shared.Abstractions
{
  public interface IPetWrapper : INPCWrapper
  {
    int CurrentBehavior { get; set; }
    void OnPetAnimationEvent(string animation_event);
    string getPetTextureName();
    void reloadBreedSprite();
    void warpToFarmHouse(IFarmerWrapper who);
    void UpdateSleepingOnBed();
    void GrantLoveMailIfNecessary();
    void setAtFarmPosition();
    void playContentSound();
    void hold(IFarmerWrapper who);
    void RunState(GameTime time);
    void OnNewBehavior();
  }
}