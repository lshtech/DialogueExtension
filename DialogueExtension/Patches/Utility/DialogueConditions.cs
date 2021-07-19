using System;
using StardewValley;

namespace DialogueExtension.Patches.Utility
{
  public struct DialogueConditions
  {
    public DialogueConditions(ref NPC npc, string year, Season season, int dayOfMonth, DayOfWeek dayOfWeek,
      string inlaw, int friendship)
    {
      Npc = npc;
      _year = "1";
      Season = season;
      _dayOfMonth = 1;
      DayOfWeek = dayOfWeek;
      Inlaw = inlaw;
      _friendship = 0;

      // Struct restriction: all values must be set before conditional code can be run
      Year = year;
      DayOfMonth = dayOfMonth;
      Friendship = friendship;
    }

    private string _year;
    private int _dayOfMonth;
    private int _friendship;

    public NPC Npc { get; }

    public string Year
    {
      get => _year;
      private set
      {
        if (!int.TryParse(value, out var year) || (year <= 0 && year != -1))
          throw new ArgumentException($"Value '{value}' is not a non-zero positive integer or -1 if unknown");
        _year = value;
      }
    }

    public int FirstOrSecondYear =>
      int.Parse(Year) == 1 ? 1 : 2;

    public Season Season { get; }

    public int DayOfMonth
    {
      get => _dayOfMonth;
      private set
      {
        if ((value != -1 && value < 1) || value > 28)
          throw new ArgumentException(
            $"Value '{value}' is not a valid day of month. Allowed values: 1-28 or -1 if unknown");
        _dayOfMonth = value;
      }
    }

    public DayOfWeek DayOfWeek { get; }
    public string Inlaw { get; }

    public int Friendship
    {
      get => _friendship;
      private set
      {
        if ((value == -1 || value >= 0) && value <= 3500)
          _friendship = value;
      }
    }

    public int Hearts => Friendship >= 0 ? Friendship / 250 : -1;
  }
}