using CommonFramwork.AttributeExtend.Validate;
using Model;
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


    public static bool Validate<T>(T t) where T:BaseModel
    {
      Type type = t.GetType();
      PropertyInfo[] props = type.GetProperties();
      foreach (var prop in props)
      {
        if (prop.IsDefined(typeof(AbstractValidateAttribute), true))
        {
          AbstractValidateAttribute[] attributes = (AbstractValidateAttribute[])prop.GetCustomAttributes(typeof(AbstractValidateAttribute), true);
          foreach (var attribute in attributes)
          {
            return attribute.Validate(prop.GetValue(t));
          }
        }
      }
      return false;
    }
  }
}
