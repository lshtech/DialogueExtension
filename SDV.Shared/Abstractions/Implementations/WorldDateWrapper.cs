﻿using System;
using Netcode;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public class WorldDateWrapper : IWorldDateWrapper
  {
    public WorldDate GetBaseType { get; }
    public int Year { get; set; }
    public int SeasonIndex { get; }
    public int DayOfMonth { get; set; }
    public DayOfWeek DayOfWeek { get; }
    public string Season { get; set; }
    public int TotalDays { get; set; }
    public int TotalWeeks { get; }
    public int TotalSundayWeeks { get; }
    public NetFields NetFields { get; }
    public string Localize() => null;
  }
}
