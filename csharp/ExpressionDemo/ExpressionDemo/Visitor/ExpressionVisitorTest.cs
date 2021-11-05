using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo.Visitor
{
  public class ExpressionVisitorTest
  {
    public static void VisitorShow()
    {
      //ExpressionVisitor类的Visit方法
      {
        Expression<Func<int, int, int>> expression = (m, n) => m * n + 2;
        OperationsVisitor operationsVisitor = new OperationsVisitor();
        Expression expression2 = operationsVisitor.Visit(expression);
      }

      {
        var source = new List<People>().AsQueryable(); //DbSet
        var result = source.Where<People>(p => p.Age > 5);

        Expression<Func<People, bool>> expression = p => p.Age > 5;

        ConditionBuilderVisitor conditionBuilderVisitor = new ConditionBuilderVisitor();
        conditionBuilderVisitor.Visit(expression);
        Console.WriteLine(conditionBuilderVisitor.Condition());
      }

      #region 表达式拼接

      {
        Expression<Func<People, bool>> expression = p => p.Age > 5;
        Expression<Func<People, bool>> expression2 = p => p.Age < 10;

        ExpressionCustomAnd expressionCustomAnd = new ExpressionCustomAnd();
        ExpressionCustomNot expressionCustomNot = new ExpressionCustomNot();

        ConditionBuilderVisitor conditionBuilderVisitor = new ConditionBuilderVisitor();
        var resultAnd = expressionCustomAnd.And<People>(expression, expression2);
        var resultOr = expressionCustomNot.Not(expression);


      }

      #endregion

    } 
  }
}