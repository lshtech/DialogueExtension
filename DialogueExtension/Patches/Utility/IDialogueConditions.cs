using StardewValley;

namespace DialogueExtension.Patches.Utility
{
  public interface IDialogueConditions
  {
    NPC Npc { get; }
    NPC BaseNpc { get; }
    string Year { get; }
    int FirstOrSecondYear { get; }
    Season Season { get; }
    int DayOfMonth { get; }
    DayOfWeek DayOfWeek { get; }
    string Inlaw { get; }
    int Friendship { get; }
    int Hearts { get; }
  }
}