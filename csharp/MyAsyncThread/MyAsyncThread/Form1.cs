using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
  ///     如：请张三吃饭，张三很忙，我自己去吃饭，张三忙完，自己去吃饭。
  ///     
  /// 
  /// 同步方法慢：只有一个线程干活
  /// 异步方法快：因为多个线程并发干活。
  ///           线程不是越多越好： a 用大量的资源换取时间
  ///                           b 来回切换上下文，增加管理成本。
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

    #region btnAnyncAdvanced_Click

    private void btnAnyncAdvanced_Click(object sender, EventArgs e)
    {
      Console.WriteLine($"btnAnyncAdvanced Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now}");

      IAsyncResult asyncResult = null;

      Action<string> action = this.DoSomethingLong;
      AsyncCallback asyncCallback = (ia) =>
      {
        Console.WriteLine(object.ReferenceEquals(ia, asyncResult));
        Console.WriteLine(ia.AsyncState);
        Console.WriteLine($"到这里计算已经完成了 {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
      };
      asyncResult = action.BeginInvoke("btnAnyncAdvanced_Click", asyncCallback, "testParama");

      int i = 0;
      while (!asyncResult.IsCompleted) //判断异步是否完成
      {
        Thread.Sleep(200);
        if (i < 10)
        {
          Console.WriteLine($"文件上传完成{i++ * 10}%");
        }
        else
        {
          Console.WriteLine($"文件上传完成99.9%");
        }
        Console.WriteLine($"上传成功了");
      }

      asyncResult.AsyncWaitHandle.WaitOne();//等待任务完成
      asyncResult.AsyncWaitHandle.WaitOne(1000);//等待，但是最多等待1000ms
      action.EndInvoke(asyncResult);//等待,且可以获取返回值

      #region EndInvoke获取返回值
      {
        Func<int> func = () =>
        {
          Thread.Sleep(2000);
          return DateTime.Now.Day;
        };

        Console.WriteLine($"func.Invoke()= {func.Invoke()}");

        IAsyncResult asyncResult2 = func.BeginInvoke(cb =>
        {
          Console.WriteLine(cb.AsyncState);
        }, "testParama");

        Console.WriteLine($"func.EndInvoke(asyncResult2)= {func.EndInvoke(asyncResult2)}");
      }
      #endregion


      Console.WriteLine($"btnAnyncAdvanced End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now}");
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
    #endregion

    #region btnThreads_Click
    /// <summary>
    /// 最初版本实现多线程Threads
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnThreads_Click(object sender, EventArgs e)
    {
      Console.WriteLine($"btnThreads Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now}");
      ThreadStart threadStart = () => this.DoSomethingLong("btnThreads_Click");
      Thread thread = new Thread(threadStart);
      thread.Start();
      //thread.Suspend(); //线程挂起，不建议使用
      //thread.Resume();  //唤醒线程，不建议使用

      //try
      //{
      //  //thread.Abort(); //销毁线程，以抛出异常的方式销毁，不建议使用。不一定及时，有些动作发出就收不回来
      //}
      //catch (Exception)
      //{
      //  Thread.ResetAbort();  //取消Abort异常
      //}

      #region 线程等待

      thread.Join();  //当前线程等待thread完成
      thread.Join(500);  //当前线程等待thread完成，最多等待500ms

      while (thread.ThreadState != System.Threading.ThreadState.Stopped)
      {
        Thread.Sleep(100);  //当前线程休息100ms
      }
      #endregion

      //Console.WriteLine(thread.IsBackground); //默认是前台线程，启动之后一定要等任务完成，阻止线程退出
      //thread.IsBackground = true; //指定为后台线程
      Console.WriteLine($"btnThreads End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now}");

      //thread.Priority = ThreadPriority.Highest; //指定线程优先级，CPU会优先执行Highest

      Action action = () => { Console.WriteLine($"action"); };
      Action callback = () => { Console.WriteLine($"callback"); };
      this.ThreadWithCallback(action, callback);
      this.ThreadPoolWithCallback(action, callback);

      Func<int> result = this.ThreadWithReturn<int>(() => { return DateTime.Now.Millisecond; });
      Console.WriteLine(result.Invoke());
    }

    /// <summary>
    /// Thread版本：不带返回值的异步调用
    /// </summary>
    /// <param name="act"></param>
    /// <param name="callback"></param>
    private void ThreadWithCallback(Action act, Action callback)
    {
      Thread thread = new Thread(() =>
      {
        act.Invoke();
        callback.Invoke();
      });
      thread.Start();
    }

    /// <summary>
    /// ThreadPool版本：不带返回值的异步调用
    /// </summary>
    /// <param name="act"></param>
    /// <param name="callback"></param>
    private void ThreadPoolWithCallback(Action act, Action callback)
    {
      ThreadPool.QueueUserWorkItem((x) =>
      {
        act.Invoke();
        callback.Invoke();
      });
    }

    /// <summary>
    /// Thread版本：     带返回值的异步调用 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="func"></param>
    /// <returns></returns>
    private Func<T> ThreadWithReturn<T>(Func<T> func)
    {
      T t = default(T);
      Thread thread = new Thread(() =>
      {
        t = func.Invoke();
      });
      thread.Start();

      thread.Join(); //等待
      return () =>
      {
        //等待
        //while (thread.ThreadState != ThreadState.Stopped)
        //{
        //  Thread.Sleep(200);
        //}
        return t;
      };
    }

    #endregion

    #region btnThreadPool_Click

    /// <summary>
    /// Thread 包含太多API，功能太强大，不可控，使用困难（就像给3岁小孩一把刀）
    /// 1 对线程的使用加以限制
    /// 2 重用线程，避免重复创建和销毁
    /// 3 线程池、享元模式、数据连接池
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnThreadPool_Click(object sender, EventArgs e)
    {
      Console.WriteLine($"btnThreadPool Start");
      ThreadPool.QueueUserWorkItem(x => this.DoSomethingLong("btnThreadPool"));

      //获取Max
      {
        ThreadPool.GetMaxThreads(out int worderThreads, out int completionPortThreads);
        Console.WriteLine($"worderThreads={worderThreads},completionPortThreads={completionPortThreads}");
      }

      //获取Min
      {
        ThreadPool.GetMinThreads(out int worderThreads, out int completionPortThreads);
        Console.WriteLine($"worderThreads={worderThreads},completionPortThreads={completionPortThreads}");
      }

      //设置
      {
        ThreadPool.SetMaxThreads(16, 16); //全局设置
        ThreadPool.SetMinThreads(8, 8); //全局设置
      }

      //获取
      {
        ThreadPool.GetMinThreads(out int worderThreads, out int completionPortThreads);
        Console.WriteLine($"worderThreads={worderThreads},completionPortThreads={completionPortThreads}");
      }

      //线程等待
      {
        //ManualResetEvent类，包含一个bool属性
        //false:WaitOne进入等待，可以用Set设置其为true，然后 WaitOne 直接过去
        //true:WaitOne 直接过去，可以用Reset设置其为false，然后WaitOne进入等待
        ManualResetEvent manualResetEvent = new ManualResetEvent(false);
        ThreadPool.QueueUserWorkItem(x =>
        {
          this.DoSomethingLong("btnThreadPool");
          manualResetEvent.Set();
        });
        manualResetEvent.WaitOne();

        //死锁
        //一般不要阻塞线程池的线程，非要阻塞的话，记得使用set解除阻塞
        manualResetEvent.Reset();
        for (int i = 0; i < 13; i++)
        {
          int k = i;
          ThreadPool.QueueUserWorkItem(x =>
          {
            Console.WriteLine($"befor:{k}");
            if (k < 11)
            {
              manualResetEvent.WaitOne(); //设置为false，上面设置了Max为16，因此最多有16个线程
              Console.WriteLine($"behind:{k}");
            }
            else
            {
              manualResetEvent.Set();
            }
          });

        }

        if (manualResetEvent.WaitOne())
        {
          Console.WriteLine($"表示没有死锁");
        }

        Console.WriteLine($"btnThreadPool End");
      }
    }

    #endregion

    #region btnTask_Click

    /// <summary>
    /// Task 基于ThreadPool 。Threads太多API，ThreadPool太少API，Task又增加一些API
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnTask_Click(object sender, EventArgs e)
    {
      Console.WriteLine($"btnTask_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now}");


      //Task.Delay(1000); //延迟
      //Thread.Sleep(1000); //等待

      //Thread.Sleep(1000); //等待
      {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Thread.Sleep(1000);
        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedMilliseconds);
      }

      //Task.Delay(1000); //延迟
      {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Task.Delay(1000).ContinueWith(x =>
        {
          stopwatch.Stop();
          Console.WriteLine(stopwatch.ElapsedMilliseconds);
        });
      }

      //Task.Run(() => { this.DoSomethingLong($"btnTask_Click"); });  //启动多线程 
      //TaskFactory taskFactory = Task.Factory;
      //taskFactory.StartNew(() => { this.DoSomethingLong($"btnTask_Click"); });  //启动多线程 
      //new Task(() => { this.DoSomethingLong($"btnTask_Click"); }).Start();  //启动多线程 

      //控制线程数量：用11个线程完成10000个任务
      //{
      //  List<int> list = new List<int>();
      //  for (int i = 0; i < 10000; i++)
      //  {
      //    list.Add(i);
      //  }

      //  Action<int> action = i =>
      //  {
      //    Console.WriteLine($"{ Thread.CurrentThread.ManagedThreadId.ToString("00")}");
      //    Thread.Sleep(new Random().Next(100, 300));
      //  };

      //  List<Task> taskList = new List<Task>();
      //  foreach (var i in list)
      //  {
      //    int k = i;
      //    taskList.Add(Task.Run(() => action.Invoke(k)));
      //    if (taskList.Count > 10)
      //    {
      //      Task.WaitAny(taskList.ToArray());
      //      taskList = taskList.Where(x => x.Status != TaskStatus.RanToCompletion).ToList();
      //    }
      //  }
      //  Task.WhenAll(taskList.ToArray());
      //}


      List<Task> tasks = new List<Task>();
      Console.WriteLine($"项目经理启动一个项目 {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
      Console.WriteLine($"前置的准备工作 {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
      Console.WriteLine($"开始编程 {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

      tasks.Add(Task.Run(() => this.Coding("爱书客", "Client")));
      tasks.Add(Task.Run(() => this.Coding("Alex", "Service")));
      tasks.Add(Task.Run(() => this.Coding("Jack", "Portal")));
      tasks.Add(Task.Run(() => this.Coding("Tony", "Monitor")));


      //等待但不会卡界面
      {
        Task.WhenAny(tasks.ToArray()).ContinueWith(x =>
        {
          Console.WriteLine($"某人最先完成，得意的笑 {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
        });
        Task.WhenAll(tasks.ToArray()).ContinueWith(x =>
        {
          Console.WriteLine($"部署环境，联调测试 {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
        });
      }


      ////等待且会卡界面
      //{
      //  //一个业务查询操作多个数据源，多线程并发--拿到全部数据后才能返回(WaitAll)
      //  //商品搜索查询操作多个数据源，多线程并发--只需要拿到一个结果就能返回(WaitAny)
      //  //WaitAny和WaitAll都会阻塞
      //  Task.WaitAny(tasks.ToArray()); ////会阻塞当前线程,等待某个任务完成后，就会进入下一行（谁运行这代码，阻塞谁）
      //  Console.WriteLine($"第一个完成任务 {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

      //  //Task.WaitAll(tasks.ToArray()); //会阻塞当前线程,等待全部任务完成后，才进入下一行（谁运行这代码，阻塞谁）
      //  Task.WaitAll(tasks.ToArray(), 1000); //等待1s      
      //  Console.WriteLine($"告诉甲方验收，上线使用 {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
      //}


      Console.WriteLine($"btnTask_Click End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now}");

      //Task回调
      {
        Task.Run(() => this.Coding("xxx", "yyy")).ContinueWith(x => { Console.WriteLine("回调"); });
      }
    }

    private void Coding(string name, string type)
    {
      Console.WriteLine($"Coding {name} Start {type} {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now}");

      Console.WriteLine($"Coding {name} End {type} {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now}");
    }

    #endregion


    #region btnParallel_Click

    /// <summary>
    /// 并行编程 在Task的基础上做了封装，自带WaitAll
    /// Parallel 会卡界面，主线程参与计算，节约了一个线程
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnParallel_Click(object sender, EventArgs e)
    {
      Console.WriteLine($"btnParallel_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now}");

      //启动方式1
      {
        Parallel.Invoke(
          () => this.Coding("爱书客", "Client"),
          () => this.Coding("Alex", "Service"),
          () => this.Coding("Jack", "Portal"),
          () => this.Coding("Tony", "Monitor")
          );
      }

      //启动方式2，for循环
      {
        ParallelOptions parallelOptions = new ParallelOptions(); //设置使用的线程数量
        Parallel.For(0, 5, i => this.Coding("Jack", "Portal"));
        //Parallel.For(0, 5,parallelOptions, i => this.Coding("Jack", "Portal")); //设置使用的线程数量
      }

      //启动方式2，forEach循环
      {
        ParallelOptions parallelOptions = new ParallelOptions(); //设置使用的线程数量
        parallelOptions.MaxDegreeOfParallelism = 3;

        Parallel.ForEach(new string[] { "0", "1", "2", "3" }, i => this.Coding("Jack", "Portal"));
        // Parallel.ForEach(new string[] { "0", "1", "2", "3" }, parallelOptions, i => this.Coding("Jack", "Portal"));//设置使用的线程数量
      }



      Console.WriteLine($"btnParallel_Click End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now}");
    }

    #endregion

    #region btnThreadCore_Click

    private static readonly object btnThreadCore_Click_Lock = new object(); //lock的内容 77微软推荐写法
    private int TotalCount = 0;
    private List<int> IntList = new List<int>();

    /// <summary>
    /// 线程里面的异常是抓不到的，因为主线程已经结束了，脱离了catch范围。加入WaitALL才能抓住。
    /// 建议：线程里面的action不允许出现异常，自己处理好（在action上加一层try catch）。
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnThreadCore_Click(object sender, EventArgs e)
    {
      Console.WriteLine($"btnThreadCore_Click Start {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now}");

      try
      {
        TaskFactory taskFactory = new TaskFactory();
        List<Task> taskList = new List<Task>();
        //#region 异常处理
        //{
        //  for (int i = 0; i < 20; i++)
        //  {
        //    string name = string.Format($"btnThreadCore_Click_{i}");
        //    Action<object> action = t =>
        //    {
        //      try
        //      {
        //        Thread.Sleep(200);
        //        if (t.ToString().Equals($"btnThreadCore_Click_11"))
        //        {
        //          throw new Exception(string.Format($"{t} 执行失败"));
        //        }
        //        if (t.ToString().Equals($"btnThreadCore_Click_12"))
        //        {
        //          throw new Exception(string.Format($"{t} 执行失败"));
        //        }
        //        Console.WriteLine($"{t} 执行成功");
        //      }
        //      catch (Exception ex)
        //      {
        //        Console.WriteLine($"Exception: {ex.Message}");
        //      }
        //    };
        //    taskList.Add(taskFactory.StartNew(action, name));
        //  }

        //  //加入Task.WaitAll就能抓住异常，但是会卡界面
        //  //Task.WaitAll(taskList.ToArray());
        //}
        //#endregion

        //#region 线程取消
        ////多个线程并发，某个线程失败后，希望通知其它线程都停下来。
        ////task是外部无法终止的
        ////线程自己停止自己--公共访问变量--修改它--线程不断检测它
        ////CancellationTokenSource:
        ////  1 用CancellationTokenSource去标记任务是否取消
        ////  2 Cancel表示取消
        ////  3 IsCancellationRequested表示是否已取消
        ////  4 Token: 假如在启动Task时候传入Token，那么当执行Cancel后，这个任务会放弃启动（Token是一个外部变量，Cancel操作会改变Token的状态）
        //{
        //  CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        //  for (int i = 0; i < 40; i++)
        //  {
        //    string name = string.Format($"btnThreadCore_Click_{i}");
        //    Action<object> action = t =>
        //    {
        //      try
        //      {

        //        Thread.Sleep(200);
        //        if (t.ToString().Equals($"btnThreadCore_Click_11"))
        //        {
        //          throw new Exception(string.Format($"{t} 执行失败"));
        //        }
        //        if (t.ToString().Equals($"btnThreadCore_Click_12"))
        //        {
        //          throw new Exception(string.Format($"{t} 执行失败"));
        //        }
        //        if (cancellationTokenSource.IsCancellationRequested)  //检查信息号量
        //        {
        //          Console.WriteLine("{0} 放弃执行");
        //          return; //方法里面的return，表示结束方法
        //        }
        //        else
        //        {
        //          Console.WriteLine($"{t} 执行成功");
        //        }
        //      }
        //      catch (Exception ex)
        //      {
        //        cancellationTokenSource.Cancel();
        //        Console.WriteLine($"Exception {ex.Message}");
        //      }
        //    };
        //    taskList.Add(taskFactory.StartNew(action, name, cancellationTokenSource.Token));
        //  }
        //  Task.WaitAll(taskList.ToArray());
        //}
        //#endregion

        //#region 多线程临时变量

        ////for (int i = 0; i < 5; i++)
        ////{
        ////  Task.Run(() =>
        ////   {
        ////     Thread.Sleep(100);
        ////     Console.WriteLine(i);
        ////   });
        ////}

        ////整个for循环只有一个i，但是有5个k
        ////sleep(100)的时候（不用Sleep也行，因为启动异步很快，但是开始执行确需要时间），for已经结束了i变成了5。
        //for (int i = 0; i < 5; i++)
        //{
        //  int k = i;
        //  new Action(() =>
        //  {
        //    Thread.Sleep(100);
        //    Console.WriteLine($"k={k} i= {i}");
        //  }).BeginInvoke(null, null);
        //}

        //{
        //  int k;
        //  for (int i = 0; i < 5; i++)
        //  {
        //    k = i;
        //    new Action(() =>
        //    {
        //      Thread.Sleep(100);
        //      Console.WriteLine($"k={k} i= {i}");
        //    }).BeginInvoke(null, null);
        //  }
        //}

        //#endregion

        #region 线程安全 lock
        //共有变量：都能访问/全局变量/数据库的一个值/硬盘文件。多疑线程同时访问会出现脏读（a是公共变量，初值为0。线程1访问a，执行a=a+1，同时线程2也访问a的，也执行a=a+1，最终a可能不为2）
        //线程内部不共享的是安全

        //private static readonly object btnParallel_Click_Lock = new object() 分析：
        //  1 private 防止外面 也去lock
        //  2 static 全局唯一，多个实例但只有一个变量
        //  3 readonly 表示不要改动
        //  4 object 表示引用
        //

        for (int i = 0; i < 1000; i++)
        {
          taskList.Add(taskFactory.StartNew(() =>
          {
            int k = 3 + 2;

            //锁lock:
            //  1 只能锁引用类型，占用引用的链接
            //  2 不要用string，因为享元

            #region 加锁方式1
              ////str和str2指向同一块内存
              ////lock(str)和lock(str2)是同一个锁
              //{
              //  string str = "string";
              //  string str2 = "string";
              //  lock (str) { }
              //  lock (str2) { }
              //}

              //lock后的方法块，任意时刻只有一个线程可以进入，但是没有了并发，牺牲性能。
              //又想并发，又想不冲突：数据拆分
              lock (btnThreadCore_Click_Lock)
              {
                //这里就是单线程
                this.TotalCount += 1;
                IntList.Add(k);
              }

            #endregion

            #region 加锁方式2，方式1是方式2的缩写

            //{
            //  Monitor.Enter(btnThreadCore_Click_Lock);
            //代码块
            //  Monitor.Exit(btnThreadCore_Click_Lock);
            //}

            #endregion
          }));
        }

        Task.WaitAll(taskList.ToArray());
        Console.WriteLine(this.TotalCount);
        Console.WriteLine(IntList.Count);

        #endregion
      }
      catch (AggregateException ex)
      {
        foreach (var item in ex.InnerExceptions)
        {
          Console.WriteLine(item.Message);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }

      Console.WriteLine($"btnThreadCore_Click End {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now}");

    }

    #endregion
  }
}
