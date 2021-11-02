using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulti
{
  public class ConsoleWriteLineAndLog
  {
    public static void ConsoleAndLog(string message)
    {
      Console.WriteLine(message);
      Log.log(message);
    }
  }
}
