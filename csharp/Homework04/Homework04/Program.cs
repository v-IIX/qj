using Constant;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ulti;

namespace Homework04
{
  class Program
  {
    private readonly static object IsFirstDoneTagLock = new object();

    static void Main(string[] args)
    {
      bool isMonitorGoOn = true;

      try
      {
        List<StoryRole> storyRoles = JsonHelper.JsonToObj();

        bool isFirstDoneTag = false; //标志谁先完成第一件事

        TaskFactory taskFactory = new TaskFactory();
        List<Task> tasks = new List<Task>();

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        #region 监控线程

        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        Task.Run(() =>
        {
          int randomNumber = 0;
          int year = DateTime.Now.Year;

          while (randomNumber != year && isMonitorGoOn)
          {
            #region Random Seed
            int seed = 0;
            Guid guid = Guid.NewGuid();
            foreach (var item in guid.ToString().ToCharArray())
            {
              seed = seed + (int)item;
            }
            #endregion

            randomNumber = new Random(seed).Next(2015, 2022);
            Thread.Sleep(500);
          }
          if (isMonitorGoOn)
          {
            ConsoleAndLog.ConsoleLog($"天降雷霆灭世，天龙八部的故事到此结束。。。。", ConsoleColor.White);
            cancellationTokenSource.Cancel();
            isMonitorGoOn = false;
          }

        });

        #endregion

        foreach (var role in storyRoles)
        {
          tasks.Add(taskFactory.StartNew((x) =>
          {
            for (int i = 0; i < role.Experience.Count; i++)
            {
              if (cancellationTokenSource.IsCancellationRequested)
              {
                isMonitorGoOn = false;
                break;
              }

              if (i == 0)
              {
                if (!isFirstDoneTag)
                {
                  lock (IsFirstDoneTagLock)
                  {
                    if (!isFirstDoneTag)
                    {
                      ConsoleAndLog.ConsoleLog($"{role.Experience[i]}", role.Color);
                      ConsoleAndLog.ConsoleLog($"天龙八部就此拉开序幕。。。", role.Color);
                      isFirstDoneTag = true;
                    }
                    else
                    {
                      ConsoleAndLog.ConsoleLog($"{role.Experience[i]}", role.Color);
                    }
                  }
                }
                else
                {
                  ConsoleAndLog.ConsoleLog($"{role.Experience[i]}", role.Color);
                }
              }
              else
              {
                ConsoleAndLog.ConsoleLog($"{role.Experience[i]}", role.Color);
              }
            }
          }, role.Name, cancellationTokenSource.Token));
        }

        tasks.Add(taskFactory.ContinueWhenAny(tasks.ToArray(), (x) =>
        {
          if (cancellationTokenSource.IsCancellationRequested)
          {
            isMonitorGoOn = false;
            return;
          }
          ConsoleAndLog.ConsoleLog($"{x.AsyncState} 已经做好准备。。。", ConsoleColor.White);
        }));

        tasks.Add(taskFactory.ContinueWhenAll(tasks.ToArray(), (x) =>
        {
          if (cancellationTokenSource.IsCancellationRequested)
          {
            isMonitorGoOn = false;
            return;
          }
          ConsoleAndLog.ConsoleLog($"中原群雄大战辽兵，忠义两难一死谢天。。。", ConsoleColor.White);
        }));
        //Task.WhenAll(rolesTasks.ToArray()).ContinueWith((x) => Console.WriteLine($"中原群雄大战辽兵，忠义两难一死谢天。。。"));

        Task.WaitAll(tasks.ToArray());
        stopwatch.Stop();
        if (!cancellationTokenSource.IsCancellationRequested)
        {
          ConsoleAndLog.ConsoleLog($"整个天龙八部故事花费了 {stopwatch.ElapsedMilliseconds} ms", ConsoleColor.White);
        }
        else
        {
          isMonitorGoOn = false;
        }

      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      finally
      {
        isMonitorGoOn = false;
      }

      Console.ReadKey();
    }
  }
}
