using H02Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace H02Factory
{
  public class SimpleFactory
  {
    public static T GetPerformer<T>() where T : AbstractVocalMinicry, ICharge
    {
      string fileName = Path.Combine(Environment.CurrentDirectory, "Config", "east_style_json.json");
      using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
      {
        using (StreamReader streamReader = new StreamReader(fileStream))
        {
          string jsonString = streamReader.ReadToEnd();
          //JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();//框架自带工具
          //T t = javaScriptSerializer.Deserialize<T>(jsonString);//框架自带工具
          T t = JsonConvert.DeserializeObject<T>(jsonString);//Newtonsoft
          return t;
        }
      }
    }
  }
}
