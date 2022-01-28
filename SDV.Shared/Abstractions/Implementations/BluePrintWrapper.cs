using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public class BluePrintWrapper : IBluePrintWrapper
  {
    public BluePrintWrapper(BluePrint item) => GetBaseType = item;
    public BluePrint GetBaseType { get; }
    public void consumeResources()
    {
    }

    public int getTileSheetIndexForStructurePlacementTile(int x, int y) => 0;

    public bool isUpgrade() => false;

    public bool doesFarmerHaveEnoughResourcesToBuild() => false;

    public void drawDescription(SpriteBatch b, int x, int y, int width)
    {
    }
  }
}
