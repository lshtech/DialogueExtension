using System;

namespace DialogueExtension.Tests.Mocks
{
  public interface IBasicDependency
  {
    string Name { get; set; }
    string Description { get; set; }
    double Number { get; set; }
    void NextNumber();
  }

  public class BasicDependency : IBasicDependency
  {
    private readonly Random _random;
    public BasicDependency() => _random = new Random();
    public string Name { get; set; } = "Steve Miller";
    public string Description { get; set; } = "Some people call me the Space Cowboy";
    public double Number { get; set; } = 7.7;
    public void NextNumber() => Number = _random.NextDouble();
  }
}
