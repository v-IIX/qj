using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent.CarDealerAndConsumer
{
  public class CarDealer
  {
    public event EventHandler<CarInfoEventArgs> events;

    public void eventInvoke(string car)
    {
      Console.WriteLine($"CarDealer: new car {car} is here");
      events?.Invoke(this, new CarInfoEventArgs());
    }
  }
}
