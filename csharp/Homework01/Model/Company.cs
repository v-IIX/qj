using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class Company : BaseModel
  {
    public string Name { get; set; }
    public int CreateId { get; set; }
    public DateTime CreateTime { get; set; }
    /// <summary>
    /// 可空类型才能和数据库对应
    /// </summary>
    public int? LastModifierId { get; set; }
    public DateTime? LastModifyTime { get; set; }
  }
}
