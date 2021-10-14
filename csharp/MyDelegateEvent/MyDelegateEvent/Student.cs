using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent
{
  public class Student
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int ClassId { get; set; }
    public int Age { get; set; }

    public void Study()
    {
      Console.WriteLine($"{this.GetType().Name} Study");
    }

    public static void StudyAdvanced()
    {
      Console.WriteLine($"{typeof(Student).Name} StudyAdvanced");
    }

    public static void Show()
    {
      Console.WriteLine($"{typeof(Student).Name} Show");
    }
  }
}
