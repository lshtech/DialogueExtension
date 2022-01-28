using Microsoft.Xna.Framework;
using StardewValley;
namespace SDV.Shared.Abstractions
{
  public class PetWrapper : NPCWrapper, IPetWrapper
  {
    public PetWrapper(Character npc) : base(npc)
    {
    }

    public int CurrentBehavior { get; set; }
    public void OnPetAnimationEvent(string animation_event)
    {
    }

    public string getPetTextureName() => null;

    public void reloadBreedSprite()
    {
    }

    public void warpToFarmHouse(IFarmerWrapper who)
    {
    }

    public void UpdateSleepingOnBed()
    {
    }

    public void GrantLoveMailIfNecessary()
    {
    }

    public void setAtFarmPosition()
    {
    }
    
    public void playContentSound()
    {
    }

    public void hold(IFarmerWrapper who)
    {
    }

    public void RunState(GameTime time)
    {
    }

    public void OnNewBehavior()
    {
    }
  }
}
