using MyOO.Interface;
using MyOO.Item;
using MyOO.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOO
{
  public class Player
  {
    public int Id { get; set; }
    public string Name { get; set; }

    #region 不使用父类方式
    public void UseIphone(Iphone phone)
    {
      phone.Call();
      phone.Text();
    }

    public void UseMi(Mi phone)
    {
      phone.Call();
      phone.Text();
    }

    public void UseLumia(Lumia phone)
    {
      phone.Call();
      phone.Text();
    }
    #endregion

    #region 使用父类方式
    /// <summary>
    /// 面向抽象编程，只能使用抽象里面共有的东西，如果有个性化需求，就不能用面向抽象方式
    /// </summary>
    /// <param name="phone"></param>
    public void UsePhone(BasePhone phone) //标签1
    {
      phone.Call();
      phone.Text();
      //phone.Game(); //Game是苹果手机专有的。
    }

    public void Use<T>(T phone) where T : BasePhone // 等价于标签1，二者是一样的
    {
      phone.Call();
      phone.Text();
    }


    #endregion

  }
}
