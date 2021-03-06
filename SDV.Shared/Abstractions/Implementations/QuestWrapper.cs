using System.Collections.Generic;
using StardewValley.Quests;

namespace SDV.Shared.Abstractions
{
  public interface IQuestWrapper : IQuest, IWrappedType<Quest>
  {
  }

  public class QuestWrapper : IQuestWrapper
  {
    public QuestWrapper(Quest item) => GetBaseType = item;
    public string GetName() => null;

    public string GetDescription() => null;

    public List<string> GetObjectiveDescriptions() => null;

    public bool CanBeCancelled() => false;

    public void MarkAsViewed()
    {
    }

    public bool ShouldDisplayAsNew() => false;

    public bool ShouldDisplayAsComplete() => false;

    public bool IsTimedQuest() => false;

    public int GetDaysLeft() => 0;

    public bool IsHidden() => false;

    public bool HasReward() => false;

    public bool HasMoneyReward() => false;

    public int GetMoneyReward() => 0;

    public void OnMoneyRewardClaimed()
    {
    }

    public bool OnLeaveQuestPage() => false;

    public Quest GetBaseType { get; }
  }
}