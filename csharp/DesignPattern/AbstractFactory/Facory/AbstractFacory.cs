using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Facory
{
  public abstract class AbstractFacory
  {
    public abstract IRace CreateRace();
    public abstract IArmy CreateArmy();
    public abstract IHero CreateHero();
    public abstract IResource CreateResource();
  }
}
