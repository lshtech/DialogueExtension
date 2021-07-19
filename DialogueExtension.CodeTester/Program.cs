using System;
using System.Collections.Generic;
using System.Threading;

namespace DialogueExtension.CodeTester
{
  class Program
  {
    static void Main(string[] args)
    {
      //var x new Initialization();
      //_ = new TestClass("Inherited Class");

      for (var i = 1; i <= 200; i++)
      {
        var twoDigit = i.ToString("00");
        Console.WriteLine($"{twoDigit} | {int.Parse(twoDigit)}");
      }
      Console.ReadLine();
    }


    private static bool? Test(int a, int b)
    {
      Console.WriteLine($"values: {a} | {b}");
      if (a > b) return true;
      return null;
    }
  }

  public class Api : IApi
  {
    //public Func<string, bool> CheckHeartLevel { get; set; }
    Random rand = new Random();
    public Api()
    {
      
      //CheckHeartLevel = s => int.Parse(s) >= rand.Next(0, 10);
    }

    public Func<string, bool> CheckHeartLevel() => s => int.Parse(s) >= rand.Next(0, 10);
  }

  public delegate void UpdateStatusEventHandler(int index);
  public delegate void StartedEventHandler(int time);


  public interface IApi
  {
    Func<string, bool> CheckHeartLevel();
  }

  public class Worker 
  {
    public Worker()
    {
      var funcs = new List<Func<string, bool>>();
      for (var i = 0; i < 10; i++)
      {
        IApi x = new Api();
        Thread.Sleep(1000);
        Console.WriteLine(x.CheckHeartLevel().Invoke(i.ToString()));
      }

      foreach (var func in funcs)
      {
        
      }
    }
  }
}
//Console.WriteLine(apis[0].CheckHeartLevel(i.ToString()));