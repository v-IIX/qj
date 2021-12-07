using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constant
{
  public class Paths
  {
    public static string StoryRoleJsonPath = System.Configuration.ConfigurationManager.AppSettings["story_role_path"];
    public static string LogPath = System.Configuration.ConfigurationManager.AppSettings["log_path"];
  }
}
