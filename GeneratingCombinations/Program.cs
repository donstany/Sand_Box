﻿namespace GeneratingCombinations
{
  using System;

  // n nested loops
  class Program
  {
    static void Main()
    {
      // 3 nested loop which 
      int n = 3; // we must generate 3 count digits , every digit is between 4 and 8
      int startNum = 4;
      int endNum = 8;

      int[] arr = new int[n];
      GenCombs(arr, 0, startNum, endNum);
    }

    // 1:14 min
    private static void GenCombs(int[] arr, int index, int startNum, int endNum)
    {
      if (index >= arr.Length) // Combination found --> print it 
      {
        Console.WriteLine("(" + String.Join(", ", arr) + ")");
      }
      else
      {
        for (int i = startNum; i < endNum; i++)
        {
          arr[index] = i;
          GenCombs(arr, index + 1, i + 1, endNum);
        }
      }
    }
  }
}
