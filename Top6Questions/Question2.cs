using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top6Questions
{
  public static class Question2
  {
    static string location;
    static DateTime time;

    public static void DoSomthing()
    {
      Console.WriteLine(location == null ? "location is null" : location);
      Console.WriteLine(time == null ? "time is null" :time.ToString());
    }
  }
}
