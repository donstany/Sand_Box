using System;
using System.Collections.Generic;

#region
// 1. task increment i -> struct copied by value
//class Program
//{
//  static void Main()
//  {
//    int i = 1;
//    Add(ref i);
//    Console.WriteLine(i);
//  }

//  static void Add(ref int i)
//  {
//    i++;
//  }
//}
#endregion

#region 
// 2. task bool expresions
//class Program
//{
//  static void Main()
//  {
//    bool t = true;
//    bool f = false;

//    Console.WriteLine(!t | !f);
//    Console.WriteLine(t || f);
//    Console.WriteLine(t ^ f);
//    Console.WriteLine(t ^ !f ^ t);
//    Console.WriteLine(!t || t && f);

//  }
//}
#endregion

#region
//class Program
//{
//  // 3. task inheritance and is operator
//  class Shape { public void pShapePrint() { } };
//  class Ellipse : Shape { public void pEllipsePrint() { } };
//  class Circle : Ellipse { public void pCirclePrint() { } };
//  class Square : Shape { };

//  static void Main()
//  {
//    Shape sh1 = new Shape();
//    sh1.pShapePrint();

//    Ellipse el1 = (Ellipse)(new Shape());
//    el1.pShapePrint();
//    el1.pEllipsePrint();

//    Circle cir1 = new Circle();
//    Circle cir2 = (Circle)(new Shape());
//    cir2.pCirclePrint();
//    cir2.pEllipsePrint();

//    IList<int> ls = new List<int>();
//    IList<int> ls1 = new int[3];
//    IList<int> ls2 = new int[4];
//  }

//}

#endregion


// 4. control flow program i, j

class Program
{
  static void Main()
  {
    int i = 1;
    int j = 10;

    do
    {
      if (j == 5)
        break;
      j--;

    } while (++i < 5);

    Console.WriteLine($"i = {i}" + System.Environment.NewLine+
                      $"j = {j}" );
  }
}

// 5. how many byte have int and how many bits in OS64

#region
// 6. method with 2 array to return an array with intersect members

//  using System;
//  using System.Collections.Generic;
//  using System.Linq;

//  class DistinctMembers
//  {
//    static void Main()
//    {
//      // input arrays - first is dynamic and second is a static array /list, array, hashset/
//      IEnumerable<int> arr1 = new List<int>() { 1, 2, 3, 4, 30, 5 };
//      IEnumerable<int> arr2 = new int[] { 2, 5, 8, 9, 29, 30 };
//      //IEnumerable<int> arr2 = new HashSet<int>() { 2, 5, 8, 9, 29, 30, 5 };

//      IEnumerable<int> result = DistinctMembers.Utils(arr1, arr2);
//      // print result at console -> Distinct member/s are: 2 30 5
//      Console.WriteLine("Distinct member/s are: " + string.Join(" ", result));
//    }

//    // method return generic collection of distinct member and work with different arguments -> dynamic array /List/ and static array/int[]/
//    private static IEnumerable<int> Utils(IEnumerable<int> arr1, IEnumerable<int> arr2)
//    {
//      List<int> distinctArr = new List<int>();
//      foreach (var item in arr1)
//      {
//        if (arr2.Contains(item))
//        {
//          distinctArr.Add(item);
//        }
//      }
//      return distinctArr;
//    }
//  }
//}
#endregion


#region
  // 6. try ctch finally condition
#endregion
