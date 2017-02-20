namespace Walk_File_System
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Linq;

  class DFS
  {
    static void Main(string[] args)
    {
      Traverse(@"C:\xampp", 1);
    }

    // Depth-First-Search
    static HashSet<string> allPaths = new HashSet<string>();

    static void Traverse(string path, int indent)
    {
      // somebody was already visiting this place
      if (allPaths.Contains(path))
      {
        //
        return;
      }
      // mark so we visit this path
      allPaths.Add(path);

      var files = Directory.GetFiles(path);
      Console.Write(new string('-', indent *2));
      Console.WriteLine(string.Join(", ", files));
      Console.WriteLine();

      var subdirs = Directory.GetDirectories(path);
      foreach (var d in subdirs)
      {
        Traverse(d, indent + 1);
      }
      Console.WriteLine("returned back");
    }
  }
}
