#region
// User tracker delegate Callback function
//using System;
//using System.Collections.Generic;

//public delegate void AddUserCallback(int i);
//public class Program
//{
//  public static void Main()
//  {
//    Runner myRunner = new Runner();
//    myRunner.Add("bob");
//    myRunner.Add("fred");
//  }
//}
//public class User
//{
//  public User(string name)
//  {
//    this.Name = name;
//  }
//  public string Name { get; private set; }
//};
//public class UserTracker
//{
//  List<User> users = new List<User>();
//  public void AddUser(string name, AddUserCallback callback)
//  {
//    string name1 = "GOGO!";
//    users.Add(new User(name1));
//    callback(users.Count);
//  }
//}

//public class Runner
//{
//  UserTracker tracker = new UserTracker();

//  public void Add(string name)
//  {
//    tracker.AddUser(name,
//                   delegate (int i)
//                   {
//                     Console.WriteLine(name + " count" + i);
//                   }
//                   );
//  }
//}
#endregion

#region
//using System.IO;
//using System;

//class Program
//{
//  static void Main()
//  {
//    using (StreamReader sr = new StreamReader("log.txt"))
//    {
//      try
//      {
//        string line;
//        while((line = sr.ReadLine()) != null)
//        {
//          Console.WriteLine(line);
//        }
//       }
//      catch(FileNotFoundException e)
//      {
//        Console.WriteLine(e.ToString());
//      }
//    }

//  }
//}
#endregion

#region
//Singelton Pattern
//public class Catalog { };
//public class Kiosk
//{
//  static Catalog _catalog = null;
//  static object _lock = new object();
//  public static Catalog Catalog
//  {

//    get
//    {
//      if (_catalog == null)
//      {
//        lock (_lock)
//        {
//          if(_catalog == null)
//          {
//            _catalog = new Catalog();
//          }

//        }
//      }
//      return _catalog;
//    }
//  }
//}
#endregion

using System;
using System.IO;
using System.Net;

public class Program
{

  static void Main()
  {
    WebRequest request = WebRequest.Create("http://www.dir.bg/");
    request.Credentials = CredentialCache.DefaultCredentials;
    ((HttpWebRequest)request).UserAgent = ".NET Framework Example Client";


    WebResponse response = request.GetResponse();
    
    Console.WriteLine(((HttpWebResponse)response).StatusDescription);


    // simple way to convert stream in memory byte[]
    Stream dataStream = response.GetResponseStream();

    byte[] resByteArr;
    using (var memoryStream = new MemoryStream())
    {
      dataStream.CopyTo(memoryStream);
      resByteArr = memoryStream.ToArray();
    }

    var str = System.Text.Encoding.UTF8.GetString(resByteArr);

    Console.WriteLine(dataStream);
    
  }
  private async void GetData(WebResponse response)
  {
    var streamReader = new StreamReader(response.GetResponseStream());
    var url = await streamReader.ReadLineAsync();
  }
}