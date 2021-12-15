using DesignPatternPrinciple.ISP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.DIP
{
  class Ipad : IExtend
  {
    public void Game()
    {
      Console.WriteLine($"{this.GetType().Name} Game");
    }

    public void Map()
    {
      Console.WriteLine($"{this.GetType().Name} Map");
    }

    public void Movie()
    {
      Console.WriteLine($"{this.GetType().Name} Movie");
    }

    public void Online()
    {
      Console.WriteLine($"{this.GetType().Name} Online");
    }

    public void Pay()
    {
      Console.WriteLine($"{this.GetType().Name} Pay");
    }

    public void Photo()
    {
      Console.WriteLine($"{this.GetType().Name} Photo");
    }

    public void Record()
    {
      Console.WriteLine($"{this.GetType().Name} Record");
    }
  }
}
