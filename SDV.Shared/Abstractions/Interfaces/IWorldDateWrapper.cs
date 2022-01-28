using System;
using Netcode;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public interface IWorldDateWrapper : IWrappedType<WorldDate>
  {
    int Year { get; set; }
    int SeasonIndex { get; }
    int DayOfMonth { get; set; }
    DayOfWeek DayOfWeek { get; }
    string Season { get; set; }
    int TotalDays { get; set; }
    int TotalWeeks { get; }
    int TotalSundayWeeks { get; }
    NetFields NetFields { get; }
    string Localize();
    string ToString();
  }
}