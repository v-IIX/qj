using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternPrinciple.ISP
{
  /// <summary>
  /// 抽象类：描述是什么（is a ）
  /// </summary>
  public abstract class AbstractPhone
  {
    public int Id { get; set; }
    public string Branch { get; set; }
    public abstract void Call();
    public abstract void Text();
  }

  /// <summary>
  /// 接口：描述能干什么（can do）
  /// 一个大而全的接口（不推荐）
  /// 小而灵活的接口（推荐）
  /// </summary>
  //public interface IExtend
  //{
  //  void Photo();
  //  void Online();
  //  void Game();
  //  void Record();
  //  void Movie();
  //  void Map();
  //  void Pay();
  //}

  /// <summary>
  /// 小而灵活的接口（推荐）
  /// </summary>
  public interface IExtend
  {
    void Photo();
    void Online();
    void Game();
    void Record();
    void Movie();
  }

  /// <summary>
  /// 小而灵活的接口（推荐）
  /// </summary>
  public interface IExtendAdvanced
  {
    void Map();
    void Pay();
  }
}
