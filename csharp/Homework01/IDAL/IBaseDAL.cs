using CommonFramwork;
using CommonFramwork.AttributeExtend;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
  public interface IBaseDAL
  {
    T Find<T>(int id) where T : BaseModel;

    List<T> FindALL<T>() where T : BaseModel;

    void UpdateAll<T>(T t) where T : BaseModel;

    void Insert<T>(List<T> items);
  }
}
