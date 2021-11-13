using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAsyncThread
{
  /// <summary>
  /// 进程：一个程序运行时，占用的全部计算资源的总和
  /// 线程：程序执行流的最小单位，任何操作都是由线程完成的。
  ///      线程依托于进程存在的，一个进程可以包含多个线程。
  ///      线程也可以有自己的计算资源 。
  ///多线程：多个执行流同时运行
  ///       1 CUP分时间片--上下文切换（加载环境-计算-保存环境）
  ///         微观角度，一个核同一时刻只能执行一个线程，宏观上来说是多线程并发
  ///Thread 是C#对线程对象的封装
  ///
  /// 同步：是对方法执行的描述，完成计算后，再进入下一行
  ///     如：请张三吃饭，张三很忙，等着张三忙完，再一起吃饭
  /// 异步：不会等待计算的完成，直接进入下一行，非阻塞
  ///     如：张张三吃饭，张三很忙，我自己去吃饭，张三忙完，自己去吃饭。
  ///     
  /// 
  /// 同步方法慢：只有一个线程干活
  /// 异步方法快：因为多个线程并发干活。
  ///           线程不是越多越好： a 用大量的资源换取时间
  ///                           b来回切换上下文，增加管理成本。
  ///多线程使用条件：多个独立任务可以同时运行
  ///异步多线程无序：a 启动顺序无序 b 执行时间不确定 结束也无序 
  /// </summary>
  public partial class Form1 : Form
  {
    public Form1()
    {

      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void btnAnyncAdvanced_Click(object sender, EventArgs e)
    {
      Console.WriteLine($"btnAnyncAdvanced Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now}");

      Action<string> action = this.DoSomethingLong;
      action.BeginInvoke("btnAnyncAdvanced_Click", null, null);
      Console.WriteLine($"到这里计算已经完成了 {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

      Console.WriteLine($"btnAnyncAdvanced End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now}");
    }

    private void DoSomething()
    {
      Console.WriteLine();
    }

    private void DoSomethingLong(string str)
    {
      Console.WriteLine($"DoSomethingLong Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now}");
      long lResult = 0;
      for (int i = 0; i < 10000000; i++)
      {
        lResult += i;
      }
      Console.WriteLine($"DoSomethingLong End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now}");
    }
  }
}
