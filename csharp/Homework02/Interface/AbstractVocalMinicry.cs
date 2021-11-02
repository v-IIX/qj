using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ulti;

namespace H02Interface
{
  public abstract class AbstractVocalMinicry : MarshalByRefObject
  {
    public event Action FireOnEvent;

    public string Man { get; set; }
    public string Chair { get; set; }
    public string Desk { get; set; }
    public string Fan { get; set; }
    public string Fuchi { get; set; }
    protected int temprature = 400;
    protected Func<int, bool> func = null;

    public void ProgramsBegin()
    {
      ConsoleWriteLineAndLog.ConsoleAndLog("Programs begin");
    }

    public abstract void WangWang();
    public abstract void HaHa();
    public abstract void HoHo();

    public virtual void OpenRemark()
    {
      ConsoleWriteLineAndLog.ConsoleAndLog("Programs is start");
    }

    public virtual void EndRemark()
    {
      ConsoleWriteLineAndLog.ConsoleAndLog("Programs is Over");
    }

    #region 套路1
    //注意此处处理方式:相同内容在父类中定义，不同内容由子类覆写
    public void UniqueSkill()
    {
      ConsoleWriteLineAndLog.ConsoleAndLog("UniqueSkill will begin");
      this.UniqueSkillCore();
      ConsoleWriteLineAndLog.ConsoleAndLog("UniqueSkill will end");
    }

    protected virtual void UniqueSkillCore()
    {
      Console.WriteLine("Default UniqueSkill");
    }
    #endregion

    #region 套路2
    //事件特点是谁申明谁才能调用，覆写时子类是不能是不能FireOnEvent?.Invoke()的

    #region 套路3
    //设置温度的方法
    //  1 使用虚方法
    //  2 使用字段或者属性方式保存设置温度值
    //  3 使用配置文件方式，将温度值写入配置文件
    //  4 使用判断委托方式
    #endregion

    public virtual void SetTemperature(int temprature)
    {
      //if (temprature >= this.temprature)
      if (func.Invoke(temprature)) //使用判断委托方式
      {
        this.FireOnEventInvoke();
      }
    }

    private void FireOnEventInvoke()
    {
      FireOnEvent.Invoke();
    }

    #endregion

  }
}
