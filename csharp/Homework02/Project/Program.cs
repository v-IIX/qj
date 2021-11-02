using H02AOP;
using H02Delegate;
using H02Factory;
using H02Interface;
using Performer;
using System;
using System.Reflection;
using Ulti;

namespace H02Project
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        //直接用类型实例化
        {
          EastStyle abstractVocalMinicry = new EastStyle();
          Show<EastStyle>(abstractVocalMinicry);
        }

        //使用AOP方式实例化，加入AOP内容
        {
          EastStyle eastStyle = ReflectionFactory<EastStyle>.GetInstance();
          eastStyle.UniqueSkill();
        }

        //使用工厂方式实例化
        {

          //事件的意义：观察者
          //事件的发布者只申明event和触发动作
          //触发动作：订户。如“() => ConsoleWriteLineAndLog.ConsoleAndLog("夫起大呼")”或者是某个类的某个方法
          //第三方完成注册，订阅动作。使用“+=”

          EastStyle eastStyle = PerformerFactory.GetPerformer<EastStyle>();
          eastStyle.FireOnEvent += () => ConsoleWriteLineAndLog.ConsoleAndLog("夫起大呼");
          eastStyle.FireOnEvent += () => ConsoleWriteLineAndLog.ConsoleAndLog("妇亦起大呼");
          eastStyle.FireOnEvent += () => ConsoleWriteLineAndLog.ConsoleAndLog("两儿齐哭");
          eastStyle.FireOnEvent += () => ConsoleWriteLineAndLog.ConsoleAndLog("俄而百千人大呼");
          eastStyle.FireOnEvent += () => ConsoleWriteLineAndLog.ConsoleAndLog("百千人哭");
          eastStyle.FireOnEvent += () => ConsoleWriteLineAndLog.ConsoleAndLog("百千犬吠");
          Show<EastStyle>(eastStyle);
          eastStyle.SetTemperature(600);
        }

        //使用简单工厂，读取json配置文件，再创建对象
        {
          var o = SimpleFactory.GetPerformer<EastStyle>();
        }
      }
      catch (Exception)
      {

        throw;
      }
      Console.ReadKey();
    }

    /// <summary>
    /// 展示所有字段和属性的名称和值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="t"></param>
    private static void Show<T>(T t) where T : AbstractVocalMinicry, ICharge
    {
      Type type = typeof(T);
      PropertyInfo[] properties = type.GetProperties();
      foreach (var prop in properties)
      {
        ConsoleWriteLineAndLog.ConsoleAndLog($"{prop.Name} value is {prop.GetValue(t)}");
      }

      FieldInfo[] fields = type.GetFields();
      foreach (var field in fields)
      {
        ConsoleWriteLineAndLog.ConsoleAndLog($"{field.Name} value is {field.GetValue(t)}");
      }

      VocalMinicryDelegate vocalMinicryDelegate = new VocalMinicryDelegate();
      vocalMinicryDelegate.actionEvent += t.ProgramsBegin;
      vocalMinicryDelegate.actionEvent += t.OpenRemark;
      vocalMinicryDelegate.actionEvent += t.WangWang;
      vocalMinicryDelegate.actionEvent += t.HaHa;
      vocalMinicryDelegate.actionEvent += t.HoHo;
      vocalMinicryDelegate.actionEvent += t.EndRemark;
      vocalMinicryDelegate.GetactionEvent().Invoke();

      dynamic dynamic = t;
      dynamic.TakeMoney();
    }
  }
}
