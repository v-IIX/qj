using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.ISP
{
  /// <summary>
  /// 接口隔离原则：客户端不应该依赖它不需要的接口；一个类对别一个类的依赖应该建立在最小的接口上；实现一个接口时，只需要自己必须的功能。
  /// 
  ///实现接口，就必须把接口里面的全部方法都实现。
  ///
  /// 大接口应该拆分成小而精准的接口，但也不能过度设计，最终变成了一个接口只有一个方法。
  /// </summary>
  public class ISPShow
  {
    public static void Show()
    {
    }
  }
}
