using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFramwork.AttributeExtend
{
  [AttributeUsage(AttributeTargets.Property)]
  public class ColumnAttribute : Attribute
  {
    private string _name;
    public ColumnAttribute(string name)
    {
      this._name = name;
    }

    public string GetColumnName()
    {
      return this._name;
    }
  }
}
