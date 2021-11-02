using MyDelegateEvent.CarDealerAndConsumer;
using MyDelegateEvent.DelegateExtend;
using MyDelegateEvent.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        {
          //MyDelegate myDelegate = new MyDelegate();
          //myDelegate.Show();
        }

        ListExtend listExtend = new ListExtend();
        listExtend.Show();

        {
          Cat cat = new Cat();
          cat.Miao();
        }

        {
          Cat cat = new Cat();
          cat.MiaoDelegateHandler = new MiaoDelegate(new Mother().Wispher);
          cat.MiaoDelegateHandler += new Dog().Wang;
          cat.MiaoNew();
        }

        {
          Cat cat = new Cat();
          cat.MiaoDelegateHandlerEvent += new MiaoDelegate(new Mother().Wispher);
          //cat.MiaoDelegateHandlerEvent = null;//不能赋值也不能调用
          cat.MiaoDelegateHandlerEvent += new Dog().Wang;
          cat.MiaoNewEvent();
        }

      }
      catch (Exception)
      {

        throw;
      }

      #region CarDealerAndConsumer
      {
        CarDealer carDealer = new CarDealer();

        Consumer Valtteri = new Consumer("Valtteri");
        carDealer.events += Valtteri.IsCarHere;
        Consumer Max = new Consumer("Max");
        carDealer.events += Max.IsCarHere;
        carDealer.eventInvoke("Mercedes");

      }
      #endregion

      Console.ReadKey();
    }
  }
}
