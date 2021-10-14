using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOO.Interface
{
  /// <summary>
  /// 抽象类:是父类 + 约束（子类必须实现特定的方法）
  /// </summary>
  public abstract class BasePhone
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Branch { get; set; }

    public void Text()
    {
      Console.WriteLine($"{this.GetType().Name} Text");
    }

    public void Call()
    {
      Console.WriteLine($"{this.GetType().Name} Call");
    }

    public abstract void System();
  }
}
