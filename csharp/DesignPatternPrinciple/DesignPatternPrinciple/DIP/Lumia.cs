using System;

namespace DesignPatternPrinciple.DIP
{
  internal class Lumia : AbstractPhone
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