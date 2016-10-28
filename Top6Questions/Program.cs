using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Top6Questions
{
  // https://www.toptal.com/c-sharp/interview-questions

  class Program
  {
    static long TotalAllEvenNumbers(int[] intArray)
    {
      return intArray.Where(i => i % 2 == 0).Sum(i => (long)i);
    }

    static long TotalAllEvenNumbers1(int[] intArray)
    {
      return (from i in intArray where i % 2 == 0 select (long)i).Sum();
    }
    static void Main(string[] args)
    {
      //1. Given an array of ints, write a C# method to total all the values that are even numbers
      int[] intArr = { 1, 3, 5, 2, 4 };
      var result = TotalAllEvenNumbers1(intArr);

      Console.WriteLine(result);

      //2. What is the output of the short program below? Explain your answer.
      Question2.DoSomthing();

    }

  }
}
