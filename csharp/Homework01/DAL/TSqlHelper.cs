using CommonFramwork.AttributeExtend;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  /// <summary>
  /// 为sql语句做的泛型缓存
  /// </summary>
  public class TSqlHelper<T> where T : BaseModel
  {
    public static string FindSql = null;

    static TSqlHelper()
    {
      Type type = typeof(T);
      var props = type.GetProperties().Where(x => !x.Name.Equals("Id"));
      string columnString = string.Join(",", props.Select(x => $"[{AttributeHelper.GetColumnName(x)}] = @{AttributeHelper.GetColumnName(x)}"));
      FindSql = $"select * from [{type.Name}] where id=";
    }
  }
}
