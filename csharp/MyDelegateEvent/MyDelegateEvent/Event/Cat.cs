using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent.Event
{
  /// <summary>
  /// 发布者
  /// 一只猫，miao一声，导致一系列的触发动作
  /// </summary>
  /// 


  //定义委托
  public delegate void MiaoDelegate();


  public class Cat
  {
    public void Miao()
    {
      Console.WriteLine("{0} Miao", this.GetType().Name);
    }
    //猫叫一声 触发一系列后续动作

    public MiaoDelegate MiaoDelegateHandler;

    //事件是带Event关键字的委托的实例,event可以限制变量被外部调用或直接赋值
    //委托和事件的区别与联系？
    //委托是类型，事件是委托类型的实例
    //事件：可以把一堆可变动作/行为封闭出去，交给第三方来指定。程序设计时候，我们可以把程序分成两部分，一部分是固定的，直接写死；还有不固定的地方，通过一个事件去开放接口，外部可以随意扩展。
    //框架：完成固定部分，把可变部分留出扩展，支持自定义
    public event MiaoDelegate MiaoDelegateHandlerEvent;

    public void MiaoNew()
    {
      Console.WriteLine("{0} MiaoNew", this.GetType().Name);
      if (this.MiaoDelegateHandler != null)
      {
        this.MiaoDelegateHandler.Invoke();
      }
    }

    public void MiaoNewEvent()
    {
      Console.WriteLine("{0} MiaoNewEvent", this.GetType().Name);
      if (this.MiaoDelegateHandlerEvent != null)
      {
        this.MiaoDelegateHandlerEvent.Invoke();
      }
    }

  }

  public class ChildClass:Cat
  {
    public void Show()
    {
      this.MiaoDelegateHandler += null;
      //this.MiaoDelegateHandlerEvent!=null;//子类也不能调用
    }
  }
}
