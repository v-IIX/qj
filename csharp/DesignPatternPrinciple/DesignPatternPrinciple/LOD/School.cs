using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.LOD
{
  /// <summary>
  ///遵循迪米特法则： Scholl管理Class,Class管理Student
  ///违背遵循迪米特法则：Class管理Student
  /// 
  /// Class 以属性、字段、参数的形式出现在School里面，属于类与类交互的必要依赖
  /// Student 直接出现在方法内部，与School属于间接依赖，应该减少此类依赖 
  /// </summary>
  public class School
  {
    public int Id { get; set; }
    public string ShoolName { get; set; }
    public List<Class> ClassList { get; set; }

    public void Manage()
    {
      Console.WriteLine($"Manage {this.GetType().Name}");
      foreach (var item in this.ClassList)
      {
        Console.WriteLine($"{item.GetType().Name} Manage {item.ClassName}");
        item.Manage();
      }
    }
  }
}
