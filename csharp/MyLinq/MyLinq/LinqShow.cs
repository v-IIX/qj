using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyLinq
{
  public class LinqShow
  {
    /// <summary>
    /// Linq to Object (Enumerable)
    /// Where:完成对数据集的过滤，通过委托封装完成通用代码，泛型+迭代去提供特性
    /// Select:完成对数据集的转换，通过委托封装完成通用代码，泛型+迭代去提供特性
    /// Min/Max:没有迭代器。
    /// 
    /// Linq to Sql (Queryable) SQL+ADO.NET
    /// Where: 完成对数据库的过滤，封装了通用代码ADO.NET,表达示目录树解析SQL
    /// 
    /// Linq to XML 封装对XML的操作
    /// 
    /// Linq to Everything
    /// </summary>
    public void Show()
    {
      List<Student> studentList = this.GetStudentList();
      #region 常规情况的数据过滤
      //{
      //  var list = new List<Student>();
      //  foreach (var item in studentList)
      //  {
      //    Thread.Sleep(500);
      //    Console.WriteLine("获取数据");
      //    if (item.Age < 30)
      //    {
      //      list.Add(item);
      //    }
      //  }
      //}
      #endregion

      #region 使用委托
      {
        var result = studentList.ElevenWhere(stu =>
        {
          Console.WriteLine("检查数据是否满足条件");
          Thread.Sleep(100);
          return stu.Age < 30;
        });//陈述是语法

        foreach (var item in result)
        {

        }
      }
      #endregion

      #region 使用Linq

      var linq = studentList.Where(stu => stu.Age > 30); //标签1
      var linqSelect = studentList.Where(stu => stu.Age > 30).Select
        (stu => new
        {
          idName = stu.Id + stu.Name,
          length = stu.Name.Length,
          ClassName = stu.ClassId == 2 ? "高级班" : "其他班"
        });

      foreach (var item in linqSelect)
      {
        Console.WriteLine(item.length);
      }

      {
        //查询表达式，等价于标签1
        var list = from s in studentList
                   where s.Age < 30
                   select s;

        foreach (var item in list)
        {
          Console.WriteLine("{0}{1}", item.Name, item.Age);
        }
      }

      {
        var list = studentList.Where<Student>(stu => stu.Age < 30) //过滤
                               .Select(s => new //投影
                               {
                                 Id = s.Id,
                                 ClassId = s.ClassId,
                                 IdName = s.Id + s.Name,
                                 ClassName = s.ClassId == 2 ? "高级班" : "其他班"
                               }).OrderBy(s => s.Id) //排序
                               .OrderByDescending(s => s.Id) //倒排
                               .Skip(2) //跳过几条
                               .Take(3); //获取几条
      }
      #endregion

    }

    #region 初始化数据
    private List<Student> GetStudentList()
    {
      return new List<Student>() {
        new Student()
        {
          Id = 1,
          Name = "Linq1",
          Age = 21,
          ClassId = 2
        },
        new Student()
        {
          Id = 2,
          Name = "Linq2",
          Age = 22,
          ClassId = 2
        },
        new Student()
        {
          Id = 3,
          Name = "Linq3",
          Age = 32,
          ClassId = 3
        },
        new Student()
        {
          Id = 4,
          Name = "Linq4",
          Age = 22,
          ClassId = 2
        },
      };
    }
    #endregion

  }
}
