using H02Interface;
using System;
using Ulti;

namespace Performer
{
  public class NorthStyle : AbstractVocalMinicry, ICharge
  {
    private string UniqueSkillName = $"{typeof(NorthStyle).Name} SnowVoice";

    public int Levle { get; set; }

    public override void HaHa()
    {
      throw new NotImplementedException();
    }

    public override void HoHo()
    {
      throw new NotImplementedException();
    }

    public void TakeMoney()
    {
      throw new NotImplementedException();
    }

    protected override void UniqueSkillCore()
    {
      ConsoleWriteLineAndLog.ConsoleAndLog($"{this.GetType().Name} UniqueSkill use by {UniqueSkillName} output {Levle}");
    }

    public override void WangWang()
    {
      throw new NotImplementedException();
    }

    public override void EndRemark()
    {
      ConsoleWriteLineAndLog.ConsoleAndLog($"{this.GetType().Name} EndRemark");
    }

  }
}
