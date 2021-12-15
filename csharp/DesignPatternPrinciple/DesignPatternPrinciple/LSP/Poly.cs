using System;

namespace DesignPatternPrinciple.LSP
{
  
  public class Poly
  {
    internal static void Test()
    {
      ParentClass instance = new ChildClass();
      instance.CommonMethod(); //父类方法 ，普通方法由左边决定，编译时决定
      instance.VirtualMethod(); //子类方法 ，虚方法由右边决定，运行时决定
      instance.AbstractMethod();  //子类方法 ，抽象方法由右边决定，运行时决定
    }
  }

  internal abstract class ParentClass
  {
    internal abstract void AbstractMethod();

    internal void CommonMethod()
    {
      Console.WriteLine($"{this.GetType().Name} CommonMethod");
    }

    internal virtual void VirtualMethod()
    {
      Console.WriteLine($"{this.GetType().Name} VirtualMethod NoParams");
    }

    internal virtual void VirtualMethod(string name)
    {
      Console.WriteLine($"{this.GetType().Name} VirtualMethod WhitParams");
    }
  }

  internal class ChildClass : ParentClass
  {
    public new void CommonMethod()
    {
      Console.WriteLine($"{this.GetType().Name} CommonMethod");
    }

    internal sealed override void AbstractMethod()
    {
      Console.WriteLine($"{this.GetType().Name} AbstractMethod");
    }

    internal override void VirtualMethod()
    {
      Console.WriteLine($"{this.GetType().Name} VirtualMethod NoParams");
    }
  }
}