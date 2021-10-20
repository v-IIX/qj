using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyLinq
{
  /// <summary>
  /// 扩展方法：静态类的静态方法里面，第一个参数类型前面加上this
  /// 用途：可以不修改类的情况下，增加方法
  /// 缺点：如果类里有，又用扩展方法方式增加方法，优先调用实例方法；如果扩展的是基类型，导致所有子类都有这个方法。
  /// 扩展时候，指定具体类型，而不是基类型。
  /// </summary>
  public static class ExtendMethod
  {
    /// <summary>
    /// 1 基于委托封装解耦，去掉重复代码
    /// 2 泛型，应对各种数据，完成代码通用
    /// 3 加入迭代器，按需获取
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <param name="func"></param>
    /// <returns></returns>
    /// 

    #region 针对Student
    //public static List<Student> ElevenWhere<T>(this List<Student> source, Func<Student, bool> func)
    //{
    //  var list = new List<Student>();
    //  foreach (var item in source)
    //  {
    //    Thread.Sleep(500);
    //    Console.WriteLine("获取数据");
    //    if (func.Invoke(item))
    //    {
    //      list.Add(item);
    //    }
    //  }

    //  return list;
    //}
    #endregion

    #region 加入泛型
    //public static List<T> ElevenWhere<T>(this List<T> source,Func<T,bool> func)
    //{
    //  var list = new List<T>();
    //  foreach (var item in source)
    //  {
    //    Thread.Sleep(500);
    //    Console.WriteLine("获取数据");
    //    if (func.Invoke(item))
    //    {
    //      list.Add(item);
    //    }
    //  }

    //  return list;
    //}
    #endregion

    #region 加入迭代器
    public static IEnumerable<T> ElevenWhere<T>(this IEnumerable<T> source, Func<T, bool> func)
    {
      if (source == null)
        throw new Exception("source is null");

      if(func == null)
        throw new Exception("fun is null");
      
      foreach (var item in source)
      {
        if (func.Invoke(item))
        {
          yield return item;
        }
      }
    }
    #endregion


    public static void Sing(this Student student)
    {
      Console.WriteLine($"{student.Name} Sing a Song");
    }

    public static void Show<T>(T t)//泛型扩展方法，最好加约束
    {

    }
  }
}
