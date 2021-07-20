using JetBrains.Annotations;
using LightInject;

namespace SDV.Shared.Abstractions.Utility
{
  public class WrapperFactory : IWrapperFactory
  {
    public TInterface CreateInstance<TInterface>()
      => (TInterface) _serviceFactory.GetInstance(typeof(TInterface));

    public TInterface CreateInstance<TInterface>(object item)
      => (TInterface)_serviceFactory.GetInstance(typeof(TInterface), new []{item});

    public TInterface CreateInstance<TInterface>(params object[] args)
    => (TInterface)_serviceFactory.GetInstance(typeof(TInterface), args);

    [NotNull] private readonly IServiceFactory _serviceFactory;
    public WrapperFactory([NotNull] IServiceFactory factory) => _serviceFactory = factory;
  }
}
