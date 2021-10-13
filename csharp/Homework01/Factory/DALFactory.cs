﻿using CommonFramwork;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
  public class DALFactory
  {
    static DALFactory()
    {
      Assembly assembly = Assembly.Load(StaticConstant.DALDllName);
      DALType = assembly.GetType(StaticConstant.DALTypeName);
    } 

    private static Type DALType = null;
    public static IBaseDAL CreateInstance()
    {
      return (IBaseDAL)Activator.CreateInstance(DALType);
    }
  }
}
