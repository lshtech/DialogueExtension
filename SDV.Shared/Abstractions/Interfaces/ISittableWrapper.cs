using Microsoft.Xna.Framework;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public interface ISittableWrapper : ISittable
  {
    bool IsSittingHere(IFarmerWrapper who);
    void RemoveSittingFarmer(IFarmerWrapper farmer);
    Vector2? GetSittingPosition(IFarmerWrapper who, bool ignore_offsets = false);
    Vector2? AddSittingFarmer(IFarmerWrapper who);
    bool IsSeatHere(IGameLocationWrapper location);
  }
}
