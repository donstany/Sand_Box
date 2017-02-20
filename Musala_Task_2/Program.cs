using System;
using System.Collections.Generic;
using System.Linq;

namespace Musala_Task_2
{
  class Program
  {
    static void Main(string[] args)
    {

      int[] array1 = { 1, 2, 3, 4, 5, 5, 11 };
      int[] array3 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
      //To delete all duplicate entries do this
      var distinct = array1.Distinct().ToArray();
      //To see elements which are in array1 and not in array3
      var result = array1.Except(array3).ToArray();
      //To see elements which are in array3 and not in array1
      var result1 = array3.Except(array1).ToArray();

      List<String> list2 = new List<String>() { "I", "am" };

       // 11
      var added = array1.Except(array3).ToArray();
      // 6 7 8 9 10
      var removed = array3.Except(array1).ToArray();

      Console.WriteLine(String.Join(" ",distinct));
      Console.WriteLine(String.Join(" ",added   ));
      Console.WriteLine(String.Join(" ",removed ));
    }
  }
}
