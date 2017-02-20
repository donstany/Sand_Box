namespace Fibonacci_Optimaized
{
  using System;
  class Program
  {
    static decimal[] fibCache = new decimal[10000];

    static decimal Fibonacci(int n)
    {
      if (fibCache[n] != 0)
      {
        return fibCache[0];
      }

      if ((n == 1) || (n == 2))
      {
        fibCache[n] = 1;
        return fibCache[n];
      }
      else
      {
        fibCache[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
        return fibCache[n];
      }
    }
    static void Main()
    {
      Console.Write("Fib(10) = ");
      decimal fib10 = Fibonacci(10);
      Console.WriteLine(fib10);

      {
        Console.Write("Fib(50) = ");
        decimal fib50 = Fibonacci(50);
        Console.WriteLine(fib50);

      }
    }
  }
}
