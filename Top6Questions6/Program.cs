using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top6Questions6
{
  class Program
  {
    private static string result;

    static void Main()
    {
      var x= SaySomething();
      Console.WriteLine(result);
    }

    static async Task<string> SaySomething()
    {
      await Task.Delay(5);
      result = "Hello world!";
      return "Something";
    }
  }
}
