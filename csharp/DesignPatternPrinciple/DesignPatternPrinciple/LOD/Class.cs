using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.LOD
{
  public class Class
  {
    public int Id { get; set; }
    public object ClassName { get; internal set; }
    public List<Student> StudentList { get; set; }

    internal void Manage()
    {
      foreach (var item in this.StudentList)
      {
        Console.WriteLine($"{this.GetType().Name}  Manage {item.StudentName}");
      }
    }
  }
}
