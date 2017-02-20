using System;
using System.Collections.Generic;
using System.Linq;

namespace CountingSort
{
  class Program
  {
    static void Main()
    {
      //var numbers = GenerateNumbers(100).Skip(5).ToList();
      //Shuffle(numbers);

      //Console.WriteLine(string.Join(" ", numbers));
      Console.WriteLine();

      var listCards = new List<Card>() {
                                      new Card() { Value=3, Suit= Suit.Clubs},
                                      new Card() { Value=2, Suit= Suit.Diamonds},
                                      new Card() { Value=10, Suit= Suit.Clubs},
                                      new Card() { Value=4, Suit= Suit.Diamonds},
                                      new Card() { Value=11, Suit= Suit.Hearts},
                                  };

      var sortedByValue = CountingSort(listCards, 2, 14, c => c.Value);
      var sortedByValueAndSuit = CountingSort(new List<Card>(), 1, 4, c => (int)c.Suit);

      Console.WriteLine(string.Join(" ", sortedByValueAndSuit));
    }

    public static List<T> CountingSort<T>(List<T> items, int min, int max, Func<T, int> sortBy)
    {

      List<List<T>> count = new List<List<T>>(max - min + 1);

      for (int i = 0; i < count.Capacity; i++)
      {
        count.Add(new List<T>());
      }

      for (int i = 0; i < items.Count; i++)
      {
        // shift position with min for negative value of min
        count[sortBy(items[i]) - min].Add(items[i]);
      }

      List<T> result = new List<T>();

      #region
      //for (int i = min; i <= max; i++)
      //{
      //  if (count[i - min].Count > 0)
      //  {
      //    result.AddRange(count[i - min]);
      //  }
      //}
      #endregion

      result.AddRange(count.SelectMany(c => c));
      return result;
    }

    public static List<int> CountingSortInt(List<int> numbers, int min, int max)
    {
      List<int> count = new List<int>(max - min + 1);

      // fill how many times we meet exact digit 
      for (int i = 0; i < count.Count; i++)
      {
        count.Add(0);
      }

      for (int i = 0; i < numbers.Count; i++)
      {
        //shift digit
        count[numbers[i] - min]++;
      }

      List<int> result = new List<int>();

      for (int i = min; i <= max; i++)
      {
        while (count[i - min] > 0)
        {
          result.Add(i);
          count[i - min]--;
        }
      }
      return result;
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

    public class Card
    {
      public int Value { get; set; }
      public Suit Suit { get; set; }
    }

    public enum Suit
    {
      Clubs = 1,
      Diamonds = 2,
      Hearts = 3,
      Spades = 4
    }


  }
}
