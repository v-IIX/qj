using CommonFramwork;
using CommonFramwork.AttributeExtend;
using CommonFramwork.log;
using IDAL;
using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public class BaseDAL : IBaseDAL
  {
    /// <summary>
    /// 约束是为了正确的调用，才能int id
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="id"></param>
    public T Find<T>(int id) where T : BaseModel
    {
      Type type = typeof(T);
      T t = (T)Activator.CreateInstance(type);

      string queryString = $"{TSqlHelper<T>.FindSql}{id}";

      using (SqlConnection conn = new SqlConnection(StaticConstant.SqlServerConnString))
      {
        SqlCommand comm = new SqlCommand(queryString, conn);
        conn.Open();
        SqlDataReader reader = comm.ExecuteReader();
        t = this.ReaderToList<T>(reader).FirstOrDefault();
      }
      return t;
    }


    public List<T> FindALL<T>() where T : BaseModel
    {
      Type type = typeof(T);
      List<T> list = new List<T>();

      string columnString = string.Join(",", type.GetProperties().Select(p => $"[{AttributeHelper.GetColumnName(p)}]"));
      string sql = $"select {columnString} from {type.Name}";

      using (SqlConnection conn = new SqlConnection(StaticConstant.SqlServerConnString))
      {
        SqlCommand comm = new SqlCommand(sql, conn);
        conn.Open();
        SqlDataReader reader = comm.ExecuteReader();
        list = this.ReaderToList<T>(reader);
      }
      return list;

    }

    #region ReaderToList
    List<T> ReaderToList<T>(SqlDataReader reader)
    {
      Type type = typeof(T);
      List<T> list = new List<T>();
      while (reader.Read())
      {
        T t = (T)Activator.CreateInstance(type);
        foreach (var prop in type.GetProperties())
        {
          prop.SetValue(t, reader[AttributeHelper.GetColumnName(prop)] is DBNull ? null : reader[AttributeHelper.GetColumnName(prop)]);
        }
        list.Add(t);
      }
      return list;
    }
    #endregion


    public void UpdateAll<T>(T t) where T : BaseModel
    {
      if (!AttributeHelper.Validate<T>(t)) {
        throw new Exception("数据不正确");
      }

      Type type = typeof(T);
      var props = type.GetProperties().Where(x => !x.Name.Equals("Id"));
      string columnString = string.Join(",", props.Select(x => $"[{AttributeHelper.GetColumnName(x)}] = @{AttributeHelper.GetColumnName(x)}"));
      string queryString = $"update [{type.Name}] set {columnString} where id = {t.Id}";
      SqlParameter[] sqlParameters = props.Select(x => new SqlParameter($"@{AttributeHelper.GetColumnName(x)}", x.GetValue(t) ?? DBNull.Value)).ToArray(); //向数据库中的字段赋值null时，不能直接=null，而是要使用DBNUll.Value

      using (SqlConnection conn = new SqlConnection(StaticConstant.SqlServerConnString))
      {
        SqlCommand comm = new SqlCommand(queryString, conn);
        conn.Open();
        comm.Parameters.AddRange(sqlParameters);
        int result = comm.ExecuteNonQuery();
        if (result == 0)
        {
          throw new Exception("没有可更新的数据");
        }
      }
    }


    public void Insert<T>(List<T> items)
    {
      int runningCount;
      Type type = typeof(T);
      PropertyInfo[] props = type.GetProperties().Where(x => !x.Name.Equals("Id")).ToArray();

      string columnString = string.Join(",", props.Select(x => $"[{AttributeHelper.GetColumnName(x)}]"));
      string parameters = string.Join(",", props.Select(x => $"@{AttributeHelper.GetColumnName(x)}"));
      string queryString = $"insert into [{type.Name}] ({columnString}) values ({parameters})";

      using (SqlConnection conn = new SqlConnection(StaticConstant.SqlServerConnString))
      {
        try
        {
          conn.Open();
          SqlCommand comm = new SqlCommand(queryString, conn);
          Stopwatch stopwatch = new Stopwatch();
          stopwatch.Start();
          runningCount = 0;
          foreach (var item in items)
          {
            SqlParameter[] parametersAndValues = props.Select(x => new SqlParameter($"@{AttributeHelper.GetColumnName(x)}", x.GetValue(item))).ToArray();
            comm.Parameters.AddRange(parametersAndValues);
            comm.ExecuteNonQuery();
            comm.Parameters.Clear();
            runningCount++;
          }
          stopwatch.Stop();
          SqlRunningDuration.SaveRunningTime(runningCount, "sql server", stopwatch.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {

          throw ex;
        }
      }

      //插入mysql，与插入sql server做对比
      #region mysql insert
      //string columnStringForMysql = string.Join(",", props.Select(x => $"{AttributeHelper.GetColumnName(x)}"));
      //string parametersForMysql = string.Join(",", props.Select(x => $"?{AttributeHelper.GetColumnName(x)}"));
      //string queryStringForMysql = $"insert into {type.Name} ({columnStringForMysql}) values ({parametersForMysql})";

      //using (MySqlConnection connForMysql = new MySqlConnection(StaticConstant.MysqlConnString))
      //{
      //  try
      //  {
      //    connForMysql.Open();
      //    MySqlCommand commForMysql = new MySqlCommand(queryStringForMysql, connForMysql);
      //    Stopwatch stopwatch = new Stopwatch();
      //    stopwatch.Start();
      //    runningCount = 0;
      //    foreach (var item in items)
      //    {

      //      MySqlParameter[] parametersAndValuesForMsql = props.Select(x => new MySqlParameter($"?{AttributeHelper.GetColumnName(x)}", $"{x.GetValue(item)}")).ToArray();
      //      commForMysql.Parameters.AddRange(parametersAndValuesForMsql);
      //      commForMysql.ExecuteNonQuery();
      //      commForMysql.Parameters.Clear();
      //      runningCount++;
      //    }
      //    stopwatch.Stop();
      //    SqlRunningDuration.SaveRunningTime(runningCount, "mysql", stopwatch.ElapsedMilliseconds);
      //  }
      //  catch (Exception ex)
      //  {
      //    throw ex;
      //  }
      //}
      #endregion

    }
  }
}
