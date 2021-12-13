using IteratorPattern.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.Menu
{
  public class KFCMenu
  {
    private Food[] _FoodList = new Food[3];

    public KFCMenu()
    {
      this._FoodList[0] = new Food() { Id = 1, Name = "HanBao", Price = 15 };
      this._FoodList[1] = new Food() { Id = 2, Name = "Kele", Price = 10 };
      this._FoodList[2] = new Food() { Id = 3, Name = "ShuTiao", Price = 8 };
    }

    public Food[] GetFood()
    {
      return _FoodList;
    }

    public IIterator<Food> GetIterator()
    {
      return new KFCMenuIterator(this);
    }
  }
}
