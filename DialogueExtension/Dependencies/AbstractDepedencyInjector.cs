namespace DialogueExtension.Dependencies
{
  public class AbstractDependencyInjector
  {
    public IDependencyHandler DependencyHandler;
    public AbstractDependencyInjector(IDependencyHandler dependencyHandler) => 
      DependencyHandler = dependencyHandler;
  }
}
