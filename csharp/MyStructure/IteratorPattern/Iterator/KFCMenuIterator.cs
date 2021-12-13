using IteratorPattern.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.Iterator
{
  public class KFCMenuIterator : IIterator<Food>
  {
    private Food[] _FoodList = null;
    private int _CurrentIndex = -1;


    public KFCMenuIterator(KFCMenu kFCMenu)
    {
      this._FoodList = kFCMenu.GetFood();
    }

    public Food Current { get { return this._FoodList[_CurrentIndex]; } }

    public bool MoveNext()
    {
      return this._FoodList.Length > ++this._CurrentIndex;
    }

    public void Reset()
    {
      this._CurrentIndex = -1;
    }
  }
}
