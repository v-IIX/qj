using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFramwork.log
{
  public class SqlRunningTime
  {
    public static void SaveRunningTime(int count,string type,long time)
    {
      string[] str = new string[] { $"{DateTime.Now} : {count} {type} {time.ToString()}" };

      using (StreamWriter sw = new StreamWriter(@"d:\names.txt",true))
      {
        foreach (string s in str)
        {
          sw.WriteLine(s);
        }
      }
    }
  }
}
