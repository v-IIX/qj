using CommonFramwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using CommonFramwork.log;
using System.Reflection;
using Ulti;
using IDAL;
using Factory;
using CommonFramwork.AttributeExtend;

namespace Project
{
  /// <summary>
  /// 1 UI层必须把异常catch住
  /// 2 底层了了问题，不要隐瞒，第一时间终止运行
  /// 3 除非某个异常无关紧要，后面的代码仍然需要继续运行，那么可以自己try catch，保留好日志，后续再做分析
  /// </summary>
  class Program
  {

    static void Main(string[] args)
    {
      try
      {
        Company company = new Company()
        {
          Name = "小稳",
          CreateId = 1,
          CreateTime = DateTime.Now,
          LastModifierId = 1,
          LastModifyTime = DateTime.Now
        };

        User user = new User()
        {
          Name = "马老师",
          Account = "user",
          Password = "e123",
          Email = "abcd@sina.com",
          Mobile = "134088",
          CompanyId = 1,
          CompanyName = "阿里巴巴",
          Status = 2,
          UserType = 2,
          LastLoginTime = DateTime.Now,
          CreateTime = DateTime.Now,
          CreateId = 1,
          LastModifierId = 1,
          LastModifyTime = DateTime.Now,
        };

        MockData mockData = new MockData();
        List<Company> data = (List<Company>)mockData.GetMockData<Company>(100);

        IBaseDAL baseDAL = DALFactory.CreateInstance();
        user=baseDAL.Find<User>(2);
        user.Name = "Jack Ma";
        baseDAL.UpdateAll(user);
        baseDAL.FindAll<User>();
        baseDAL.Insert(data);

        //Console.ReadKey();
      }
      catch (Exception ex)
      {
        throw;
      }
    }
  }
}
