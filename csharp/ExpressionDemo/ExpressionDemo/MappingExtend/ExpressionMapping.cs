using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionDemo.MappingExtend
{
  public class ExpressionMapping
  {
    private static Dictionary<string, object> Dic = new Dictionary<string, object>();

    /// <summary>
    /// 使用静态字典实现缓存
    /// </summary>
    /// <typeparam name="I">传入参数类型</typeparam>
    /// <typeparam name="O">返回参数类型</typeparam>
    /// <param name="i">传入形参</param>
    /// <returns></returns>
    public static O Trans<I, O>(I i)
    {
      string key = string.Format("key_{0}_{1}", typeof(I).Name, typeof(O).Name);
      if (!Dic.ContainsKey(key))
      {
        ParameterExpression parameterExpression = Expression.Parameter(typeof(I), "i");
        List<MemberBinding> memberBindings = new List<MemberBinding>();
        foreach (var item in typeof(O).GetProperties())
        {
          memberBindings.Add(Expression.Bind(item, Expression.Property(parameterExpression, typeof(I).GetProperty(item.Name))));
        }

        foreach (var item in typeof(O).GetFields())
        {
          memberBindings.Add(Expression.Bind(item, Expression.Field(parameterExpression, typeof(I).GetField(item.Name))));
        }

        Expression<Func<I, O>> expression = Expression.Lambda<Func<I, O>>
          (
            Expression.MemberInit
            (
              Expression.New(typeof(O)), memberBindings

            ), new ParameterExpression[1] { parameterExpression }
          );

        Func<I, O> func = expression.Compile();
        Dic[key] = func;
      }

      return ((Func<I, O>)Dic[key]).Invoke(i);
    }
  }
}
