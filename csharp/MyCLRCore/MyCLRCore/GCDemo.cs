using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCLRCore
{
  /// <summary>
  /// 什么是垃圾：访问不到的东西
  /// </summary>
  public class GCDemo
  {
    private static Student student = new Student()
    {
      Id = 123,
      Name = "viix"
    };

    public static void Show()
    {
    }
  }

  internal class Student
  {
    internal int Id;
    internal string Name;
  }
}
