using StardewValley.GameData;

namespace SDV.Shared.Abstractions
{
  public class SpecialOrderDataWrapper : ISpecialOrderDataWrapper
  {
    public SpecialOrderDataWrapper(SpecialOrderData item) => GetBaseType = item;
    public SpecialOrderData GetBaseType { get; }
  }
}
