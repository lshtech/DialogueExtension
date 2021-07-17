using System;
using System.Collections.Generic;

namespace DialogueExtension.Dependencies
{
  public class DependencyHandler : IDependencyHandler
  {
    private readonly IDictionary<Type, IDependency> _registeredTypes;
    public DependencyHandler() => 
      _registeredTypes = new Dictionary<Type, IDependency>();


    public IDependencyHandler RegisterType<TFrom, TTo>(string name)
      where TFrom : class
      where TTo : class, TFrom, new()
    {
      if (!_registeredTypes.ContainsKey(typeof(TFrom)))
        _registeredTypes.Add(typeof(TFrom), new Dependency<TFrom>());
      ((Dependency<TFrom>) _registeredTypes[typeof(TFrom)]).AddRegistration<TTo>(name);
      return this;
    }

    public IDependencyHandler RegisterInstance<TFrom, TTo>(TTo instance, string name)
      where TFrom : class
      where TTo : class, TFrom, new()
    {
      if (!_registeredTypes.ContainsKey(typeof(TFrom)))
        _registeredTypes.Add(typeof(TFrom), new Dependency<TFrom>());
      ((Dependency<TFrom>) _registeredTypes[typeof(TFrom)]).AddRegistration(instance, name);
      return this;
    }

    public T Resolve<T>(string name)
      where T : class =>
      ((Dependency<T>) _registeredTypes[typeof(T)]).GetRegistration(name);
  }
}