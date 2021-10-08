using MyAttribute.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
  /// <summary>
  /// 特性：中括号申明
  /// 错觉：第一个特性都可以带来对应的功能
  /// 实际上特性添加后，编译会在元素内部产生IL，但是我们是没有办法直接使用的，
  /// 而且在metadata里面会有记录
  /// 
  /// 特性，本身是没用的
  /// 程序运行的过程中，我们能找到特性，而且也能应用一下
  /// 
  /// 没有破坏类型封闭的前提下，可以加点额外的信息和行为
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      Student student = new Student();
      student.Id = 123;
      student.Name = "timo";
      student.QQ = 123456;
      Manager.Show(student);
      student.QQ = 9999;
      Manager.Show(student);
      {
        UserState userState = UserState.Normal;
        Console.WriteLine(userState.GetRemark());
        Console.WriteLine(UserState.Delete.GetRemark()); ;
        //if (userState == UserState.Normal)
        //{
        //  Console.WriteLine("正常状态");
        //}
        //else if (userState == UserState.Frozen)
        //{
        //  Console.WriteLine("冻结状态");
        //}
        //else
        //{
        //  Console.WriteLine("删除状态");
        //}
      }

      Console.ReadKey();
    }
  }
}
