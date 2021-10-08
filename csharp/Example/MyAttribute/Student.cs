using MyAttribute.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute
{
  [CustomAttribute(123, Description = "this is attribute descrition", Remark = " this is attribute remark")]
  public class Student
  {
    public int Id { get; set; }
    [Length(5, 10)]
    public string Name { get; set; }
    /// <summary>
    /// 对QQ 做范围检测
    /// 10001-999999999999
    /// </summary>
    [LongAttribute(10001, 999999999999)]
    public long QQ { get; set; }

    //以前这么写，解决数据合法性，给属性增加了太多事
    //private long _TIM = 0;
    //public long TIM
    //{
    //  get { return this._TIM; }
    //  set
    //  {
    //    if (value > 10001 && value < 999999999999)
    //    {
    //      this._TIM = value;
    //    }
    //    else
    //    {
    //      throw new Exception();
    //    }
    //  }
    //}

    [Custom(Description = "study method's attribute")]
    public void Study()
    {
      Console.WriteLine($"这里是{this.Name}跟着老师学习");
    }

    [CustomAttribute]
    [return: CustomAttribute(Description = "return parameter's attribute")]
    public string Answer([CustomAttribute(Description = "parameter's attribute")] string name)
    {
      return $"this is {name}";
    }
  }
}
