using ExpressionDemo.MappingExtend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo
{
  /// <summary>
  /// 表达式目录树动态生成的用途：
  ///   1 可以用来替代反射，因为反射可以通用，但性能低
  ///   2 生成硬编码，可以提升性能 
  /// </summary>
  public class ExpressionTest
  {
    public static void Show()
    {
      Func<int, int, int> func = (int m, int n) => m * n + 2;

      //lambda表达式申明表达式目录树，只能写在一行上，不能有大括号
      Expression<Func<int, int, int>> exp = (m, n) => m * n + 2;

      //达式目录树，只能写在一行上，不能有大括号
      //Expression<Func<int, int, int>> exp = (m, n) =>{ m* n +2 };

      //表达式目录树，语法树，或者说是一种数据结构，可以被解析 
      int result = func.Invoke(10, 20);
      //Compile方法可以得到对应委托的实例
      int result2 = exp.Compile().Invoke(10, 20);

      //手动拼装表达式目录树
      {
        //expression和expression2是等价的

        Expression<Func<int, int, int>> expression = (m, n) => m * n * m + 2;

        ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "m");
        ParameterExpression parameterExpression2 = Expression.Parameter(typeof(int), "n");
        ParameterExpression parameterExpression3 = Expression.Parameter(typeof(int), "l");
        var multiply = Expression.Multiply(parameterExpression, parameterExpression2);
        var constant = Expression.Constant(2, typeof(int));
        var add = Expression.Add(multiply, constant);

        Expression<Func<int, int, int>> expression2 = Expression.Lambda<Func<int, int, int>>(add, new ParameterExpression[] { parameterExpression, parameterExpression2 });

      }

      //手动拼装表达式目录树
      {
        ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "x");
        ParameterExpression parameterExpression2 = Expression.Parameter(typeof(int), "y");
        ParameterExpression parameterExpression3 = Expression.Parameter(typeof(int), "z");
        BinaryExpression multiply = Expression.Multiply(parameterExpression, parameterExpression2);
        BinaryExpression multiply2 = Expression.Multiply(multiply, parameterExpression3);
        ConstantExpression constantExpression = Expression.Constant(2, typeof(int));
        BinaryExpression binaryExpression = Expression.Add(multiply2, constantExpression);

        Expression<Action<int, int, int>> expression = Expression.Lambda<Action<int, int, int>>(binaryExpression, new ParameterExpression[] { parameterExpression, parameterExpression2, parameterExpression3 });

        expression.Compile().Invoke(1, 2, 3);

      }

      //手动拼装表达式目录树
      {
        //Expression<Func<People, bool>> expression = (p) => p.Id.ToString().Equals("5");

        ParameterExpression parameterExpression = Expression.Parameter(typeof(People), "p");
        //var x = typeof(People).GetProperty("Id");
        Expression field = Expression.Property(parameterExpression, typeof(People).GetProperty("Id"));
        var toStingMethod = typeof(People).GetMethod("ToString"); ;
        var equalsMethod = typeof(People).GetMethod("Equals");
        ConstantExpression constantExpression = Expression.Constant("5", typeof(string));
        Expression<Func<People, bool>> expression2 = Expression.Lambda<Func<People, bool>>(Expression.Call(Expression.Call(field, toStingMethod, new Expression[] { }), equalsMethod, constantExpression), parameterExpression);

        bool result3 = expression2.Compile().Invoke(new People { Id = 5, Name = "v", Age = 23 });

      }

      //将people转换为peoplecopy，只能为这两个服务，不具备通用性
      {
        People people = new People()
        {
          Id = 1,
          Name = "v",
          Age = 22
        };

        PeopleCopy peopleCopy = new PeopleCopy()
        {
          Id = people.Id,
          Name = people.Name,
          Age = people.Age
        };
      }

      //利用反射完成
      {
        People people = new People()
        {
          Id = 1,
          Name = "v",
          Age = 22
        };

        var result4 = ReflectionMapper.Trans<People, PeopleCopy>(people);

      }

      //表达式目录树 + 静态字典
      {
        People people = new People()
        {
          Id = 1,
          Name = "v",
          Age = 22
        };

        var result4 = ExpressionMapping.Trans<People, PeopleCopy>(people);
      }

      //表达式目录树 + 泛型缓存
      {
        {
          People people = new People()
          {
            Id = 1,
            Name = "v",
            Age = 22
          };

          var result5 = ExpressionGenericMapping<People, PeopleCopy>.Trans(people);
        }
      }


    }
  }
}
