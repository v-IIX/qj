using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.DIP
{
  public class Honor : AbstractPhone
  {
    internal override void Call()
    {
      Console.WriteLine($"{this.GetType().Name} Call");
    }

    internal override void Text()
    {
      Console.WriteLine($"{this.GetType().Name} Text");
    }
  }
}
