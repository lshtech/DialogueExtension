namespace DialogueExtension.Dependencies
{
  public interface IDependencyHandler
  {
    IDependencyHandler RegisterType<TFrom, TTo>(string name)
      where TFrom : class
      where TTo : class, TFrom, new();

    IDependencyHandler RegisterInstance<TFrom, TTo>(TTo instance, string name)
      where TFrom : class
      where TTo : class, TFrom, new();

    T Resolve<T>(string name)
      where T : class;
  }
}