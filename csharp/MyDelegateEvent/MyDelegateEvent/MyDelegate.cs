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

      //BeginInvoke
      {
        WithReturnNoPara withReturnNoPara = new WithReturnNoPara(this.GetSomething);
        int iResult = withReturnNoPara.Invoke();
        iResult = GetSomething();
        var result =withReturnNoPara.BeginInvoke(null,null);
        withReturnNoPara.EndInvoke(result);
      }

      //多播委托:+=为委托实例按顺序增加方法，形成方法链，Invoke时，按顺序依次执行
      //-=为委托实例移除方法，从方法链的尾部开始匹配，遇到第一个完全吻合的，移除且只移除一个，没有匹配也不会报异常
      {
        WithReturnNoPara withReturnNoPara = new WithReturnNoPara(this.GetSomething);
        withReturnNoPara += new WithReturnNoPara(this.GetSomething);
        withReturnNoPara += new WithReturnNoPara(this.GetSomething);
        withReturnNoPara += new WithReturnNoPara(this.GetSomething);
        withReturnNoPara += new WithReturnNoPara(this.GetSomething);
        withReturnNoPara.Invoke();
        //withReturnNoPara.BeginInvoke(null,null); //多播委托不能异步调用

        //获取委托实例的每一个方法
        foreach (WithReturnNoPara method in withReturnNoPara.GetInvocationList())
        {
          method.Invoke();
        }
      }
    }

    private int GetSomething()
    {
      return 1;
    }

    private void DoNothing()
    {
      Console.WriteLine($"{this.GetType().Name} DoNothing");
    }
  }
}
