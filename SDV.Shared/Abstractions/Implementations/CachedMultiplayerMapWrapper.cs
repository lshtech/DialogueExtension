using StardewValley;

namespace SDV.Shared.Abstractions
{
  public class CachedMultiplayerMapWrapper : ICachedMultiplayerMapWrapper
  {
    public CachedMultiplayerMapWrapper(CachedMultiplayerMap item) => GetBaseType = item;
    public CachedMultiplayerMap GetBaseType { get; }
  }
}
