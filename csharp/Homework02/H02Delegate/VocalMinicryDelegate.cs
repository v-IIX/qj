using Performer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H02Delegate
{
  public class VocalMinicryDelegate
  {
    public event Action actionEvent = null;

    public Action GetactionEvent()
    {
      return actionEvent;
    }
  }
}
