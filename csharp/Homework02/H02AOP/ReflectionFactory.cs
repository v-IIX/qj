using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H02AOP
{
  public class ReflectionFactory<T>
  {
    public static T GetInstance()
    {
      Type type = typeof(T);
      T tObject = (T)Activator.CreateInstance(type);

      IConfigurationSource configurationSource = ConfigurationSourceFactory.Create();
      PolicyInjector policyInjector = new PolicyInjector(configurationSource);
      PolicyInjection.SetPolicyInjector(policyInjector);
      tObject = PolicyInjection.Create<T>();

      return tObject;
    }
  }
}
