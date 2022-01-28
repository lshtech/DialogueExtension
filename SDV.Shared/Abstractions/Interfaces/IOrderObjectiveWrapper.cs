﻿using System.Collections.Generic;
using Netcode;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public interface IOrderObjectiveWrapper : IWrappedType<OrderObjective>
  {
    NetFields NetFields { get; }
    void OnFail();
    void InitializeNetFields();
    void Register(ISpecialOrderWrapper new_order);
    void Unregister();
    bool ShouldShowProgress();
    int GetCount();
    void IncrementCount(int amount);
    void SetCount(int new_count);
    int GetMaxCount();
    void OnCompletion();
    void CheckCompletion(bool play_sound = true);
    bool IsComplete();
    bool CanUncomplete();
    bool CanComplete();
    string GetDescription();
    void Load(ISpecialOrderWrapper order, IDictionary<string, string> data);
  }
}