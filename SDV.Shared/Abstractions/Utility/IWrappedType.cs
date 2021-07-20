namespace SDV.Shared.Abstractions
{
  public interface IWrappedType<T> where T : class
  {
    T GetBaseType { get; }
  }

}
