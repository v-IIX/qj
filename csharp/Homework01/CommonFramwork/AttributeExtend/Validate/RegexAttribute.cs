using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CommonFramwork.AttributeExtend.Validate
{
  public class RegexAttribute : AbstractValidateAttribute
  {
    private string _regexExpression = string.Empty;

    public RegexAttribute(string regex)
    {
      this._regexExpression = regex;
    }

    public override bool Validate(object value)
    {
      if (value == null)
      {
        return false;
      }
      else
      {
        return Regex.IsMatch(value.ToString(), _regexExpression);
      }
    }
  }
}
