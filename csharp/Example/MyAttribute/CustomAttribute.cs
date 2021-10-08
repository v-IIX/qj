using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
  class CustomAttribute : Attribute
  {
    public CustomAttribute() { }

    public CustomAttribute(int id) { }

    public string Description { get; set; }

    public string Remark = null;

    public void Show()
    {
      Console.WriteLine($"this is {nameof(CustomAttribute)}");
    }
  }
}
