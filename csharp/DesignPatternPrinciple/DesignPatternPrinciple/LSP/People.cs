using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.LSP
{
  public class People
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public void Traditional()
    {
      Console.WriteLine($"仁义礼智信，温良恭俭让");
    }
  }


  public class Chinese : People
  {
    public string Kuaizi { get; set; }

    public void SayHi()
    {
      Console.WriteLine($"早上好，吃了吗？");
    }
  }


  public class HuBei : Chinese
  {
    public string MaJiang { get; set; }

    public new void SayHi()
    {
      Console.WriteLine($"早上好，过早了吗？");
    }
  }


  public class Japanese//:People
  {
    public int Id { get; set; }
  }

}
