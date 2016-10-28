using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top6Question3
{
  delegate double MatchDel(double radius1);

  class Program
  {
      
    static void Main()
    {
      //3. Is the comparison of time and null in the if statement below valid or not? Why or why not?

      Nullable<int> a = null;
      DateTime? time = null; // Datetime is not nullable by defalt 01.01.01 0:00
      if (time ==null)
      {
        /* */
      }

      double x = 5.0;
      int y = 5;
      Console.WriteLine(x==y);
      //---------------------------------------->
      // 4.Given an instance circle of the following class:

      Func<double, double> op = r => 2 * Math.PI * r;
      var c1 = new Circle().Calculate(op);
      Console.WriteLine(c1);

    }
  }
}
