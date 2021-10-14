using MyOO.Interface;
using MyOO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOO
{
  /// <summary>
  /// 1 面向对象Object Oriented
  /// 2 封装继承多态
  /// 3 重写overwrite(new) 覆写override 重载overload
  /// 4 抽象类接口
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        #region 玩手机游戏 面向过程

        //Console.WriteLine("有一个手机");
        //Console.WriteLine("开机。。。");
        //Console.WriteLine("联网");
        //Console.WriteLine("启动游戏");
        //Console.WriteLine("一顿操作");
        //Console.WriteLine("结束游戏");

        #endregion

        //面向对象
        //封装：数据安全、内部修改保持稳定，分工合作、职责分明、方便构建大型复杂系统
        //继承：去掉重复代码、可以实现多态。但是建立了侵入性很强的类关系
        //抽象：
        //多态：相同的变量、操作，但是有不同的实现
        //    1、方法的重载
        //    2、接口+实现
        //    3、抽象类+实现
        //    4、继承

        Player player = new Player();


        #region 运行时多态
        {
          BasePhone phone = new Iphone();
          phone.Call();
          phone.System();
          //phone.Vedio(); 运行时多态，在编译时编译器认为变量是BasePhone，里面没有Video方法，但运行时（new Iphone()）实际是有的。
          dynamic dPhone = phone; //避开编译器的检查
          dPhone.Video();
        }

        {
          BasePhone phone = new Lumia();
          phone.Call();
          phone.System();
        }

        {
          Iphone extend = new Iphone();
          extend.Video();
        }
        #endregion

        //接口：纯粹的约束；多继承更灵活 。can do 
        //抽象类：父类 + 约束；可以完成通用实现；单继承。 is a 
        //虽然可能没有共同实现，也可以使用抽象类，用来表示“是什么”。
        //子类必须有而且都一样的，放在父类，子类必须有但又不一样的，放在父类且抽象一下，有的有有的没有的，放在接口。
        //实际工作中，接口用的多，因为接口简单灵活，除非有些共有的需要继承
        // 什么时候用静态方法？什么时候用普通方法？
        //能用普通方法就用普通方法，除非这个方法确定没有什么扩展，只是工具类方法。

      }
      catch (Exception)
      {

        throw;
      }
      Console.Read();
    }
  }
}
