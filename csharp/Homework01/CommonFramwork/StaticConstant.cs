using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFramwork
{
  public class StaticConstant
  {
    public static string SqlServerConnString = System.Configuration.ConfigurationManager.ConnectionStrings["libConn"].ConnectionString;
    public static string MysqlConnString = System.Configuration.ConfigurationManager.ConnectionStrings["libConn_mysql"].ConnectionString;
  }
}
