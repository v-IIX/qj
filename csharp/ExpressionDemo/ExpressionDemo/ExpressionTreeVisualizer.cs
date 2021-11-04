using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionDemo
{
  public class ExpressionTreeVisualizer
  {
    public static void Show()
    {
      Expression<Func<int, int, int>> expression = (m, n) => m / n * n + 2;

      Expression<Func<People, bool>> expression2 = p => p.Id.ToString().Equals("1");

      Expression<Func<People, PeopleCopy>> exception3 = p => new PeopleCopy() { Id=p.Id,Name=p.Name,Age=p.Age };
      
    }
  }
}
