// ReSharper disable UnusedMember.Global
namespace DialogueExtension.Dependencies
{
  public static class Extensions
  {
    public static IDependencyHandler RegisterType<TFrom, TTo>(this IDependencyHandler handler)
      where TFrom : class
      where TTo : class, TFrom, new() =>
      RegisterType<TFrom, TTo>(handler, string.Empty);

    public static IDependencyHandler RegisterType<TFrom, TTo>(this IDependencyHandler handler, string name)
      where TFrom : class
      where TTo : class, TFrom, new() =>
      handler.RegisterType<TFrom, TTo>(name);

    public static IDependencyHandler RegisterInstance<TFrom, TTo>(this IDependencyHandler handler, TTo instance)
      where TFrom : class
      where TTo : class, TFrom, new() =>
      RegisterInstance<TFrom, TTo>(handler, instance, string.Empty);

    public static IDependencyHandler RegisterInstance<TFrom, TTo>(this IDependencyHandler handler, TTo instance,
      string name)
      where TFrom : class
      where TTo : class, TFrom, new() =>
      handler.RegisterInstance<TFrom, TTo>(instance, name);

    public static T Resolve<T>(this IDependencyHandler handler)
      where T : class =>
      Resolve<T>(handler, string.Empty);

    public static T Resolve<T>(this IDependencyHandler handler, string name)
      where T : class =>
      handler.Resolve<T>(name);

  }
}