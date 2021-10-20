using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq
{
  public delegate void NoReturnNoParaOutClass();
  public delegate void GenericDelegate<T>();

  public class LambdaShow
  {
    public delegate void NoReturnNoPara();
    public delegate void NoReturnWithPara(int x, int y);
    public delegate int WithReturnNoPara();
    public delegate string WithReturnWithPara(out int x, ref int y);

    public void Show()
    {
      {
        //最原始的做法
        NoReturnNoPara method = new NoReturnNoPara(this.DoNothing);
      }

      {
        //使用匿名方法
        NoReturnNoPara method = new NoReturnNoPara(delegate ()
        {
          Console.WriteLine("This is DoNothing");
        });
      }

      {
        //lambda:左边是参数列表，右边是方法体，中间是goes to。本质就是一个方法
        //=> 称为goes to 
        NoReturnNoPara method = new NoReturnNoPara(() =>
       {
         Console.WriteLine("This is DoNothing");
       });
      }

      {
        //lambda:有参数
        NoReturnWithPara method = new NoReturnWithPara((int x, int y) =>
        {
          Console.WriteLine("This is DoNothing");
        });
      }

      {
        //lambda:省略参数类型
        NoReturnWithPara method = new NoReturnWithPara((x, y) =>
        {
          Console.WriteLine("This is DoNothing");
        });
      }

      {
        //lambda:省略大括号
        NoReturnWithPara method = new NoReturnWithPara((x, y) => Console.WriteLine("This is DoNothing"));
      }

      {
        //lambda:省略实例化语句
        NoReturnWithPara method = (x, y) => Console.WriteLine("This is DoNothing");
      }

    }

    private void DoNothing()
    {
      Console.WriteLine("This is DoNothing");
    }
  }
}
