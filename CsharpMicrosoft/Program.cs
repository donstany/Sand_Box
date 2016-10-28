using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpMicrosoft
{
  //2 Question
  class Program
  {
    static void Main(string[] args)
    {
      int[] employeeIds = { 1,2,3,1,2,3,4};
      int employeeIdToRemove = 1;
      int[] filteredEmloyeeIds = employeeIds
                                            .Distinct()
                                            .Where(v => v != employeeIdToRemove)
                                            .OrderByDescending(x => x).ToArray();
      Console.WriteLine(string.Join(" ",filteredEmloyeeIds));

      var result = new Animal();

    }
  }
}
