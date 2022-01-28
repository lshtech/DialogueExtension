using Microsoft.Xna.Framework;
using Netcode;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public interface IBaseEnchantmentWrapper : IWrappedType<BaseEnchantment>
  {
    int Level { get; set; }
    NetFields NetFields { get; }
    bool IsForge();
    bool IsSecondaryEnchantment();
    void InitializeNetFields();
    void OnEquip(IFarmerWrapper farmer);
    void OnUnequip(IFarmerWrapper farmer);

    void OnCalculateDamage(
      IMonsterWrapper monster,
      IGameLocationWrapper location,
      IFarmerWrapper who,
      ref int amount);

    void OnDealDamage(IMonsterWrapper monster, IGameLocationWrapper location, IFarmerWrapper who, ref int amount);
    void OnMonsterSlay(IMonsterWrapper m, IGameLocationWrapper location, IFarmerWrapper who);
    void OnCutWeed(Vector2 tile_location, IGameLocationWrapper location, IFarmerWrapper who);
    IBaseEnchantmentWrapper GetOne();
    int GetLevel();
    void SetLevel(IItemWrapper item, int new_level);
    int GetMaximumLevel();
    void ApplyTo(IItemWrapper item, IFarmerWrapper farmer = null);
    bool IsItemCurrentlyEquipped(IItemWrapper item, IFarmerWrapper farmer);
    void UnapplyTo(IItemWrapper item, IFarmerWrapper farmer = null);
    bool CanApplyTo(IItemWrapper item);
    string GetDisplayName();
    string GetName();
    bool ShouldBeDisplayed();
  }
}