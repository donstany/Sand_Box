//using System;
//using System.IO;
//using System.Security.Permissions;
//using System.Xml;
//using System.Xml.Serialization;

//public class SongFile : IXmlSerializable
//{
// // public static event ProgressMade OnProgress;

//  public SongFile()
//  { }

//  private const string ns = "http://demos.teched2004.com/webservices";
//  public static string MusicPath;
//  private string filePath;
//  private double size;

//  void IXmlSerializable.ReadXml(System.Xml.XmlReader reader)
//  {
//    reader.ReadStartElement("DownloadSongResult", ns);
//    ReadFileName(reader);
//    ReadSongSize(reader);
//    ReadAndSaveSong(reader);
//    reader.ReadEndElement();
//  }

//  void ReadFileName(XmlReader reader)
//  {
//    string fileName = reader.ReadElementString("fileName", ns);
//    this.filePath =
//        Path.Combine(MusicPath, Path.ChangeExtension(fileName, ".mp3"));
//  }

//  void ReadSongSize(XmlReader reader)
//  {
//    this.size = Convert.ToDouble(reader.ReadElementString("size", ns));
//  }

//  void ReadAndSaveSong(XmlReader reader)
//  {
//    FileStream outFile = File.Open(
//        this.filePath, FileMode.Create, FileAccess.Write);

//    string songBase64;
//    byte[] songBytes;
//    reader.ReadStartElement("song", ns);
//    double totalRead = 0;
//    while (true)
//    {
//      if (reader.IsStartElement("chunk", ns))
//      {
//        songBase64 = reader.ReadElementString();
//        totalRead += songBase64.Length;
//        songBytes = Convert.FromBase64String(songBase64);
//        outFile.Write(songBytes, 0, songBytes.Length);
//        outFile.Flush();

//        if (OnProgress != null)
//        {
//          OnProgress(100 * (totalRead / size));
//        }
//      }

//      else
//      {
//        break;
//      }
//    }

//    outFile.Close();
//    reader.ReadEndElement();
//  }

//  [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
//  public void Play()
//  {
//    System.Diagnostics.Process.Start(this.filePath);
//  }

//  System.Xml.Schema.XmlSchema IXmlSerializable.GetSchema()
//  {
//    throw new System.NotImplementedException();
//  }

//  public void WriteXml(XmlWriter writer)
//  {
//    throw new System.NotImplementedException();
//  }
//}

public class Program1
{
  static void Main()
  {

  }
}