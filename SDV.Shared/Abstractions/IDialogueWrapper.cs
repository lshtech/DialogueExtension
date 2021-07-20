using System.Collections.Generic;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public interface IDialogueWrapper : IWrappedType<Dialogue>
  {
    string CurrentEmotion { get; set; }
    Farmer farmer { get; }
    void setCurrentDialogue(string dialogue);
    void addMessageToFront(string dialogue);
    int getPortraitIndex();
    void prepareDialogueForDisplay();
    string getCurrentDialogue();
    bool isItemGrabDialogue();
    bool isOnFinalDialogue();
    bool isDialogueFinished();
    string checkForSpecialCharacters(string str);
    string exitCurrentDialogue();
    List<NPCDialogueResponse> getNPCResponseOptions();
    List<Response> getResponseOptions();
    bool isCurrentDialogueAQuestion();
    bool chooseResponse(Response response);
  }
}
