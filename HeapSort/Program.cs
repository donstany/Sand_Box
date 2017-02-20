using System;
using System.Collections.Generic;
using System.Linq;

namespace CountingSort
{
  class Program
  {
    static void Main()
    {
      var numbers = GenerateNumbers(100).Skip(5).ToList();
      Shuffle(numbers);

      Console.WriteLine(string.Join(" ", numbers));

      var sorted = CountingSort(numbers, 6, 100, c => c);

      Console.WriteLine(string.Join(" ", sorted));
    }

    public static List<T> CountingSort<T>(List<T> items, int min, int max, Func<T, int> sortBy)
    {

      List<List<T>> count = new List<List<T>>(max - min + 1);

      for (int i = 0; i < count.Capacity; i++)
      {
        count[i] = new List<T>();
      }

      for (int i = 0; i < items.Count; i++)
      {
        // shift position with min for negative value of min
        count[sortBy(items[i]) - min].Add(items[i]);
      }

      List<T> result = new List<T>();
      for (int i = min; i <= max; i++)
      {
        if (count[i - min].Count > 0)
        {
          result.AddRange(count[i - min]);
        }
      }
      //result.AddRange(count.SelectMany(c => c));
      return result;
    }

    public static List<int> CountingSortInt(List<int> numbers, int min, int max)
    {
      List<int> count = new List<int>(max - min + 1);

      // fill how many times we meet exact digit 
      for (int i = 0; i < numbers.Count; i++)
      {
        count[i]++;
      } 

      List<int> result = new List<int>();

      for (int i = min; i <= max; i++)
      {
        while (count[i - min] > 0)
        {
          result.Add(i);
          count[i]--;
        }
      }
      return null;
    }

    public static List<int> GenerateNumbers(int maxNumber)
    {
      List<int> result = new List<int>();
      for (int i = 1; i <= maxNumber; i++)
      {
        result.Add(i);
      }
      return result;
    }
    // Fisher-Yates
    public static void Shuffle<T>(List<T> numbers)
    {
      Random random = new Random();
      for (int i = 0; i < numbers.Count - 1; i++)
      {
        int randomIndex = random.Next(i + 1, numbers.Count);
        Swap(numbers, i, randomIndex);
      }
    }

    public static void Swap<T>(List<T> numbers, int firstIndex, int secondIndex)
    {
      T temp = numbers[firstIndex];
      numbers[firstIndex] = numbers[secondIndex];
      numbers[secondIndex] = temp;
    }
  }
}
