using System;
using LightInject;

namespace DialogueExtension.CodeTester
{
  class Program
  {
    static void Main(string[] args)
    {
      var c = CreateContainer();
      var f = c.GetInstance<ITestFactory>();
      //var t = f.CreateInstance<IWrappedTest, string>("test string");
      var x = c.GetInstance(typeof(IWrappedTest), new[] {"porky pigb"});

      //var ff = c.GetInstance<IFooFactory>();
      //var f = ff.GetFoo(324);
      //var x = f;

      Console.ReadLine();
    }

    static ServiceContainer CreateContainer()
    {
      var container = new ServiceContainer();
      container.Register<string, IWrappedTest>((factory, item) => new WrappedTest(item));
      container.Register<ITestFactory, TestFactory>();

      container.Register<int, IFoo>((factory, i) => new Foo(i));
      container.Register<IFooFactory, FooFactory>();

      return container;
    }
  }

  public class TestFactory : ITestFactory
  {
    public TWrapped CreateInstance<TWrapped, TBase>(TBase item)
      where TBase : class
    {
      var instance = Activator.CreateInstance(typeof(TWrapped), item);
      return (TWrapped) instance;
    }

  }
  public interface ITestFactory
  {
    TWrapped CreateInstance<TWrapped, TBase>(TBase item)
      where TBase : class;


    //ITest<T> Get
  }
  public abstract class Test<T> : ITest<T> where T : class
  {
    protected T Item;
   // protected Test(T item) => _item = item;
    public string WhatAmI => Item.GetType().ToString();
  }
  public interface ITest<T> where T : class
  {
    string WhatAmI { get; }
  }

  public class WrappedTest : Test<string>, IWrappedTest
  {

    public WrappedTest(string item) => Item = item;
  }

  public interface IWrappedTest
  {

  }




  public class Foo : IFoo
  {
    public Foo(int value)
    {
      Value = value;
    }

    public int Value { get; private set; }

  
  }

  public interface IFooFactory
  {
    IFoo GetFoo(int value);
  }
  public class FooFactory : IFooFactory
  {
    private readonly Func<int, IFoo> _createFoo;

    public FooFactory(Func<int, IFoo> createFoo) => _createFoo = createFoo;

    public IFoo GetFoo(int value) => _createFoo(value);
  }

  public interface IFoo
  {

  }
 
}