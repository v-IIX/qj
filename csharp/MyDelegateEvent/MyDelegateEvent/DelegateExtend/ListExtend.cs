using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegateEvent.DelegateExtend
{
  public class ListExtend
  {
    public delegate bool ThanDelegate(Student student);

    public bool Than(Student student)
    {
      return student.Age > 25;
    }

    private List<Student> GetStudent()
    {
      #region 数据源
      List<Student> studentList = new List<Student>() {
        new Student(){ Id=1,Name="张三",ClassId=2,Age=23},
        new Student(){ Id=2,Name="李四",ClassId=3,Age=25},
        new Student(){ Id=3,Name="王麻子",ClassId=4,Age=24},
        new Student(){ Id=4,Name="赵小花",ClassId=5,Age=28},
        new Student(){ Id=4,Name="唐文艺",ClassId=6,Age=21},
        new Student(){ Id=4,Name="小可i",ClassId=7,Age=19},
      };
      #endregion
      return studentList;
    }

    public void Show()
    {
      List<Student> students = this.GetStudent();

      #region 原始方式1
      //找出年龄大于25的
      //{
      //  List<Student> result = new List<Student>();
      //  foreach (Student student in students)
      //  {
      //    if (student.Age > 25)
      //    {
      //      result.Add(student);
      //    }
      //  }
      //  Console.WriteLine($"结果一共有{result.Count()}个 ");
      //}

      ////找出姓名字数少于2个字的
      //{
      //  List<Student> result = new List<Student>();
      //  foreach (Student student in students)
      //  {
      //    if (student.Name.Length < 2)
      //    {
      //      result.Add(student);
      //    }
      //  }
      //  Console.WriteLine($"结果一共有{result.Count()}个 ");
      //}

      ////找出姓名字数少于2个字且年龄大于25的
      //{
      //  List<Student> result = new List<Student>();
      //  foreach (Student student in students)
      //  {
      //    if (student.Name.Length < 2 && student.Age > 25)
      //    {
      //      result.Add(student);
      //    }
      //  }
      //  Console.WriteLine($"结果一共有{result.Count()}个 ");
      //}
      #endregion

      #region 调用方法方式
      //this.GetStudentList(this.GetStudent(), 2);
      #endregion

      #region 委托方式
      ThanDelegate thanDelegate = new ThanDelegate(this.Than);
      //this.GetStudentListByDelegate(GetStudent(),thanDelegate);
      List<Student> result = this.GetStudentListByDelegate(GetStudent(), (Student student) => student.Name.Length > 2);
      #endregion

    }

    public List<Student> GetStudentList(List<Student> source, int type)
    {
      List<Student> result = new List<Student>();
      if (type == 1)
      {
        foreach (Student student in source)
        {
          if (student.Age > 25)
          {
            result.Add(student);
          }
        }
      }
      else if (type == 2)
      {
        foreach (Student student in source)
        {
          if (student.Name.Length < 2)
          {
            result.Add(student);
          }
        }
      }
      else if (type == 3)
      {
        foreach (Student student in source)
        {
          if (student.Name.Length < 2 && student.Age > 25)
          {
            result.Add(student);
          }
        }
      }
      return result;
    }

    /// <summary>
    /// 传入判断逻辑
    /// 委托解耦，减少重复代码
    /// </summary>
    /// <param name="source"></param>
    /// <param name="thanDelegate"></param>
    /// <returns></returns>
    public List<Student> GetStudentListByDelegate(List<Student> source, ThanDelegate thanDelegate)
    {
      List<Student> result = new List<Student>();
      foreach (Student student in source)
      {
        if (thanDelegate.Invoke(student))
          result.Add(student);
      }
      return result;
    }
  }
}
