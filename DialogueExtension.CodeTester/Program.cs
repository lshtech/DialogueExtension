using System;

namespace DialogueExtension.CodeTester
{
  class Program
  {
    static void Main(string[] args)
    {
      DependencyHandlerChecks();
      Console.ReadLine();
    }

    private static void DependencyHandlerChecks()
    {
      var handler = new Dependencies.DependencyHandler();
      handler.RegisterType<ITest, Test>("Type");
      handler.RegisterInstance<ITest, Test>(new Test(), "Instance");

      var test = handler.Resolve<ITest>("Type");
      Console.WriteLine("--- Type ---");
      Console.WriteLine($"{test.Name} | {test.Number}");
      test.Name = "Altered for Types";
      test.Number = 32;
      Console.WriteLine($"{test.Name} | {test.Number}");
      Console.WriteLine();
      test = handler.Resolve<ITest>("Instance");
      Console.WriteLine("--- Instance ---");
      Console.WriteLine($"{test.Name} | {test.Number}");
      test.Name = "Altered for Instances";
      test.Number = 98;
      Console.WriteLine($"{test.Name} | {test.Number}");
      Console.WriteLine();
      test = handler.Resolve<ITest>("Type");
      Console.WriteLine("--- Type 2 ---");
      Console.WriteLine($"{test.Name} | {test.Number}");
      Console.WriteLine();
      test = handler.Resolve<ITest>("Instance");
      Console.WriteLine("--- Instance 2 ---");
      Console.WriteLine($"{test.Name} | {test.Number}");
      Console.WriteLine();
    }

    public interface ITest
    {
      string Name { get; set; }
      int Number { get; set; }
    }

    public class Test : ITest
    {
      public Test()
      {
        Name = "Original";
        Number = 66;
      }
      public string Name { get; set; }
      public int Number { get; set; }
    }
  }
}
