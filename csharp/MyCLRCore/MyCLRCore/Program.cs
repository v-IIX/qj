using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCLRCore
{
  /// <summary>
  /// 1 .net平台和CLR
  /// 2 堆栈内存分配：值类型和引用类型
  /// 3 垃圾回收和Dispose模式
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        StackHeap.Show();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }

      Console.ReadKey();
    }
  }
}
