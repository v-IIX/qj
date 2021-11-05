using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.Visitor
{
  public class ConditionBuilderVisitor : ExpressionVisitor
  {
    /// <summary>
    /// 栈：后进先出
    /// </summary>
    private Stack<string> _stringStack = new Stack<string>();

    public string Condition()
    {
      string condition = string.Concat(this._stringStack.ToArray());
      this._stringStack.Clear();
      return condition;
    }

    /// <summary>
    /// 二元运算
    /// 对于node本身来说没有任何影响，只是使用node完成其它工作
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    protected override Expression VisitBinary(BinaryExpression node)
    {
      if (node == null)
      {
        throw new ArgumentNullException($"BinaryExpression {node} is null");
      }

      string sqlOperator = ExpressionTypeToSqlOperator.Trans(node.NodeType);
      this._stringStack.Push(")");
      base.Visit(node.Right);
      this._stringStack.Push(" " + sqlOperator + " ");
      base.Visit(node.Left);
      this._stringStack.Push("(");

      return node;
    }

    /// <summary>
    /// 常量
    /// 对于node本身来说没有任何影响，只是使用node完成其它工作
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    protected override Expression VisitConstant(ConstantExpression node)
    {
      if (node == null)
      {
        throw new ArgumentNullException($"BinaryExpression {node} is null");
      }

      this._stringStack.Push("‘" + node.Value + "’");

      return node;
    }

    /// <summary>
    /// 属性
    /// 对于node本身来说没有任何影响，只是使用node完成其它工作
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    protected override Expression VisitMember(MemberExpression node)
    {
      if (node == null)
      {
        throw new ArgumentNullException($"BinaryExpression {node} is null");
      }
      this._stringStack.Push(" [" + node.Member.Name + "] ");

      return node;
    }

    /// <summary>
    /// 方法调用
    /// 相当于什么也没有做
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
      return node;
    }
  }
}
