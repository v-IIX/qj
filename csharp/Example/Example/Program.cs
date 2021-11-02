using AOP;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
  class Program
  {
    static void Main(string[] args)
    {
      //AOP
      {
        var user = new User() { Name = "test1111", Password = "yxj" };
        var user2 = new User() { Name = "test2222", Password = "yxj" };

        UserOperation userOperation = new UserOperation();
        userOperation = UserOperationFactory.GetInstance();

        userOperation.Test(user);
        Console.WriteLine(userOperation.Name);
      }

      Console.ReadKey();
    }
  }
}
