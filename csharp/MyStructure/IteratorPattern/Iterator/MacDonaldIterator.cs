using IteratorPattern.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.Iterator
{
  public class MacDonaldIterator : IIterator<Food>
  {
    private List<Food> _FoodList = null;
    private int _CurrentIndex = -1;

    public MacDonaldIterator(MacDonaldMenu macDonaldMenu)
    {
      this._FoodList = macDonaldMenu.GetFood();
    }

    public Food Current { get { return _FoodList[_CurrentIndex]; } }

    public bool MoveNext()
    {
      return this._FoodList.Count > ++_CurrentIndex;
    }

    public void Reset()
    {
      _CurrentIndex = -1;
    }
  }
}
