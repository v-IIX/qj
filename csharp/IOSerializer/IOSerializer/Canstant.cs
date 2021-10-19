using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOSerializer
{
  public class Canstant
  {
    public static string LogPath = System.Configuration.ConfigurationManager.AppSettings["GetPath"];
    public static string LogMovePath = System.Configuration.ConfigurationManager.AppSettings["LogMovePath"];
    public static string SerializeDataPath = System.Configuration.ConfigurationManager.AppSettings["SerializeDataPath"];

  }
}
