using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public class SalableWrapper : ISalableWrapper
  {
    public bool ShouldDrawIcon() => false;

    public void drawInMenu(SpriteBatch spriteBatch, Vector2 location, float scaleSize, float transparency, float layerDepth,
      StackDrawType drawStackNumber, Color color, bool drawShadow)
    {
    }

    public string getDescription() => null;

    public int maximumStackSize() => 0;
    int ISalable.addToStack(Item stack) => 0;

    public int addToStack(IItemWrapper stack) => 0;

    public int salePrice() => 0;

    public bool actionWhenPurchased() => false;
    bool ISalable.canStackWith(ISalable other) => false;

    bool ISalable.CanBuyItem(Farmer farmer) => false;

    public bool canStackWith(ISalableWrapper other) => false;

    public bool CanBuyItem(IFarmerWrapper farmer) => false;

    public bool IsInfiniteStock() => false;
    ISalable ISalable.GetSalableInstance() => GetSalableInstance();

    public ISalableWrapper GetSalableInstance() => null;

    public string DisplayName { get; }
    public string Name { get; }
    public int Stack { get; set; }
  }
}
