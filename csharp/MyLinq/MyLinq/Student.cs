using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq
{
  public class Student
  {
    public int Id { get; set; }
    public String Name { get; set; }
    public int Age { get; set; }
    public int ClassId { get; set; }

    public void Study()
    {
      Console.WriteLine("{0} Study",this.GetType().Name);
    }

    public void StudyHard()
    {
      Console.WriteLine("{0} StudyHard", this.GetType().Name);
    }

    //public void Sing()
    //{
    //  Console.WriteLine("{0} Sing", this.GetType().Name);
    //}
  }
}
