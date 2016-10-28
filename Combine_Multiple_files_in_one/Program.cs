using System.IO;
using System;
using System.Linq;

public static class Program
{
  public static void CombineMultipleFilesIntoSingleFile(/*string inputDirectoryPath, string inputFileNamePattern, string outputFilePath*/)
  {
    var strPath = @"C:\Users\User\Documents\SQL_Transfer";
    var inputFilePaths = Directory.EnumerateFiles(strPath, "*.*", SearchOption.TopDirectoryOnly)
                                                  .Where(s => s.EndsWith(".sql") || s.EndsWith(".*")).ToArray<string>();
    Console.WriteLine("Number of files: {0}.", inputFilePaths.Length);

    #region
    // string[] inputFilePaths = Directory.GetFiles(inputDirectoryPath, inputFileNamePattern);
    // Console.WriteLine("Number of files: {0}.", inputFilePaths.Length);
    //foreach (var item in inputFilePaths)
    //{
    //  using (FileStream stream = File.OpenRead(item))
    //  using (FileStream writeStream = File.OpenWrite(strPath + @"final\final.sql"))
    //  {
    //    BinaryReader reader = new BinaryReader(stream);
    //    BinaryWriter writer = new BinaryWriter(writeStream);

    //    // create a buffer to hold the bytes 
    //    byte[] buffer = new Byte[1024];
    //    int bytesRead;

    //    // while the read method returns bytes
    //    // keep writing them to the output stream
    //    while ((bytesRead =
    //            stream.Read(buffer, 0, 1024)) > 0)
    //    {
    //      writeStream.Write(buffer, 0, bytesRead);
    //    }
    //  }

    //}

    #endregion
    int i =0 ;
    using (var outputStream = File.Create(strPath + @"\final\final.sql"))
    {
      foreach (var inputFilePath in inputFilePaths)
      {
        using (var inputStream = File.OpenRead(inputFilePath))
        {
          int bufferSize = 1;
          // Buffer size can be passed as the second argument.
          inputStream.CopyTo(outputStream, bufferSize);
          i++;
          Console.WriteLine($"ïterates : {i}" );
        }
        Console.WriteLine("The file {0} has been processed.", inputFilePath);
      }
    }
  }


  public class Program1
  {
    public static void Main()
    {
      Program.CombineMultipleFilesIntoSingleFile();
    }
  }
}

