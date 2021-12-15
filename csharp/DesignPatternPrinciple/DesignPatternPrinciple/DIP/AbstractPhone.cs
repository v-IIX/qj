using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.DIP
{
  public abstract class AbstractPhone
  {
    public int Id { get; set; }
    public string Branch { get; set; }
    internal abstract void Call();
    internal abstract void Text();
  }
}
