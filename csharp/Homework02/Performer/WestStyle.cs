using H02Interface;
using System;
using Ulti;

namespace Performer
{
  public class WestStyle : AbstractVocalMinicry, ICharge
  {
    private string UniqueSkillName = $"{typeof(WestStyle).Name} WindVoice";

    public int Levle { get; set; }

    protected override void UniqueSkillCore()
    {
      ConsoleWriteLineAndLog.ConsoleAndLog($"{this.GetType().Name} UniqueSkill use by {UniqueSkillName} output {Levle}");
    }

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

    public override void WangWang()
    {
      throw new NotImplementedException();
    }
  }
}
