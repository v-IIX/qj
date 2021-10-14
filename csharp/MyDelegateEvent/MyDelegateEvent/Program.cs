using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        {
          MyDelegate myDelegate = new MyDelegate();
          myDelegate.Show();
        }
      }
      catch (Exception)
      {

        throw;
      }

      Console.Read();
    }
  }
}
