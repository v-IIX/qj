using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo
{
  public class ActionFunc
  {
    public delegate void NoReturnNoParaDelegate();

    public void Show()
    {
      //Action 表示0到16参数的没有返回值的泛型委托
      Action action = () => { }; //无参数，无返回值的委托
      Action<int> action1 = (int i) => { };

      //Action 表示0到16参数的有返回值的泛型委托
      Func<int, string> func = (i) => i.ToString();

      this.DoNothing(action);

      NoReturnNoParaDelegate noReturnNoParaDelegate = () => { };

      //因为NoReturnNoParaDelegate和Action不是同一个类型
      //很多委托长得一样，参数列表及返回值都一样，但是不能通用。为了统一，就全部使用标准的Action、Func
      // this.DoNothing(noReturnNoParaDelegate); 

    }

    private void DoNothing(Action act)
    {
      act.Invoke();
    }
  }
}
