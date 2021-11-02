using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H02AOP
{
  public class LogAttribute : HandlerAttribute
  {
    public string LogMessage { get; set; }

    public override ICallHandler CreateHandler(IUnityContainer container)
    {
      LogHandler logHandler = new LogHandler();
      logHandler.LogMessage = this.LogMessage;
      return logHandler;
    }
  }
}
