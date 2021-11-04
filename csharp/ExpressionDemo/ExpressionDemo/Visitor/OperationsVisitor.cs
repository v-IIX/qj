using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.Visitor
{
  /// <summary>
  /// ExpressionVisitor：
  ///   1 用递归解析表达式目录树，因为不知道树的深度
  ///   2 只有一个入口Visit，首先检查是个什么结构的表达式，然后调用对应的protected virtual方法
  ///   3 得到的结果继续检查结构，再调用Visit，一直到树结束
  /// </summary>
  public class OperationsVisitor : ExpressionVisitor
  {
    public override Expression Visit(Expression node)
    {
      return base.Visit(node);
    }

    protected override Expression VisitParameter(ParameterExpression node)
    {
      return base.VisitParameter(node);
    }

    protected override Expression VisitConstant(ConstantExpression node)
    {
      return base.VisitConstant(node);
    }

    protected override Expression VisitBinary(BinaryExpression node)
    {
      if (node.NodeType.Equals(ExpressionType.Add))
      {
        Expression left = base.Visit(node.Left);
        Expression right = base.Visit(node.Right);
        return Expression.Subtract(left, right);
      }

      if (node.NodeType.Equals(ExpressionType.Multiply))
      {
        Expression left = base.Visit(node.Left);
        Expression right = base.Visit(node.Right);
        return Expression.Divide(left, right);
      }

      return node;
    }
  }
}
