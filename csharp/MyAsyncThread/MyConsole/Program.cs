using AwaiAsyncLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsole
{
  /// <summary>
  /// 控制台测试await/async
  /// C#5.0 、.net framework4.5、 clr4.0
  /// await/async 是语法糖，本身是编译器提供的功能
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        AwaitAsyncClass.TestShow();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }

      Console.ReadLine();
    }
  }
}
