namespace Quick_Sort_Multithread
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public class QuickSortAlgo
  {

    public static void Main()
    {
      var numbers = GenerateNumbers(1000000);
      Shuffle(numbers);
      //var numbers = new List<int> { 6, 5, 3, 1 };

      Console.WriteLine(string.Join(" ", numbers));

      ////   InsertionSort(numbers);
      //var sorted = QuickSort(numbers);

      var sorted = QuickSort(numbers,true,true);

      Console.WriteLine(string.Join(" ", sorted));
    }

    public static List<int> MergeSort(List<int> numbers, bool isAsync = false)
    {
      if (numbers.Count <= 1)
      {
        return numbers;
      }

      int midIndex = numbers.Count / 2;
      var left = numbers.Take(midIndex).ToList();
      var right = numbers.Skip(midIndex).ToList();

      if (isAsync)
      {
        Task leftTask  = Task.Run(() => left  = MergeSort(left, isAsync));
        Task rightTask = Task.Run(() => right = MergeSort(right, isAsync));
        Task.WaitAll(leftTask, rightTask);
      }
      else
      {
        left = MergeSort(left, isAsync);
        right = MergeSort(right, isAsync);
      }

      left = MergeSort(left);
      right = MergeSort(right);

      return Merge(left, right);
    }

    public static List<int> Merge(List<int> left, List<int> right)
    {
      List<int> result = new List<int>();
      int leftIndex = 0;
      int rightIndex = 0;

      while (leftIndex < left.Count && rightIndex < right.Count)
      {
        if (left[leftIndex] <= right[rightIndex])
        {
          result.Add(left[leftIndex]);
          leftIndex++;
        }
        else
        {
          result.Add(right[rightIndex]);
          rightIndex++;
        }
      }

      while (leftIndex < left.Count)
      {
        result.Add(left[leftIndex]);
        leftIndex++;
      }

      while (rightIndex < right.Count)
      {
        result.Add(right[rightIndex]);
        rightIndex++;
      }

      return result;
    }
    public static List<int> QuickSort(List<int> numbers, bool isOptimized = false, bool isAsync = false)
    {
      if (numbers.Count <= 1)
      {
        return numbers;
      }
      // for small items in array
      if (isOptimized && numbers.Count < 30)
      {
        return InsertionSort(numbers);
      }

      int pivotIndex = numbers.Count / 2;
      int pivot = numbers[pivotIndex];

      List<int> left = new List<int>();
      List<int> right = new List<int>();

      for (int i = 0; i < pivotIndex; i++)
      {
        if (numbers[i] <= pivot)
        {
          left.Add(numbers[i]);
        }
        else
        {
          right.Add(numbers[i]);
        }
      }

      for (int i = pivotIndex + 1; i < numbers.Count; i++)
      {
        if (numbers[i] < pivot)
        {
          left.Add(numbers[i]);
        }
        else
        {
          right.Add(numbers[i]);
        }
      }

      List<int> result = new List<int>();

      List<int> sortedLeft = null;
      List<int> sortedRight = null;

      if (isAsync)
      {
        //two thread => two task. Two task is independant. We must have more than one core in procesor
        Task leftTask = Task.Run(() => sortedLeft = QuickSort(left,isAsync:true));
        Task rightTask = Task.Run(() => sortedRight = QuickSort(right, isAsync:true));
        Task.WaitAll(leftTask, rightTask);
      }
      else
      {
        //one thread
        sortedLeft = QuickSort(left);
        sortedRight = QuickSort(right);
      }

      result.AddRange(sortedLeft);
      result.Add(pivot);
      result.AddRange(sortedRight);

      return result;
    }

    public static List<int> InsertionSort(List<int> numbers)
    {
      // support before current Index sorted list
      for (int i = 1; i < numbers.Count; i++)
      {
        // where to insert current element in ordered list backward
        int jBackIndex = i; // index which will decrease when we going back to sorted list
        // numbers[jBackIndex] < numbers[jBackIndex - 1] not numbers[jBackIndex] <= numbers[jBackIndex - 1] suport stable effect
        while (jBackIndex > 0 && numbers[jBackIndex] < numbers[jBackIndex - 1])
        {
          Swap(numbers, jBackIndex, jBackIndex - 1);
          jBackIndex--;
        }
      }

      return numbers;
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
