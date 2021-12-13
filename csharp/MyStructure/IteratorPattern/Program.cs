using IteratorPattern.Iterator;
using IteratorPattern.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorPattern
{
  /// <summary>
  /// 1 迭代器模式Iterator
  /// 2 .net里面的迭代器模式yield return
  /// 3 解密linq to object的延迟加载查询，按需获取
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      try
      {

        {
          //kfc
          KFCMenu kFCMenu = new KFCMenu();
          Food[] foodCollection = kFCMenu.GetFood();

          for (int i = 0; i < foodCollection.Length; i++)
          {
            Console.WriteLine($"Id={0},Name={1},Price={2}", foodCollection[i].Id, foodCollection[i].Name, foodCollection[i].Price);
          }

          foreach (var item in foodCollection)
          {
            Console.WriteLine($"Id={0},Name={1},Price={2}", item.Id, item.Name, item.Price);
          }

          //自定义实现类似foreach功能
          IIterator<Food> kFCIterator = kFCMenu.GetIterator();
          while (kFCIterator.MoveNext())
          {
            Food food = kFCIterator .Current;
            Console.WriteLine($"Id={0},Name={1},Price={2}", food.Id, food.Name, food.Price);
          }

        }

        {
          //macdonal
          MacDonaldMenu macDonaldMenu = new MacDonaldMenu();
          List<Food> foodCollection = macDonaldMenu.GetFood();

          for (int i = 0; i < foodCollection.Count; i++)
          {
            Console.WriteLine($"Id={0},Name={1},Price={2}", foodCollection[i].Id, foodCollection[i].Name, foodCollection[i].Price);
          }

          foreach (var item in foodCollection)
          {
            Console.WriteLine($"Id={0},Name={1},Price={2}", item.Id, item.Name, item.Price);
          }

          //自定义实现类似foreach功能
          IIterator<Food> macDonaldIterator = macDonaldMenu.GetIterator();
          while (macDonaldIterator.MoveNext())
          {
            Food food = macDonaldIterator.Current;
            Console.WriteLine($"Id={0},Name={1},Price={2}", food.Id, food.Name, food.Price);
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
