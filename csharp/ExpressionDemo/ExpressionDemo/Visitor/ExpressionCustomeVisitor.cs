using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.Visitor
{
  public class ExpressionCustomeVisitor : ExpressionVisitor
  {
    private ParameterExpression _parameter;

    public ExpressionCustomeVisitor(ParameterExpression parameter)
    {
      _parameter = parameter;
    }

    public Expression Trans(Expression expression)
    {
      return base.Visit(expression);
    }

    protected override Expression VisitParameter(ParameterExpression node)
    {
      return base.VisitParameter(_parameter);
    }

    protected override Expression VisitMember(MemberExpression node)
    {
      return base.VisitMember(node);
    }
  }
}
