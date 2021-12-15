using System;

namespace DesignPatternPrinciple.SRP
{
  /// <summary>
  /// 一个类只做一件事，一个方法也只做一件事
  /// 成本：类变多了
  /// </summary>
  public class Animal
  {
    private string _Name;

    public Animal(string name)
    {
      this._Name = name;
    }

    internal void Breath()
    {
      Console.WriteLine($"{this._Name} 呼吸空气");
    }

    internal void Action()
    {
      Console.WriteLine($"{this._Name} 飞");
    }
  }
}
