using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.DIP
{
  /// <summary>
  /// 依赖倒置原则：上层模块不应该依赖于低层模块，二者应该通过抽象依赖（面向抽象编程）
  /// 
  /// 抽象：抽象类、接口（抽象是稳定的）
  /// 细节：具体类（细节是多变的）
  ///   
  /// 23种设计模式，80%与这个模式有关 
  /// 
  /// 建议：
  ///   面向抽象 编程过程中，底层模块里面尽量都有抽象类、接口（细节类应该有父级抽象类、接口）。
  /// </summary>
  public class DIPShow
  {
    public static void Show()
    {
      Student student = new Student()
      {
        Id = 19,
        Name = "viix"
      };

      {
        //依赖细节，不合理
        IPhone iPhone = new IPhone();
        student.PlayIPhone(iPhone);

        Lumia lumia = new Lumia();
        student.PlayLumia(lumia);
      }

      {
        //依赖抽象,推荐
        Honor honor = new Honor();
        student.PlayPhone(honor);
      }

    }
  }
}
