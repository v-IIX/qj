using H02Common;
using H02Interface;
using System;
using System.Reflection;

namespace H02Factory
{
  /// <summary>
  /// 使用反射方式配置工厂
  /// </summary>
  public class PerformerFactory
  {
    public static T GetPerformer<T>() where T : AbstractVocalMinicry, ICharge
    {
      Type tType = typeof(T);
      string typeName = tType.Name;

      Assembly assembly = null;
      Type type = null;

      if (typeName.Equals("EastStyle"))
      {
        assembly = Assembly.Load(Constant.EastStyleDll);
        type = assembly.GetType(Constant.EastStyleType);
      }
      else if (typeName.Equals("WestStyle"))
      {
        assembly = Assembly.Load(Constant.WestStyleDll);
        type = assembly.GetType(Constant.WestStyleType);
      }
      else if (typeName.Equals("SouthStyle"))
      {
        assembly = Assembly.Load(Constant.SouthStyleDll);
        type = assembly.GetType(Constant.SouthStyleType);
      }
      else
      {
        assembly = Assembly.Load(Constant.NorthStyleDll);
        type = assembly.GetType(Constant.NorthStyleType);
      }

      T obj = (T)Activator.CreateInstance(type);
      return obj;
    }
  }
}
