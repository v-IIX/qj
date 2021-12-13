using IteratorPattern.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern.Menu
{
  public class MacDonaldMenu
  {
    private List<Food> _FoodList = new List<Food>();

    public MacDonaldMenu()
    {
      this._FoodList.Add(new Food() { Id = 1, Name = "JiRouJuan", Price = 16 });
      this._FoodList.Add(new Food() { Id = 2, Name = "ZhaJi", Price = 8 });
      this._FoodList.Add(new Food() { Id = 3, Name = "HongShu", Price = 12 });
    }

    public List<Food> GetFood()
    {
      return _FoodList;
    }

    public IIterator<Food> GetIterator()
    {
      return new MacDonaldIterator(this);
    }
  }
}
