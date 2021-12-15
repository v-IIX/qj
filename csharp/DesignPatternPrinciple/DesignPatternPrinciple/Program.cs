using DesignPatternPrinciple.LSP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple
{
  class Program
  {
    /// <summary>
    /// 设计模式：面向对象语言开发过程中，遇到各种场景和问题，总结出的解决方案和思路，就是设计模式。解决问题的套路。
    /// 
    /// 推荐的一此指导性原则
    ///   1 单一职责原则（Single Reponsibility Principle）
    ///   2 里氏替换原则（Liskov Substitution Priciple）
    ///   3 依赖倒置原则（Dependence Inversion Principle）
    ///   4 接口隔离原则（Interface Segregation Principle）
    ///   5 迪米特法则（Law Of Demeter）
    ///   6 开闭原则（Open Closed Principle）
    /// 
    /// 设计模式六大原则是开发过程中的一些推荐性原则，并非强制要求。
    /// 
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
      try
      {
        {
          //SRPShow.Show();

          LSPShow.Show();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
