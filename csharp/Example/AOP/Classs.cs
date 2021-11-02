using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP
{
  public class User
  {
    public string Name { get; set; }
    public string Password { get; set; }
  }

  #region 定义特性
  public class LogHandlerAttribute : HandlerAttribute
  {
    public string LogInfo { get; set; }

    public override ICallHandler CreateHandler(IUnityContainer container)
    {
      LogHandler logHandler = new LogHandler();
      logHandler.LogInfo = this.LogInfo;

      return logHandler;
    }
  }
  #endregion


  public class LogHandler : ICallHandler
  {
    public string LogInfo { set; get; }
    public int Order { get; set; }

    public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
    {
      Console.WriteLine($"LogInfo内容 " + LogInfo);

      //Console.WriteLine("方法执行前拦截到了");
      var messageReturn = getNext()(input, getNext);
      //Console.WriteLine("方法执行后拦截到了");
      return messageReturn;
    }
  }


  public interface IUserOperation
  {
    void Test(User user);
    void Test2(User user, User user2);
  }

  public class UserOperation : MarshalByRefObject, IUserOperation
  {
    [LogHandlerAttribute(LogInfo = "执行Name属性时的日志")]
    public string Name { set; get; }

    [LogHandlerAttribute(LogInfo = "执行Test方法时的日志")]
    public void Test(User user)
    {
      Console.WriteLine($"Test 方法执行了");
    }

    [LogHandlerAttribute(LogInfo = "执行Test2方法时的日志")]
    public void Test2(User user, User user2)
    {
      Console.WriteLine($"Test2 方法执行了");
    }

  }

  public class UserOperationFactory
  {
    public static UserOperation GetInstance()
    {
      UserOperation userOperation = new UserOperation();

      IConfigurationSource configurationSource = ConfigurationSourceFactory.Create();
      PolicyInjector policyInjector = new PolicyInjector(configurationSource);
      PolicyInjection.SetPolicyInjector(policyInjector);

      userOperation = PolicyInjection.Create<UserOperation>();
      return userOperation;
    }

  }
}
