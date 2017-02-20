namespace GenereteBitsVectors
{
  using System;

  class Program
  {
    // How to generate all 8-bit vectors recursivly
    static void Gen01(int index, int[] vector)
    {
      if (index <0)
      {
        Print(vector);
      }
      else
      {
        for (int i = 0; i <=1; i++)
        {
          vector[index] = i;
          Gen01(index - 1, vector);
        }
      }
    }

    static void Print(int[] vector)
    {
      foreach (var i in vector)
      {
        Console.Write($"{i}");
      }
      Console.WriteLine();
    }

    static void Main()
    {
      Console.Write("n = ");
      int n = int.Parse(Console.ReadLine());

      int[] vector = new int[n];
      Gen01(n - 1, vector);
    }


  }
}
