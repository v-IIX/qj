using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOO.Interface
{
  /// <summary>
  /// 接口没有任何具体实现，全部默认public，不能写访问修饰符
  /// </summary>
  public interface IExtend
  {
    //string Remark; 不能有字段
    //delegate void Action(); 不能有委托

    //String Description { get; set; }
    void Video();
    // event Action ActionHandler;
    //int this[int index] { get; }
  }
}
