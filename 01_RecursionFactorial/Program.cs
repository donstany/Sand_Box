

namespace _01_RecursionFactorial
{
  using System;
 public class Program
  {
    static void Main()
    {
      Console.Write("n = ");
      int number = int.Parse(Console.ReadLine());

      decimal factorial = Factorial(number);
      Console.WriteLine($"{number}! = {factorial}");
    }

    private static decimal Factorial(int n)
    {
      if (n==0)
      {
        return 1;
      }
      else
      {
        return n * Factorial(n - 1);
      }
    }
  }
}
