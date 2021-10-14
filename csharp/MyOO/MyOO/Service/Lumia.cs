using MyOO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOO.Service
{
  public class Lumia : BasePhone,IExtend
  {
    public override void System()
    {
      Console.WriteLine($"{this.GetType().Name} System is WinPhon");
    }

    public void Video()
    {
      Console.WriteLine($"{this.GetType().Name} Video");
    }
  }
}
