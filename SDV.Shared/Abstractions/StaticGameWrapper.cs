using System;
using System.Collections;

namespace SDV.Shared.Abstractions
{
  public class DynamicProperties : IDictionary
  {
    private readonly IDictionary _propDict = new Hashtable();

    public void Add<T>(string key, T value)
    {
      if (_propDict.Contains(key))
        throw new ArgumentException("Key already exists");
      _propDict.Add(key, value);
    }

    public bool Contains(object key) => _propDict.Contains(key);

    public void Add(object key, object value) => Add(key.ToString(), value);
    
    public void Clear()=> _propDict.Clear();

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

    public void CopyTo(Array array, int index)=>
      _propDict.CopyTo(array, index);

    public int Count => _propDict.Count;
    public object SyncRoot => _propDict.SyncRoot;
    public bool IsSynchronized => _propDict.IsSynchronized;
  }

  public class fdsg
  {
    public void test()
    {
    //  var x = new DynamicProperties();
    //  x<string>.Add()
    //}
  }
}
