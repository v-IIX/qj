using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.Visitor
{
  public class ExpressionCustomAnd
  {
    /// <summary>
    /// 使用Expression.Lambda 构造全新的Expression表达式树
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="expression"></param>
    /// <param name="expression2"></param>
    /// <returns></returns>
    public Expression<Func<T, bool>> And<T>(Expression<Func<T, bool>> expression, Expression<Func<T, bool>> expression2)
    {
      ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "x");
      ExpressionCustomeVisitor expressionCustomeVisitor = new ExpressionCustomeVisitor(parameterExpression);
      var left = expressionCustomeVisitor.Trans(expression.Body);
      var right = expressionCustomeVisitor.Trans(expression2.Body);
      var body = Expression.And(left, right);
      var result = Expression.Lambda<Func<T, bool>>(body, parameterExpression);
      return result;
    }
  }
}
