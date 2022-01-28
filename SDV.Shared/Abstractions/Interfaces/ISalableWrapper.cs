using StardewValley;

namespace SDV.Shared.Abstractions
{
  public interface ISalableWrapper : ISalable
  {
    int addToStack(IItemWrapper stack);
    bool CanBuyItem(IFarmerWrapper farmer);
    bool canStackWith(ISalableWrapper other);
    new ISalableWrapper GetSalableInstance();
  }
}