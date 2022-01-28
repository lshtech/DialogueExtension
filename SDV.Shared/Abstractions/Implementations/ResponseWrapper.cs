using Microsoft.Xna.Framework.Input;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public class ResponseWrapper : IResponseWrapper
  {
    public string responseKey;
    public string responseText;
    public Keys hotkey;

    public IResponseWrapper SetHotKey(Keys key)
    {
      this.hotkey = key;
      return this;
    }

    public Response GetBaseType { get; }
    public ResponseWrapper(Response item) => GetBaseType = item;
  }
}