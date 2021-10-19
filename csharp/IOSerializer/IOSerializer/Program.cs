using IOSerializer.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOSerializer
{
  public class Program
  {
    static void Main(string[] args)
    {
      try
      {
        //MyIO.Show();
        Console.WriteLine(Recurision.GetAllDirectory(@"C:\Users\entme\source").Count());          
      }
      catch (Exception)
      {

        throw;
      }
      Console.ReadKey();
    }
  }
}
