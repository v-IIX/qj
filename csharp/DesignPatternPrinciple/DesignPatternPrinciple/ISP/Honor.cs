using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.ISP
{
  public class Honor : AbstractPhone, IExtend, IExtendAdvanced
  {
    public override void Call()
    {
      Console.WriteLine($"{this.GetType().Name} Call");
    }

    public override void Text()
    {
      Console.WriteLine($"{this.GetType().Name} Text");
    }

    public void Photo()
    {
      Console.WriteLine($"{this.GetType().Name} Photo");
    }

    public void Online()
    {
      Console.WriteLine($"{this.GetType().Name} Online");
    }

    public void Game()
    {
      Console.WriteLine($"{this.GetType().Name} Game");
    }

    public void Record()
    {
      Console.WriteLine($"{this.GetType().Name} Record");
    }

    public void Movie()
    {
      Console.WriteLine($"{this.GetType().Name} Movie");
    }

    public void Map()
    {
      Console.WriteLine($"{this.GetType().Name} Map");
    }

    public void Pay()
    {
      Console.WriteLine($"{this.GetType().Name} Pay");
    }
  }
}
