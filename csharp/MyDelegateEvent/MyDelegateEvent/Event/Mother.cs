﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent.Event
{
  public class Mother
  {
    public void Wispher()
    {
      Console.WriteLine($"{this.GetType().Name} wispher");
    }
  }
}
