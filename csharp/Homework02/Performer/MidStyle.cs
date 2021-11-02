using H02Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ulti;

namespace Performer
{
  public class MidStyle : AbstractVocalMinicry, ICharge
  {
    public event Action ProgramsOnEvent;
    public event Action HightJoyEvent;
    public event Action ProgramsEndEvent;

    private string UniqueSkillName = $"{typeof(MidStyle).Name} ChuanChuanVoice";

    public int Levle { get; set; }

    //封装框架
    //核心不变的内容写成固定
    //自定义的、可变的扩展部分做成事件开放出去，供用户提供逻辑

    public void MiddleShow()
    {
      base.ProgramsBegin();
      base.OpenRemark();
      this.ProgramsEndEvent?.Invoke();
      this.HaHa();
      this.HoHo();
      this.HightJoyEvent?.Invoke();
      this.WangWang();
      this.ProgramsEndEvent.Invoke();
      base.EndRemark();
      this.TakeMoney();

    }

    protected override void UniqueSkillCore()
    {
      ConsoleWriteLineAndLog.ConsoleAndLog($"{this.GetType().Name} UniqueSkill use by {UniqueSkillName} output {Levle}");
    }

    public override void HaHa()
    {
      ConsoleWriteLineAndLog.ConsoleAndLog($"{this.GetType().Name} HaHa");
    }

    public override void HoHo()
    {
      ConsoleWriteLineAndLog.ConsoleAndLog($"{this.GetType().Name} HoHo");
    }

    public void TakeMoney()
    {
      ConsoleWriteLineAndLog.ConsoleAndLog($"{this.GetType().Name} TakeMoney");
    }

    public override void WangWang()
    {
      ConsoleWriteLineAndLog.ConsoleAndLog($"{this.GetType().Name} WangWang");
    }

    public override void OpenRemark()
    {
      ConsoleWriteLineAndLog.ConsoleAndLog($"{this.GetType().Name} OpenRemark");
    }

    public override void EndRemark()
    {
      ConsoleWriteLineAndLog.ConsoleAndLog($"{this.GetType().Name} EndRemark");
    }
  }
}
