using H02AOP;
using H02Interface;
using System;
using Ulti;

namespace Performer
{
  public class EastStyle : AbstractVocalMinicry, ICharge
  {
    public EastStyle()
    {
      //base.temprature = 800;
      base.func = (i) => i >= 800;
    }
    private string UniqueSkillName = $"{typeof(EastStyle).Name} SeaVoice";

    public int Levle { get; set; }

    protected override void UniqueSkillCore()
    {
      ConsoleWriteLineAndLog.ConsoleAndLog($"{this.GetType().Name} UniqueSkill use by {UniqueSkillName} output {Levle}");
    }

    public override void SetTemperature(int temprature)
    {
      base.SetTemperature(temprature);
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
