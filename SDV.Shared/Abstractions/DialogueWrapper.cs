using System.Collections.Generic;
using JetBrains.Annotations;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public class DialogueWrapper : IDialogueWrapper
  {
    public DialogueWrapper([NotNull] Dialogue item) => GetBaseType = item;

    public DialogueWrapper(string masterDialogue, INPCWrapper speaker) 
      : this(new Dialogue(masterDialogue, speaker.GetBaseType))
    { }


    public string CurrentEmotion { get; set; }
    public Farmer farmer { get; }
    public void setCurrentDialogue(string dialogue)
    {
    }

    public void addMessageToFront(string dialogue)
    {
    }

    public int getPortraitIndex() => 0;

    public void prepareDialogueForDisplay()
    {
    }

    public string getCurrentDialogue() => null;

    public bool isItemGrabDialogue() => false;

    public bool isOnFinalDialogue() => false;

    public bool isDialogueFinished() => false;

    public string checkForSpecialCharacters(string str) => null;

    public string exitCurrentDialogue() => null;

    public List<NPCDialogueResponse> getNPCResponseOptions() => null;

    public List<Response> getResponseOptions() => null;

    public bool isCurrentDialogueAQuestion() => false;

    public bool chooseResponse(Response response) => false;
    public Dialogue GetBaseType { get; }
  }
}
