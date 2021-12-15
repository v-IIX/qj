using System;

namespace DesignPatternPrinciple.DIP
{
  /// <summary>
  /// Student类用到IPhone类，Student称为高层类，IPhone类称为低层类
  /// </summary>
  internal class Student
  {
    public int Id { get; internal set; }
    public string Name { get; internal set; }

    /// <summary>
    /// 依赖细节，不合理
    /// </summary>
    /// <param name="iPhone"></param>
    internal void PlayIPhone(IPhone iPhone)
    {
      Console.WriteLine($"{this.Name} PlayIPhone");
      iPhone.Call();
      iPhone.Text();
    }

    /// <summary>
    /// 依赖细节，不合理
    /// </summary>
    /// <param name="iPhone"></param>
    internal void PlayLumia(Lumia lumia)
    {
      Console.WriteLine($"{this.Name} PlayLumia");
      lumia.Call();
      lumia.Text();
    }

    /// <summary>
    /// 依赖抽象，推荐
    /// </summary>
    /// <param name="iPhone"></param>
    internal void PlayPhone(AbstractPhone abstractPhone)
    {
      Console.WriteLine($"{this.Name} PlayPhone");
      abstractPhone.Call();
      abstractPhone.Text();
    }
  }
}