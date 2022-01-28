using StardewValley;

namespace SDV.Shared.Abstractions
{
  public class NPCDialogueResponseWrapper : ResponseWrapper, INpcDialogueResponseWrapper
  {
    public NPCDialogueResponseWrapper(Response item) : base(item)
    {
    }
  }
}
