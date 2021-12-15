using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.LOD
{
  /// <summary>
  /// 迪米特法则（最少知道原则）：一个对象应该对其它对象保持最少的了解。
  ///   1 面向对象——类——类与类之间交互——功能模块——系统
  ///   2 高内聚，低耦合。类本身高度封闭，类与类之间减少依赖
  ///     耦合关系：继承、实现、依赖、关联、组合、聚合。。。
  /// </summary>
  public class LODShow
  {
    public static void Show()
    {
      School school = new School();
    }
  }
}
