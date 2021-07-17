using System;
using System.Collections.Generic;

namespace DialogueExtension.Dependencies
{
  public class Dependency<T> : IDependency
    where T : class
  {
    private readonly IDictionary<string, ITypeInstance> _dependencyObjects;

    public Dependency()
    {
      if (!typeof(T).IsInterface) throw new ArgumentException("Type is not an interface");
      _dependencyObjects = new Dictionary<string, ITypeInstance>();
    }

    public T GetRegistration(string name) =>
      _dependencyObjects.ContainsKey(name) ? _dependencyObjects[name].Instance : null;

    public void AddRegistration<TOut>(TOut type, string name) where TOut : class, T, new()
    {
      if (!_dependencyObjects.ContainsKey(name))
        _dependencyObjects.Add(name, new TypeInstance<TOut>(type));
    }

    public void AddRegistration<TOut>(string name) where TOut : class, T, new()
    {
      if (!_dependencyObjects.ContainsKey(name))
        _dependencyObjects.Add(name, new TypeInstance<TOut>());
    }

    private class TypeInstance<TOut> : ITypeInstance
      where TOut : class, T, new()
    {
      private readonly TOut _instance;

      public TypeInstance(TOut instance) => _instance = instance;

      public TypeInstance() { }

      public T Instance => _instance ?? new TOut();
    }

    private interface ITypeInstance
    {
      T Instance { get; }
    }
  }

  public interface IDependency { }
}