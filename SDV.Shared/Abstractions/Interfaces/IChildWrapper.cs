namespace SDV.Shared.Abstractions
{
  public interface IChildWrapper : INPCWrapper
  {
    bool isInCrib();
    void toss(IFarmerWrapper who);
    void performToss(IFarmerWrapper who);
    void doneTossing(IFarmerWrapper who);
    void tenMinuteUpdate();
    int GetChildIndex();
    void toddlerReachedDestination(ICharacterWrapper c, IGameLocationWrapper l);
    void resetForPlayerEntry(IGameLocationWrapper l);
  }
}