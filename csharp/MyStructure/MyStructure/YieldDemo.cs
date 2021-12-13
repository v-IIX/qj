using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyStructure
{
  public class YieldDemo
  {

    private int Get(int num)
    {
      Thread.Sleep(1000);
      return num * DateTime.Now.Second;
    }

    public IEnumerable<int> Power()
    {
      for (int i = 0; i < 10; i++)
      {
        yield return this.Get(i);
      }
    }

    public IEnumerable<int> Common()
    {
      List<int> intList = new List<int>();
      for (int i = 0; i < 10; i++)
      {
        intList.Add(this.Get(i));
      }
      return intList;
    }
  }
}
