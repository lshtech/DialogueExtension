using Microsoft.Xna.Framework.Input;
using StardewValley;

namespace SDV.Shared.Abstractions
{
  public interface IResponseWrapper : IWrappedType<Response>
  {
    IResponseWrapper SetHotKey(Keys key);
  }
}