using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public interface IBluePrintWrapper : IWrappedType<BluePrint>
  {
    void consumeResources();
    int getTileSheetIndexForStructurePlacementTile(int x, int y);
    bool isUpgrade();
    bool doesFarmerHaveEnoughResourcesToBuild();
    void drawDescription(SpriteBatch b, int x, int y, int width);
  }
}