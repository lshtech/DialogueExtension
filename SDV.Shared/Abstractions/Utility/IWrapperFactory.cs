namespace SDV.Shared.Abstractions.Utility
{
  public interface IWrapperFactory
  {
    TInterface CreateInstance<TInterface>();
    TInterface CreateInstance<TInterface>(object item);
    TInterface CreateInstance<TInterface>(params object[] args);
  }
}