using CommonFramwork;
using CommonFramwork.AttributeExtend;
using CommonFramwork.log;
using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public class BaseDAL
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

      string columnString = string.Join(",", type.GetProperties().Select(p => $"[{AttributeHelper.GetColumnName(p)}]"));
      string sql = $"select {columnString} from [{type.Name}] where Id={id}";

      using (SqlConnection conn = new SqlConnection(StaticConstant.SqlServerConnString))
      {
        SqlCommand comm = new SqlCommand(sql, conn);
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

    #region MyRegion
    private List<T> ReaderToList<T>(SqlDataReader reader) where T : BaseModel
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
      Type type = typeof(T);
      var props = type.GetProperties().Where(x => !x.Name.Equals("Id"));
      string columnString = string.Join(",", props.Select(x => $"[{AttributeHelper.GetColumnName(x)}] = @{AttributeHelper.GetColumnName(x)}"));
      string queryString = $"update [{type.Name}] set {columnString} where id = {t.Id}";
      SqlParameter[] sqlParameters = props.Select(x => new SqlParameter($"@{AttributeHelper.GetColumnName(x)}", x.GetValue(t) ?? DBNull.Value)).ToArray();

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


    public void Insert<T>(T t)
    {
      int i;
      int runCount = 10000;
      Type type = typeof(T);
      PropertyInfo[] props = type.GetProperties().Where(x => !x.Name.Equals("Id")).ToArray();

      string columnString = string.Join(",", props.Select(x => $"[{AttributeHelper.GetColumnName(x)}]"));
      string parameters = string.Join(",", props.Select(x => $"@{AttributeHelper.GetColumnName(x)}"));
      string queryString = $"insert into [{type.Name}] ({columnString}) values ({parameters})";
      SqlParameter[] parametersAndValues = props.Select(x => new SqlParameter($"@{AttributeHelper.GetColumnName(x)}", x.GetValue(t))).ToArray();

      using (SqlConnection conn = new SqlConnection(StaticConstant.SqlServerConnString))
      {
        SqlCommand comm = new SqlCommand(queryString, conn);
        try
        {
          conn.Open();
          comm.Parameters.AddRange(parametersAndValues);
          Stopwatch stopwatch = new Stopwatch();
          stopwatch.Start();
          i = 0;
          while (i < runCount)
          {
            i++;
            comm.ExecuteNonQuery();
          }
          stopwatch.Stop();
          SqlRunningTime.SaveRunningTime(runCount, "sql server", stopwatch.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {

          throw ex;
        }

      }


      string columnStringForMysql = string.Join(",", props.Select(x => $"{AttributeHelper.GetColumnName(x)}"));
      string parametersForMysql = string.Join(",", props.Select(x => $"?{AttributeHelper.GetColumnName(x)}"));
      string queryStringForMysql = $"insert into {type.Name} ({columnStringForMysql}) values ({parametersForMysql})";
      MySqlParameter[] parametersAndValuesForMsql = props.Select(x => new MySqlParameter($"?{AttributeHelper.GetColumnName(x)}", $"{x.GetValue(t)}")).ToArray();

      using (MySqlConnection connForMysql = new MySqlConnection(StaticConstant.MysqlConnString))
      {
        MySqlCommand commForMysql = new MySqlCommand(queryStringForMysql, connForMysql);
        try
        {
          connForMysql.Open();
          commForMysql.Parameters.AddRange(parametersAndValuesForMsql);
          Stopwatch stopwatch = new Stopwatch();
          stopwatch.Start();
          i = 0;
          while (i < runCount)
          {
            i++;
            commForMysql.ExecuteNonQuery();
          }
          stopwatch.Stop();
          SqlRunningTime.SaveRunningTime(runCount, "mysql", stopwatch.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
          throw ex;
        }
      }

    }
  }
}
