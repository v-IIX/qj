using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommonFramwork.AttributeExtend.Validate
{
  public class EmailAttribute : AbstractValidateAttribute
  {
    public override bool Validate(object value)
    {
      if (value == null)
      {
        return false;
      }
      else
      {
        Regex regex = new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        return regex.IsMatch(value.ToString());
      }

    }
  }
}
