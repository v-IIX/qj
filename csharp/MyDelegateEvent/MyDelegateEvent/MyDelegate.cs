using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent
{
  /// <summary>
  /// 委托：是一个类，继承自System.MulticastDelegate，里面有几个方法
  /// </summary>
  public delegate void NoReturnNoParaOutClass();
  public class MyDelegate
  {
    public delegate void NoReturnWithGeneric<T>(T t);
    public delegate void NoReturnNoPara();
    public delegate void NoReturnWhitPara(int x, int y);
    public delegate int WithReturnNoPara();
    public delegate string WhitReturnWithPara(out int x, ref int y);

    public void Show()
    {
      Student student = new Student()
      {
        Id = 123,
        Name = "Spring",
        Age = 22,
        ClassId = 1
      };

      student.Study();

      {
        NoReturnNoPara method = new MyDelegate.NoReturnNoPara(this.DoNothing);
        method.Invoke(); //等价于method();
      }
    }

    private void DoNothing()
    {
      Console.WriteLine($"{this.GetType().Name} DoNothing");
    }
  }
}
