using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinq
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        {
          LambdaShow lambdaShow = new LambdaShow();
          lambdaShow.Show();

          LinqShow linqShow = new LinqShow();
          linqShow.Show();
          
        }

        #region 匿名类
        //普通类
        //{
        //  Student student = new Student()
        //  {
        //    Id = 1,
        //    Name = "Linq",
        //    Age = 22,
        //    ClassId = 2
        //  };
        //}

        ////匿名类
        //{
        //  object model = new
        //  {
        //    Id = 1,
        //    Name = "Linq",
        //    Age = 22,
        //    ClassId = 2
        //  };

        //  //Console.WriteLine(model.Id); //编译器不允许
        //  //利用反射获取 
        //  Type type = model.GetType();
        //  Console.WriteLine(type.GetProperty("Id").GetValue(model));

        //  var varModel = new
        //  {
        //    Id = 1,
        //    Name = "Linq",
        //    Age = 22,
        //    ClassId = 2
        //  };
        //  Console.WriteLine(varModel.Id);

        //  dynamic dModel = new
        //  {
        //    Id = 1,
        //    Name = "Linq",
        //    Age = 22,
        //    ClassId = 2
        //  };
        //  Console.WriteLine(dModel.Id); //dynamic可以避开编译器检查 
        //}
        #endregion

        #region 扩展方法
        //{
        //  Student student = new Student()
        //  {
        //    Id = 1,
        //    Name = "Linq",
        //    Age = 22,
        //    ClassId = 2
        //  };
        //  student.Study();
        //  //使用扩展方法访问Sing
        //  //又要增加方法，又不能（不想）更改类
        //  student.Sing();//等价于 ExtendMethod.Sing(student)
        //}

        #endregion

      }
      catch (Exception)
      {

        throw;
      }
    }
  }
}
