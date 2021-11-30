using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AwaiAsyncLibrary
{
  /// <summary>
  /// 任何一个方法都可以增加async
  /// await放在task前面。async和await一般成对出现，只有async是没有意义的，只有await会报错
  /// </summary>
  public class AwaitAsyncClass
  {
    public static void TestShow()
    {
      Test();
    }

    /// <summary>
    /// 没有返回值
    /// </summary>
    /// <returns></returns>
    private async static Task Test()
    {
      Console.WriteLine($"Test Start ThreadId = {Thread.CurrentThread.ManagedThreadId}");
      {
        //NoReturnNoAwait();
      }

      {
        NoReturnTask();
        for (int i = 0; i < 10; i++)
        {
          Thread.Sleep(30);
          Console.WriteLine($"Main Thread Task ManagedThreadId = {Thread.CurrentThread.ManagedThreadId}");
        }
      }

      //{
      //  Task t = NoReturnTask();
      //Console.WriteLine($"Main Thread Task ManagedThreadId={Thread.CurrentThread.ManagedThreadId}");
      //  t.Wait();//主线程等待Task的完成
      //  await t;//await后的代码会由线程池的线程执行
      //}

      {
        //Task<long> t = SumAsync();
        //Console.WriteLine($"Main Thread Task ManagedThreadId={Thread.CurrentThread.ManagedThreadId}");
        //long result = t.Result; //主线程等待Task的完成，并访问result
        //t.Wait(); //主线程等待Task的完成
      }

      {
        //Task<int> t = SumFactory();
        //Console.WriteLine($"Main Thread Task ManagedThreadId={Thread.CurrentThread.ManagedThreadId}");
        //long result = t.Result; //没有await和async的普通task
        //t.Wait();
      }

      Console.WriteLine($"Test End ThreadId = {Thread.CurrentThread.ManagedThreadId}");
    }

    private static Task<int> SumFactory()
    {
      Console.WriteLine($"SumFactory Start ManagedThreadId={Thread.CurrentThread.ManagedThreadId}");
      TaskFactory taskFactory = new TaskFactory();
      Task<int> result = taskFactory.StartNew<int>(() =>
      {
        Thread.Sleep(1000);
        Console.WriteLine($"taskFactory ManagedThreadId={Thread.CurrentThread.ManagedThreadId}");
        return 123;
      });
      Console.WriteLine($"SumFactory End ManagedThreadId={Thread.CurrentThread.ManagedThreadId}");
      return result;
    }


    /// <summary>
    /// 不推荐在await/async方法中返回void，使用Task代替
    /// </summary>
    private static async void NoReturn()
    {
      Console.WriteLine($"NoReturn Sleep Before Await,ThreadId={Thread.CurrentThread.ManagedThreadId}"); //主线程执行

      TaskFactory taskFactory = new TaskFactory();
      Task task = taskFactory.StartNew(() =>
      {
        Console.WriteLine($"NoReturn Sleep Before,ThreadId={Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(3000);
        Console.WriteLine($"NoReturn Sleep After,ThreadId={Thread.CurrentThread.ManagedThreadId}");
      });
      await task; //主线程到这里就返回了，执行主线程任务
      //耗时任务就用await
      // await task 后面的代码如（Console.WriteLine($"NoReturn Sleep After Await,ThreadId={Thread.CurrentThread.ManagedThreadId}")）相当于是task执行过后的回调，等价于：
      // task.ContinueWith((x)=>{Console.WriteLine($"NoReturn Sleep After Await,ThreadId={Thread.CurrentThread.ManagedThreadId}");})

      Console.WriteLine($"NoReturn Sleep After Await,ThreadId={Thread.CurrentThread.ManagedThreadId}"); //可能是主线程、子线程也可能是其它线程执行

    }

    /// <summary>
    /// 返回Task，调用的代码也可以继续await
    /// </summary>
    /// <returns></returns>
    private static async Task NoReturnTask()
    {
      Console.WriteLine($"NoReturnTask Sleep Before Await,ThreadId = {Thread.CurrentThread.ManagedThreadId}"); //主线程执行

      TaskFactory taskFactory = new TaskFactory();
      Task task = taskFactory.StartNew(() =>
      {
        Console.WriteLine($"NoReturnTask Sleep Before,ThreadId = {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(300);
        Console.WriteLine($"NoReturnTask Sleep After,ThreadId = {Thread.CurrentThread.ManagedThreadId}");
      });
      await task; //主线程到这里就返回了，执行主线程任务
      //耗时任务就用await
      // await task 后面的代码如（Console.WriteLine($"NoReturn Sleep After Await,ThreadId={Thread.CurrentThread.ManagedThreadId}")）相当于是task执行过后的回调，等价于：
      // task.ContinueWith((x)=>{Console.WriteLine($"NoReturn Sleep After Await,ThreadId={Thread.CurrentThread.ManagedThreadId}");})

      Console.WriteLine($"NoReturnTask Sleep After Await,ThreadId = {Thread.CurrentThread.ManagedThreadId}"); //可能是主线程、子线程也可能是其它线程执行

    }


    private static async void NoReturnNoAwait()
    {
      Console.WriteLine($"NoReturnNoAwait Sleep Before Task,ThreadId={Thread.CurrentThread.ManagedThreadId}"); //主线程执行
      Task task = Task.Run(() =>
      {
        Console.WriteLine($"NoReturnNoAwait Sleep Before,ThreadId={Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(300);
        Console.WriteLine($"NoReturnNoAwait Sleep After,ThreadId={Thread.CurrentThread.ManagedThreadId}");
      });
      Console.WriteLine($"NoReturnNoAwait Sleep After Task,ThreadId={Thread.CurrentThread.ManagedThreadId}"); //主线程执行
    }

    /// <summary>
    /// async 只返回long的result
    /// </summary>
    /// <returns></returns>
    private static async Task<long> SumAsync()
    {
      Console.WriteLine($"SumAsync Begin,ThreadId={Thread.CurrentThread.ManagedThreadId}");
      long result = 0;

      await Task.Run(() =>
      {
        for (int k = 0; k < 10; k++)
        {
          Console.WriteLine($"k= {k},ThreadId={Thread.CurrentThread.ManagedThreadId}");
          Thread.Sleep(1000);
        }

        for (long i = 0; i < 1000000000; i++)
        {
          result += i;
        }
      });

      Console.WriteLine($"SumAsync End,ThreadId={Thread.CurrentThread.ManagedThreadId}");
      return result;

    }
  }
}
