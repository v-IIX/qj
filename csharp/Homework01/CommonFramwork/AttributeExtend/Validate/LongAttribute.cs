using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonFramwork.AttributeExtend.Validate
{
  public class LongAttribute : AbstractValidateAttribute
  {
    private long _Min = 0;
    private long _Max = 0;

    public LongAttribute(long min, long max)
    {
      this._Min = min;
      this._Max = max;
    }

    public override bool Validate(object value)
    {
      if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
      {
        if (long.TryParse(value.ToString(), out long result))
        {
          if (result > this._Min && result < this._Max)
          {
            return true;
          }
        }
      }
      return false;
    }
  }
}
