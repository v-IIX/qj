using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SingletonPattern
{

  /// <summary>
  /// 懒汉式（需要时才创建）
  /// 双if加lock 标准单例模式
  /// </summary>
  /// <returns></returns>
  public class Singleton
  {
    /// <summary>
    /// 构造函数，耗时长，不适合多次实例化
    /// </summary>
    private Singleton() //避免外部创建
    {
      long lResult = 0;
      for (int i = 0; i < 10000; i++)
      {
        lResult += i;
      }
      Thread.Sleep(1000);
      Console.WriteLine($"{this.GetType().Name}");
    }

    /// <summary>
    /// singleton 全局唯一的静态字段，重用这个变量
    /// </summary>
    private static volatile Singleton singleton = null; //volatile关键字用以促进线程安全，不加也可以
    private static object Singleton_Lock = new object();


    public static Singleton CreateSingleton()
    {
      if (singleton == null) //保证对象初始化之后，不用去等待锁
      {
        lock (Singleton_Lock) //保证只有一个进程进去
        {
          Console.WriteLine($"这里做了1s的锁等待");
          if (singleton == null)  //保证只被实例化一次
          {
            singleton = new Singleton();
          }
        }
      }
      return singleton;
    }
  }
}
