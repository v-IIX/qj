using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.SRP
{
  /// <summary>
  /// 一个类只负责一件事。  /// 
  /// 
  /// 单一职责原则：类T负责两个不同的职责：职责P1和职责P2。但是职责P1需求发生有可能会导致原本运行正常的职责P2功能出现故障。  ///   
  /// </summary>
  public class SRPShow
  {
    public static void Show()
    {
      #region 违背单一原则
      //应该使用抽象类或接口进行相应分离
      {
        Animal animal = new Animal("鸡");
        animal.Breath();
        animal.Action();
      }

      {
        Animal animal = new Animal("鱼");
        animal.Breath();
        animal.Action();
      }
      #endregion
    }
  }
}
