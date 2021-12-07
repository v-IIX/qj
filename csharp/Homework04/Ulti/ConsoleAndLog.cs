using Constant;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ulti
{
  public class ConsoleAndLog
  {
    private static string fileName = null;
    private static readonly object ConsoleLock = new object();
    private static readonly object LogLock = new object();

    static ConsoleAndLog()
    {
      fileName = Path.Combine(Paths.LogPath, "log.txt");
      if (!File.Exists(fileName))
      {
        File.Create(fileName);
      }
    }

    public static void ConsoleLog(string logString, ConsoleColor color)
    {
      lock (ConsoleLock)
      {
        Console.ForegroundColor = color;
        foreach (var item in logString.ToCharArray())
        {
          Console.Write($"{item}");
          Thread.Sleep(30);
        }
        Console.WriteLine("");
      }


      lock (LogLock)
      {
        using (FileStream fileStream = new FileStream(fileName, FileMode.Append, FileAccess.Write))
        {
          using (StreamWriter streamWriter = new StreamWriter(fileStream))
          {
            streamWriter.WriteLine(logString);
          }
        }
      }
    }

  }
}
