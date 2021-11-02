using H02Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ulti
{
  public class Log
  {
    public static void log(string logStr)
    {
      if (!Directory.Exists(Constant.LogPath))
      {
        Directory.CreateDirectory(Constant.LogPath);
      }

      logStr = $"{DateTime.Now.ToString()} : {logStr}";
      string file = Path.Combine(Constant.LogPath, "homework02.log");
      using (FileStream fileStream = new FileStream(file, FileMode.Append, FileAccess.Write))
      {
        using (StreamWriter streamWriter = new StreamWriter(fileStream))
        {
          streamWriter.WriteLine(logStr);
          streamWriter.Flush();
        }
      }
    }
  }
}
