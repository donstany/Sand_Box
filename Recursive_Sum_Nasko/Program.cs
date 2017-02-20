namespace Recursive_Sum_Nasko
{
  using System;
  class Program
  {
    static void Main()
    {
      int[] arr = { 1, 2, 3 };
      var sum = FindSum(arr, 0);
      Console.WriteLine(sum);
    }
    static int FindSum(int[] arr, int index)
    {
      if (index==arr.Length)
      {
        return 0;
      }
      return arr[index] + FindSum(arr, index + 1);
    }
  }
}
