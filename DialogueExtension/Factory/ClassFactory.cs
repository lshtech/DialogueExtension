using System.Reflection;
using DialogueExtension.Dependencies;

namespace DialogueExtension.Factory
{
  public class ClassFactory : IClassFactory
  {
    private IDependencyHandler _dependencyHandler;

    public ClassFactory() : this(new DependencyHandler()) {}
    public ClassFactory(IDependencyHandler dependencyHandler) 
    {
      _dependencyHandler = dependencyHandler;
      _dependencyHandler.RegisterInstance<IClassFactory, ClassFactory>(this, string.Empty);
    }

    public T BuildClass<T>() where T : class, new()
    {
      var newInstance = new T();
      if (newInstance.GetType().IsAssignableFrom(typeof(AbstractDependencyInjector)))
        (newInstance as AbstractDependencyInjector).DependencyHandler = _dependencyHandler;
      return newInstance;
    }

    //public T BuildClass<T>(string args)
    //{
    //  typeof(T).TypeInitializer.
    //  return new T();
    //}
  }
  public interface IClassFactory
  {

  }
}