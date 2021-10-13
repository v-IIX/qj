using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommonFramwork.AttributeExtend.Validate
{
  public class MobileAttribute : AbstractValidateAttribute
  {
    public override bool Validate(object value)
    {
      if (value == null)
      {
        return false;
      }
      else
      {
        Regex regex = new Regex(@"^1[34589]\d{9}$");
        return regex.IsMatch(value.ToString());
      }

    }
  }
}
