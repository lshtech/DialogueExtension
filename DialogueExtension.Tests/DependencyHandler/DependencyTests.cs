using System;
using DialogueExtension.Tests.Mocks;
using NUnit.Framework;

namespace DialogueExtension.Dependencies.Tests
{
  [TestFixture]
  public class DependencyTests
  {
    [Test]
    public void InitializationWithInterface_DependencyTest()
    {
      // Arrange
      // // Act
      var dependency = new Dependency<IBasicDependency>();

      // Assert
      Assert.That(!(dependency is null));
    }

    [Test]
    public void InitializationWithClass_DependencyTest()
    {
      // Arrange
      // Act
      // Assert
      Assert.Throws<ArgumentException>(() => new Dependency<BasicDependency>());
    }

    [Test]
    public void AddRegistrationByType_Test()
    {
      // Arrange
      var dependency = new Dependency<IBasicDependency>();

      // Act
      dependency.AddRegistration<BasicDependency>(string.Empty);
      var basicDependency = dependency.GetRegistration(string.Empty);

      // Assert
      Assert.That(basicDependency.GetType() == typeof(BasicDependency));
    }

    [Test]
    public void AddRegistrationByInstance_Test()
    {
      // Arrange
      var dependency = new Dependency<IBasicDependency>();
      var initialDependency = new BasicDependency
      {
        Name = "High demand",
        Description = "A drink in the hand"
      };
      initialDependency.NextNumber();

      // Act
      dependency.AddRegistration(initialDependency, string.Empty);
      var basicDependency = dependency.GetRegistration(string.Empty);

      // Assert
      Assert.That(basicDependency.GetType() == typeof(BasicDependency));
      Assert.AreEqual(initialDependency.Name, basicDependency.Name);
      Assert.AreEqual(initialDependency.Description, basicDependency.Description);
      Assert.AreEqual(initialDependency.Number, basicDependency.Number);
    }

    [Test]
    public void GetRegistration_Test()
    {
      // Arrange
      var dependency = new Dependency<IBasicDependency>();

      // Act
      dependency.AddRegistration<BasicDependency>(string.Empty);
      var basicDependency = dependency.GetRegistration(string.Empty);

      // Assert
      Assert.That(basicDependency.GetType() == typeof(BasicDependency));
    }

    [Test]
    public void GetRegistrationByName_Test()
    {
      // Arrange
      var dependency = new Dependency<IBasicDependency>();
      const string key = "Stacy";

      // Act
      dependency.AddRegistration<BasicDependency>(key);
      var basicDependency = dependency.GetRegistration(key);

      // Assert
      Assert.That(basicDependency.GetType() == typeof(BasicDependency));
    }

    [Test]
    public void GetRegistrationInvalid_Test()
    {
      // Arrange
      var dependency = new Dependency<IBasicDependency>();
      const string key = "Stacy";

      // Act
      var basicDependency = dependency.GetRegistration(key);

      // Assert
      Assert.That(basicDependency == null);
    }
  }
}