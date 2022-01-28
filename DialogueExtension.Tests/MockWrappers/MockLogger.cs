using System;
using StardewModdingAPI;

namespace DialogueExtension.Tests.MockWrappers
{
  public class MockLogger : IMonitor
  {
    public void Log(string message, LogLevel level = LogLevel.Trace)
    {
      Console.WriteLine($"{level} | {message}");
    }

    public void LogOnce(string message, LogLevel level = LogLevel.Trace)
    {
      Log(message,level);
    }

    public void VerboseLog(string message)
    {
      Log(message);
    }

    public bool IsVerbose { get; }
  }
}
