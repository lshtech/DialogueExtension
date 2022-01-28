using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Objects;

namespace SDV.Shared.Abstractions
{
  public class BedFurnitureWrapper : FurnitureWrapper, IBedFurnitureWrapper
  {
    public BedFurnitureWrapper(Object item) : base(item)
    {
    }

    public BedFurniture.BedType bedType { get; set; }
    public bool IsBeingSleptIn(IGameLocationWrapper location) => false;

    public void ReserveForNPC()
    {
    }

    public bool CanModifyBed(IGameLocationWrapper location, IFarmerWrapper who) => false;

    public Point GetBedSpot() => default;

    public void UpdateBedTile(bool check_bounds)
    {
    }
  }
}
