using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent.CarDealerAndConsumer
{
  public class Consumer
  {
    private string _name;
    public Consumer(string name)
    {
      this._name = name;
    }

    public void IsCarHere(object sender, CarInfoEventArgs e)
    {
      Console.WriteLine($"Consumer: {_name} know car is here");
    }
  }
}
