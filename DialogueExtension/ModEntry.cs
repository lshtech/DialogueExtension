﻿using StardewModdingAPI;

namespace DialogueExtension
{
  public class ModEntry : Mod
  {
    public override void Entry(IModHelper helper)
    {
      _ = new Initialization(this);
    }
  }
}
