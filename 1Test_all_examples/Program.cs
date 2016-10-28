using System;
using System.Collections.Generic;


#region
//class Program
//{
//  // important we can define variable outside the method with static 
//  private static int sum;
//  static void Main()
//  {

//    int[] intArr =  { 1, 2, 3, 4, 4, 4 };
//    for (int i=0; i<intArr.Length; i++ )
//    {
//      if (intArr[i] % 2 ==0)
//      {
//        Program.sum += intArr[i];
//      }

//    }
//    Console.WriteLine(sum);
//    Console.ReadKey();
//  }
//}
#endregion

#region
// REF parameter
//public class Program 
//  {
//  // ref must initialize before pass like a parameter
//    public static string GetNextName(ref int id)
//    {
//      string returnText = "Next-" + id.ToString();
//      id += 1;
//      return returnText;
//    }

//    public static void Main(string[] args)
//    {
//      int i = 1;
//      Console.WriteLine("Previous value of integer i:" + i.ToString());
//      string test = GetNextName(ref i);
//      Console.WriteLine("Current value of integer i:" + i.ToString());
//    }
//  }
#endregion

#region
// OUT PARAM
//public class Program
//{
//  public static string GetNextNameByOut(out int id)
//  {
//    id = 1;
//    string returnText = "Next-" + id.ToString();
//    return returnText;
//  }
//  static void Main(string[] args)
//  {
//    int i = 1;
//    Console.WriteLine("Previous value of integer i:" + i.ToString());
//    string test = GetNextNameByOut(out i);
//    Console.WriteLine("Current value of integer i:" + i.ToString());
//  }
//}
#endregion

#region
// EXTENTION METHOD
//public class Class1
//{
//  public void Display()
//  {
//    Console.WriteLine("I m in Display"); 
//  }
//  public void Print()
//  {
//    Console.WriteLine("I m in Print");
//  }
//}

//public static class XX
//{
//  /// <summary>
//  /// Returning new implementation
//  /// </summary>
//  /// <param name="ob">extended class</param>
//  public static void NewMethod(this Class1 ob)
//  {
//    Console.WriteLine("Hello Iam extended method!");
//  }
//}
//public class Program
//{
//  static void Main()
//  {
//    Class1 ob1 = new Class1();
//    ob1.Display();
//    ob1.Print();
//    ob1.NewMethod();
//    Console.ReadKey();
//  }
//}
#endregion

#region
//using System.Linq;
//class Program
//{
//  static void Main()
//  {
//    int[] intArr = { 1, 2, 3, 4, 4 };
//    var result1= intArr.Where(x => x%2==0).Sum();
//    IEnumerable result2 = from n in intArr where (n % 2 == 0) select n;
//    foreach (var item in result2)
//    {
//      Console.WriteLine(item);
//    }
//    Console.WriteLine();
//  }
//}
#endregion

#region
// starting out program with task scheduler;
//using System;
//using System.Diagnostics;

//namespace ProcessExitSample
//{
//  class Program
//  {
//    static void Main(string[] args)
//    {
//      try
//      {

//        Process firstProc = new Process();
//        firstProc.StartInfo.FileName = "notepad.exe";
//        firstProc.EnableRaisingEvents = true;

//        firstProc.Start();

//        firstProc.WaitForExit();

//        //You may want to perform different actions depending on the exit code.
//        Console.WriteLine("First process exited: " + firstProc.ExitCode);

//        Process secondProc = new Process();
//        secondProc.StartInfo.FileName = "mspaint.exe";
//        secondProc.Start();

//      }
//      catch (Exception ex)
//      {
//        Console.WriteLine("An error occurred!!!: " + ex.Message);
//        return;
//      }
//    }
//  }
//}
#endregion


#region
//public class Program
//{
// Generic class 
//public class Animal { };
//public static void Save<T>(T target) where T : Animal, new()
//{
//  throw new NotImplementedException();
//}
//}
#endregion

#region
// EXTENTION METHODS
//public static class ExtensionMethods
//{
//  public static bool IsUrl(this String str)
//  {
//    string pattern = @"(https ?:\/\/)?([A-Za-z0-9]*\.)?([A-Za-z0-9-]*)";
//    var regex = new Regex(pattern);
//    return regex.IsMatch(str);
//  }
//}

//public class Program
//{
//  public static void Main()
//  {
//    string strTest = @"http://www.aiotestking.com/microsoft/how-should-you-complete-the-relevant-code-21/";
//    bool IsHttpAddress = strTest.IsUrl();
//    Console.WriteLine(IsHttpAddress);
//  }
//}
#endregion

// Interface IEnumerator
//public interface IOutputFormatter<T>
//{
//  string GetOutput(IEnumerator<T> iterator, int recordSize);

//}
//public class TabDelimiterFormatter : IOutputFormatter<string>
//{
//  readonly Func<int, char> suffix = col => col % 2 == 0 ? '\n' : '\t';
//  public string GetOutput(IEnumerator<string> iterator, int recordSize)
//  {
//    var output = new StringBuilder();
//    for (int i = 1; iterator.MoveNext(); i++)
//    {
//      output.Append(iterator.Current);
//      output.Append(suffix(i));
//    }
//    return output.ToString();
//  }
//}

//public class Program
//{
//  public static void Main()
//  {
//    List<string> lst = new List<string>() { "a","b", "c", "d"};
//    var TabDelimit = (new TabDelimiterFormatter()).GetOutput(lst.GetEnumerator(), lst.Count);
//    Console.WriteLine(TabDelimit);

//  }
//}

#region
//OOP
//public class Employee
//{
//  private const string _default_emptype = "example";
//  private string _emptype = _default_emptype;
//  protected string EmployeeType
//  {
//    get { return this._emptype; }
//    private set { this._emptype = _default_emptype; }
//  }
//}

//public class Program
//{
//  public static void Main()
//  {
//    var emp = new Employee();

//  }
//}
#endregion

//Type cast conversion
//  class Program
//{
//  public static void Calculate(float amount)
//  {
//    object amountRef = amount;
//    int balance = (int)(float)amountRef;
//    Console.WriteLine(balance);
//    Console.WriteLine(System.Reflection.Assembly.GetExecutingAssembly());
//  }

//  public static void Main()
//  {
//    Calculate(5.81f);
//  }
//}

#region
//using System;
//using System.Threading;
//using System.Threading.Tasks;

//class ContinuationSimpleDemo
//{
//  // Demonstrated features:
//  // 		Task.Factory
//  //		Task.ContinueWith()
//  //		Task.Wait()
//  // Expected results:
//  // 		A sequence of three unrelated tasks is created and executed in this order - alpha, beta, gamma.
//  //		A sequence of three related tasks is created - each task negates its argument and passes is to the next task: 5, -5, 5 is printed.
//  //		A sequence of three unrelated tasks is created where tasks have different types.
//  // Documentation:
//  //		http://msdn.microsoft.com/en-us/library/system.threading.tasks.taskfactory_members(VS.100).aspx
//  static void Main()
//  {
//    Action<string> action =
//        (str) =>
//            Console.WriteLine("Task={0}, str={1}, Thread={2}", Task.CurrentId, str, Thread.CurrentThread.ManagedThreadId);

//    // Creating a sequence of action tasks (that return no result).
//    Console.WriteLine("Creating a sequence of action tasks (that return no result)");
//    Task.Factory.StartNew(() => action("alpha"))
//        .ContinueWith(antecendent => action("beta"))        // Antecedent data is ignored
//        .ContinueWith(antecendent => action("gamma"))
//        .Wait();


//    Func<int, int> negate =
//        (n) =>
//        {
//          Console.WriteLine("Task={0}, n={1}, -n={2}, Thread={3}", Task.CurrentId, n, -n, Thread.CurrentThread.ManagedThreadId);
//          return -n;
//        };

//    // Creating a sequence of function tasks where each continuation uses the result from its antecendent
//    Console.WriteLine("\nCreating a sequence of function tasks where each continuation uses the result from its antecendent");
//    Task<int>.Factory.StartNew(() => negate(5))
//        .ContinueWith(antecendent => negate(antecendent.Result))    // Antecedent result feeds into continuation
//        .ContinueWith(antecendent => negate(antecendent.Result))
//        .Wait();


//    // Creating a sequence of tasks where you can mix and match the types
//    Console.WriteLine("\nCreating a sequence of tasks where you can mix and match the types");
//    Task<int>.Factory.StartNew(() => negate(6))
//        .ContinueWith(antecendent => action("x"))
//        .ContinueWith(antecendent => negate(7))
//        .Wait();
//  }
//}
#endregion

#region
// EVENT NOTIFICATION
//public class Program
//{
//  public static void Main()
//  {
//    var res = new Lease();
//    res.Term = 6;
//  }
//}

//public delegate void MaximumTermReachedHandler(object source, EventArgs e);
//public class Lease
//{
//  public event MaximumTermReachedHandler OnMaximumTermReached;
//  private int _term;
//  private const int MaximumTerm = 5;
//  private const decimal Rate = 0.034m;

//  public int Term
//  {
//    get { return _term; }
//    set
//    {
//      if (value <= MaximumTerm)
//      {
//        this._term = value;
//      }
//      else
//      {
//        if (OnMaximumTermReached != null)
//        {
//          OnMaximumTermReached(this, new EventArgs());
//        }
//      }
//    }
//  }
//}
#endregion

// User tracker delegate
public delegate void AddUserCallback(int i);
public class Program
{
  public static void Main()
  {
    Runner myRunner = new Runner();
    myRunner.Add("bob");
    myRunner.Add("fred");
  }
}
public class User
{
  public User(string name)
  {
    this.Name = name;
  }
  public string Name { get; private set; }
};
public class UserTracker
{
  List<User> users = new List<User>();
  public void AddUser(string name, AddUserCallback callback)
  {
    string name1 = "GOGO!";
    users.Add(new User(name1));
    callback(users.Count);
  }
}

public class Runner
{
  UserTracker tracker = new UserTracker();

  public void Add(string name)
  {
    tracker.AddUser(name, 
                   delegate (int i){
                        Console.WriteLine(name + " count" + i);}
                   );
  }
}




