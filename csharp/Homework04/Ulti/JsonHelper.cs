using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Model;
using Newtonsoft.Json;
using Constant;

namespace Ulti
{
  public class JsonHelper
  {
    public static List<StoryRole> JsonToObj()
    {
      string fileName = Path.Combine(Paths.StoryRoleJsonPath, "story_role.json");
      using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
      {
        using (StreamReader streamReader = new StreamReader(fileStream, Encoding.Default))
        {
          string jsonString = streamReader.ReadToEnd();
          List<StoryRole> storyRoles = JsonConvert.DeserializeObject<List<StoryRole>>(jsonString);

          return storyRoles;
        }
      }
    }
  }
}
