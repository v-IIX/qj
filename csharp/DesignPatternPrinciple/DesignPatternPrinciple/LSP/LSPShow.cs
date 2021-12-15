using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.LSP
{
  /// <summary>
  /// 继承：通过继承，子类拥有父类的一切属性和方法，任何父类出现的地方，都可以用子类来代替
  ///   1 如果父类有的东西，子类没有，那么应该断开继承关系
  ///   2 子类可以有父类没有的东西，所以子类出现的地方，不一定能用父类代替
  ///   3 透明指的是安全。父类的东西换成子类后不影响程序（建议父类已经实现的东西，子类不要用new来隐藏。想要改的话用virtual+override）
  ///    
  /// 
  /// 里氏替换原则：任何使用基类的地方，都可以透明的使用其子类。继承+不改变行为
  /// 继承、多态 
  /// </summary>
  public class LSPShow
  {
    internal static void Show()
    {
      Poly.Test();

      {
        Chinese people = new Chinese();
        people.Traditional();
        DoChinese(people);
      }

      {
        Chinese people = new HuBei();
        people.Traditional();
      }
    }

    private static void DoChinese(Chinese people)
    {
      throw new NotImplementedException();
    }
  }
}
