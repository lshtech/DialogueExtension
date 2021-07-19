using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading;

namespace DialogueExtension.CodeTester
{
  class Program
  {
    static void Main(string[] args)
    {
      //var x new Initialization();
      //_ = new TestClass("Inherited Class");
      var api = new Api();
      var x = new DynamicProperties();
      x.Add("blarg", api);
      var y = x.Contains("blarg");
      var z = x.Get<Api>("blarg");
      var sf = api.Equals(z);
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

  public class DynamicProperties : IDictionary
  {
    private readonly IDictionary _propDict = new Hashtable();

    public void Add<T>(string key, T value)
    {
      if (_propDict.Contains(key))
        throw new ArgumentException("Key already exists");
      _propDict.Add(key, value);
    }

    public T Get<T>(string key) => (T)_propDict[key];

    public bool Contains(object key) => _propDict.Contains(key);

    public void Add(object key, object value) => Add(key.ToString(), value);

    public void Clear() => _propDict.Clear();

    public IDictionaryEnumerator GetEnumerator() => _propDict.GetEnumerator();

    public void Remove(object key)
    {
      _propDict.Remove(key);
    }

    public object this[object key]
    {
      get => _propDict[key];
      set => _propDict[key] = value;
    }

    public ICollection Keys => _propDict.Keys;
    public ICollection Values => _propDict.Values;
    public bool IsReadOnly => _propDict.IsReadOnly;
    public bool IsFixedSize => _propDict.IsFixedSize;

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void CopyTo(Array array, int index) =>
      _propDict.CopyTo(array, index);

    public int Count => _propDict.Count;
    public object SyncRoot => _propDict.SyncRoot;
    public bool IsSynchronized => _propDict.IsSynchronized;
  }
}
//Console.WriteLine(apis[0].CheckHeartLevel(i.ToString()));