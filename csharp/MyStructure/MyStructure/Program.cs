using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStructure
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        //CollectionDemo.Show();


        {
          //yield
          YieldDemo yieldDemo = new YieldDemo();
          foreach (var item in yieldDemo.Power())
          {
            Console.WriteLine(item);
            if (item > 100) //要一个拿一个，按需获取
            {
              break;
            }
          }

          {
            //common
            foreach (var item in yieldDemo.Common())
            {
              Console.WriteLine(item);
              if (item > 100) //全部获取，然后一起返回
              {
                break;
              }
            }
          }
        }



      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      Console.ReadKey();
    }
  }
}
