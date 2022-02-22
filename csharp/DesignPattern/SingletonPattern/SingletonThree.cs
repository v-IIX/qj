using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonPattern
{
  /// <summary>
  /// 饿汉式
  /// </summary>
  public class SingletonThree
  {
    //静态字段：调用类之时，先完成静态字段初始化，在构造函数运行之前，且只初始化一次
    private static SingletonThree singletonThree = new SingletonThree();

    private SingletonThree()
    {
      long lResult = 0;
      for (int i = 0; i < 10000; i++)
      {
        lResult += i;
      }
      Thread.Sleep(1000);
      Console.WriteLine($"{this.GetType().Name}");
    }

    public static SingletonThree CreateInstance()
    {
      return singletonThree;
    }
  }
}
