using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ulti;

namespace H02AOP
{
  public class LogHandler : ICallHandler
  {
    public int Order { get; set; }
    public string LogMessage { get; set; }

    public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
    {
      Log.log(LogMessage);
      return getNext().Invoke(input, getNext);
    }
  }
}
