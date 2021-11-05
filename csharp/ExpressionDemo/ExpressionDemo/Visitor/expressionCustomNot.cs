using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.Visitor
{
  public class ExpressionCustomNot
  {
    public Expression<Func<T, bool>> Not<T>(Expression<Func<T, bool>> expression)
    {
      var parameters = expression.Parameters;
      var parameter = parameters[0];
      var body = Expression.Not(expression.Body);
      var result = Expression.Lambda<Func<T, bool>>(body, parameter);
      return result;
    }
  }
}
