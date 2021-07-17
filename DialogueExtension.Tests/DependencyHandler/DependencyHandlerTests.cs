using DialogueExtension.Tests.Mocks;
using NUnit.Framework;

namespace DialogueExtension.Dependencies.Tests
{
  [TestFixture()]
  public class DependencyHandlerTests
  {
    [Test()]
    public void RegisterType_Test()
    {
      // Arrange
      var handler = new DependencyHandler();

      // Act
      handler.RegisterType<IBasicDependency, BasicDependency>("LostRiver");

      // Assert
      Assert.IsNotNull(handler.Resolve<IBasicDependency>("LostRiver"));
    }

    [Test()]
    public void RegisterInstance_Test()
    {
      // Arrange
      var handler = new DependencyHandler();

      // Act
      handler.RegisterInstance<IBasicDependency, BasicDependency>(new BasicDependency(), "LostRiver");

      // Assert
      Assert.IsNotNull(handler.Resolve<IBasicDependency>("LostRiver"));
    }

    [Test()]
    public void Resolve_Test()
    {
      // Arrange
      var handler = new DependencyHandler();
      handler.RegisterType<IBasicDependency, BasicDependency>("LostRiver");
      handler.RegisterInstance<IBasicDependency, BasicDependency>(new BasicDependency(), "LightsOut");

      // Act
      var dependency1 = handler.Resolve<IBasicDependency>("LostRiver");
      var dependency2 = handler.Resolve<IBasicDependency>("LightsOut");

      // Assert
      Assert.IsNotNull(dependency1);
      Assert.IsNotNull(dependency2);
    }
  }
}