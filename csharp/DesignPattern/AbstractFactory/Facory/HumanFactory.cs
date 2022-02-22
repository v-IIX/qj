using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Facory
{
  public class HumanFactory : AbstractFacory
  {
    public override IArmy CreateArmy()
    {
      throw new NotImplementedException();
    }

    public override IHero CreateHero()
    {
      throw new NotImplementedException();
    }

    public override IRace CreateRace()
    {
      throw new NotImplementedException();
    }

    public override IResource CreateResource()
    {
      throw new NotImplementedException();
    }
  }
}
