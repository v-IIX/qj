using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.MappingExtend
{
  /// <summary>
  /// 使用泛型缓存
  /// </summary>
  /// <typeparam name="I"></typeparam>
  /// <typeparam name="O"></typeparam>
  public class ExpressionGenericMapping<I, O>
  {
    private static Func<I, O> _func = null;
    static ExpressionGenericMapping()
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
      _func = func;
    }

    public static O Trans(I i)
    {
      return _func.Invoke(i);
    }
  }
}
