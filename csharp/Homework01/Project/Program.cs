using CommonFramwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;
using CommonFramwork.log;

namespace Project
{
  class Program
  {

    static void Main(string[] args)
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

      try
      {
        BaseDAL baseDAL = new BaseDAL();
        //Company company = baseDAL.Find<Company>(10);
        //List<Company> listCompany = baseDAL.FindALL<Company>();
        //user = baseDAL.Find<User>(1);
        //user.Name = "腾讯";
        //baseDAL.UpdateAll<User>(user);
        //user = new User();
        //user.Name = "tencent";
        //user.Mobile = "136";
        baseDAL.Insert(user);
      }
      catch (Exception)
      {

        throw;
      }

      //Console.ReadKey();
    }
  }
}
