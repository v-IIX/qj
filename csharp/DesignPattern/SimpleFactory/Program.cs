using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactory
{
  /// <summary>
  /// 简单工厂
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        Player player = new Player()
        {
          Id = 123,
          Name = "viix"
        }; 
      }
      catch (Exception)
      {

        throw;
      }
    }
  }
}
