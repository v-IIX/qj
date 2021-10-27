using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.MappingExtend
{
  public class ReflectionMapper
  {
    public static R Trans<I, R>(I i)
    {
      R r = Activator.CreateInstance<R>();
      foreach (var rProp in typeof(R).GetProperties())
      {
        foreach (var iProp in typeof(I).GetProperties())
        {
          if (rProp.Name.Equals(iProp.Name))
          {
            rProp.SetValue(r, iProp.GetValue(i));
          }
        }
      }

      foreach (var rfield in typeof(R).GetFields())
      {
        foreach (var iField in typeof(I).GetFields())
        {
          if (rfield.Equals(iField))
          {
            rfield.SetValue(r, iField.GetValue(i));
          }
        }
      }

      return r;
    }
  }
}
