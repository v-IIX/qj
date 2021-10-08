using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyAttribute.Extension
{

  public enum UserState
  {
    [Remark("正常")]
    Normal = 0,
    [Remark("冻结")]
    Frozen = 1,
    [Remark("删除")]
    Delete = 2
  }

  public class RemarkAttribute : Attribute
  {
    private string Remark = null;

    public RemarkAttribute(string remark)
    {
      this.Remark = remark;
    }

    public string GetRemark()
    {
      return this.Remark;
    }
  }

  public static class RemarkExtension
  {
    //参数里带this的称为扩展方法
    public static string GetRemark(this UserState value)
    {
      Type type = typeof(UserState);
      FieldInfo field = type.GetField(value.ToString());
      if (field.IsDefined(typeof(RemarkAttribute), true))
      {
        RemarkAttribute state = (RemarkAttribute)field.GetCustomAttribute(typeof(RemarkAttribute), true);
        return state.GetRemark();
      }
      else
      {
        return value.ToString();
      }
    }
  }
}
