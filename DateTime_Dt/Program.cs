namespace DateTime_Dt
{
  using System;

  class Program
  {
    static void Main(string[] args)
    {
      //30-12-2016 14:56
      DateTime dt = new DateTime();
      string dtStr = DateTime.Now.ToString("MM-dd-yyyy");
      Console.WriteLine(dtStr);
    }
  }
}
