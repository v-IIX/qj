using MyOO.Interface;
using MyOO.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOO.Service
{
  public class Iphone:BasePhone,IExtend
  {
    public override void System()
    {
      Console.WriteLine($"{this.GetType().Name} System is IOS");
    }

    public void Game(Game game)
    {
      game.Start();
      game.Play();
    }

    public void Video()
    {
      Console.WriteLine($"{this.GetType().Name} Video");
    }
  }
}
