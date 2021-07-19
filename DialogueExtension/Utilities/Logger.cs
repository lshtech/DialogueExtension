using StardewModdingAPI;

namespace DialogueExtension.Utilities
{
  public class Logger : IMonitor
  {
    public Logger(IMonitor monitor)
    {
      Monitor = monitor;
    }

    public IMonitor Monitor { get; }
    public void Log(string message, LogLevel level = LogLevel.Trace) => 
      Monitor.Log(message, level);

    public void LogOnce(string message, LogLevel level = LogLevel.Trace) => 
      Monitor.LogOnce(message, level);

    public void VerboseLog(string message) => 
      Monitor.VerboseLog(message);

    public bool IsVerbose => Monitor.IsVerbose;
  }
}