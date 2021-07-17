using DialogueExtension.Tests.Mocks;
using Moq;
using NUnit.Framework;

namespace DialogueExtension.Dependencies.Tests
{
  [TestFixture]
  public class ExtensionsTests
  {
    private Mock<IDependencyHandler> BuildMockDependencyHandler()
    {
      var handler = new Mock<IDependencyHandler>();
      handler.Setup(h => h.RegisterInstance<IBasicDependency, BasicDependency>
          (new BasicDependency(), It.IsAny<string>()))
        .Returns(handler.Object);
      handler.Setup(h => h.RegisterType<IBasicDependency, BasicDependency>
        (It.IsAny<string>())).Returns(handler.Object);
      handler.Setup(h => h.Resolve<IBasicDependency>(It.IsAny<string>()))
        .Returns(new BasicDependency());
      return handler;
    }

    [Test]
    public void RegisterType_Test()
    {
      // Arrange
      var handler = BuildMockDependencyHandler();

      // Act
      var returnedHandler = handler.Object.RegisterType<IBasicDependency, BasicDependency>();

      // Assert
      Assert.That(returnedHandler != null);
      Assert.That(handler.Invocations.Count > 0);
      Assert.That(handler.Invocations[handler.Invocations.Count -1].IsVerified);
    }

    [Test]
    public void RegisterTypeByName_Test()
    {
      // Arrange
      var handler = BuildMockDependencyHandler();

      // Act
      var returnedHandler = handler.Object.RegisterType<IBasicDependency, BasicDependency>("LostRiver");

      // Assert
      Assert.That(returnedHandler != null);
      Assert.That(handler.Invocations.Count > 0);
      Assert.That(handler.Invocations[handler.Invocations.Count - 1].IsVerified);
    }

    [Test]
    public void RegisterInstance_Test()
    {
      // Arrange
      var handler = BuildMockDependencyHandler();

      // Act
      var returnedHandler = handler.Object.RegisterInstance<IBasicDependency, BasicDependency>(new BasicDependency());

      // Assert
      Assert.That(returnedHandler != null);
      Assert.That(handler.Invocations.Count > 0);
      Assert.That(handler.Invocations[handler.Invocations.Count - 1].IsVerified);
    }

    [Test]
    public void RegisterInstanceByName_Test()
    {
      // Arrange
      var handler = BuildMockDependencyHandler();

      // Act
      var returnedHandler = handler.Object.RegisterInstance<IBasicDependency, BasicDependency>(new BasicDependency(), "LostRiver");

      // Assert
      Assert.That(returnedHandler != null);
      Assert.That(handler.Invocations.Count > 0);
      Assert.That(handler.Invocations[handler.Invocations.Count - 1].IsVerified);
    }

    [Test]
    public void Resolve_Test()
    {
      // Arrange
      var handler = BuildMockDependencyHandler();

      // Act
      var dependency = handler.Object.Resolve<IBasicDependency>();

      // Assert
      Assert.That(dependency != null);
      Assert.That(handler.Invocations.Count > 0);
      Assert.That(handler.Invocations[handler.Invocations.Count - 1].IsVerified);
    }

    [Test]
    public void ResolveByName_Test()
    {
      // Arrange
      var handler = BuildMockDependencyHandler();

      // Act
      var dependency = handler.Object.Resolve<IBasicDependency>("LostRiver");

      // Assert
      Assert.That(dependency != null);
      Assert.That(handler.Invocations.Count > 0);
      Assert.That(handler.Invocations[handler.Invocations.Count - 1].IsVerified);
    }
  }
}