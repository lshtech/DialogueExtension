using Microsoft.Xna.Framework;
using StardewValley.Objects;

namespace SDV.Shared.Abstractions
{
  public interface IBedFurnitureWrapper : IFurnitureWrapper
  {
    BedFurniture.BedType bedType { get; set; }
    bool IsBeingSleptIn(IGameLocationWrapper location);
    void ReserveForNPC();
    bool CanModifyBed(IGameLocationWrapper location, IFarmerWrapper who);

    Point GetBedSpot();
    void UpdateBedTile(bool check_bounds);
  }
}