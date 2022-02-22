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
  public class SingletonSecond
  {
    private static SingletonSecond singletonSecond = null;

    /// <summary>
    /// 构造函数，耗时长，不适合多次实例化
    /// </summary>
    private SingletonSecond()
    {
      long lResult = 0;
      for (int i = 0; i < 10000; i++)
      {
        lResult += i;
      }
      Thread.Sleep(1000);
      Console.WriteLine($"{this.GetType().Name}");
    }

    static SingletonSecond() //静态构造函数，由CRL调用，程序第一次使用这个类型前补调用，且只调用一次
    {
      singletonSecond = new SingletonSecond();
    }

    public static SingletonSecond CreateInstance()
    {
      return singletonSecond;
    }

    /// <summary>
    /// 原型模式：解决对象重复创建的问题
    /// 通过MemberwiseClone来clone新对象，避免重复创建
    /// </summary>
    /// <returns></returns>
    public static SingletonSecond CreateInstancePrototype()
    {
      SingletonSecond second = (SingletonSecond)singletonSecond.MemberwiseClone();
      return second;
    }
  }
}
