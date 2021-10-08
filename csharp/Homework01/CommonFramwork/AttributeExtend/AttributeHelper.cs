using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonFramwork.AttributeExtend
{
  public class AttributeHelper
  {
    public static string GetColumnName(PropertyInfo prop)
    {

      if (prop.IsDefined(typeof(ColumnAttribute), true))
      {
        ColumnAttribute attribute = (ColumnAttribute)prop.GetCustomAttribute(typeof(ColumnAttribute), true);
        return attribute.GetColumnName();
      }
      return prop.Name;

    }
  }
}
