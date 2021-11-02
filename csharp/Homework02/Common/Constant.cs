using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H02Common
{
  public class Constant
  {
    private static string EastStyleDllType = System.Configuration.ConfigurationManager.AppSettings["east"];
    private static string WestStyleDllType = System.Configuration.ConfigurationManager.AppSettings["west"];
    private static string SouthStyleDllType = System.Configuration.ConfigurationManager.AppSettings["south"];
    private static string NorthStyleDllType = System.Configuration.ConfigurationManager.AppSettings["north"];

    public static string EastStyleDll = EastStyleDllType.Split(new char[] { ',' })[0];
    public static string EastStyleType = EastStyleDllType.Split(new char[] { ',' })[1];
    public static string WestStyleDll = WestStyleDllType.Split(new char[] { ',' })[0];
    public static string WestStyleType = WestStyleDllType.Split(new char[] { ',' })[1];
    public static string SouthStyleDll = SouthStyleDllType.Split(new char[] { ',' })[0];
    public static string SouthStyleType = SouthStyleDllType.Split(new char[] { ',' })[1];
    public static string NorthStyleDll = NorthStyleDllType.Split(new char[] { ',' })[0];
    public static string NorthStyleType = NorthStyleDllType.Split(new char[] { ',' })[1];

    public static string LogPath = System.Configuration.ConfigurationManager.AppSettings["log_path"];
  }
}
