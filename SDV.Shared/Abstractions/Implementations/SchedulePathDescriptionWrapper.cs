using StardewValley;

namespace SDV.Shared.Abstractions
{
  public class SchedulePathDescriptionWrapper : ISchedulePathDescriptionWrapper
  {
    public SchedulePathDescriptionWrapper(SchedulePathDescription item) => GetBaseType = item;
    public SchedulePathDescription GetBaseType { get; }
  }
}
