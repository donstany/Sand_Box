namespace ClientMail
{
  using EAGetMail;
  using System;
  using System.IO;

  class Program
  {
    static void Main(string[] args)
    {
      // Create a folder named "inbox" under current directory
      // to save the email retrieved.
      string curpath = Directory.GetCurrentDirectory();
      string mailbox = string.Format("{0}\\inbox", curpath);

      // If the folder is not existed, create it.
      if (!Directory.Exists(mailbox))
      {
        Directory.CreateDirectory(mailbox);
      }

      MailServer oServer = new MailServer("pop3.gmail.com",
                  "test.stanev@gmail.com", "test.stanev2801", ServerProtocol.Pop3);
      MailClient oClient = new MailClient("TryIt");

      // If your POP3 server requires SSL connection,
      // Please add the following codes:
      oServer.SSLConnection = true;
      oServer.Port = 995;

      try
      {
        oClient.Connect(oServer);
        MailInfo[] infos = oClient.GetMailInfos();
        for (int i = 0; i < infos.Length; i++)
        {
          MailInfo info = infos[i];
          Console.WriteLine("Index: {0}; Size: {1}; UIDL: {2}",
              info.Index, info.Size, info.UIDL);

          // Receive email from POP3 server
          Mail oMail = oClient.GetMail(info);

          Console.WriteLine("From: {0}", oMail.From.ToString());
          Console.WriteLine("Subject: {0}\r\n", oMail.Subject);

          // Generate an email file name based on date time.
          System.DateTime d = System.DateTime.Now;
          System.Globalization.CultureInfo cur = new
              System.Globalization.CultureInfo("en-US");
          string sdate = d.ToString("yyyyMMddHHmmss", cur);
          string fileName = String.Format("{0}\\{1}{2}{3}.eml",
              mailbox, sdate, d.Millisecond.ToString("d3"), i);

          // Save email to local disk
          oMail.SaveAs(fileName, true);

          // Mark email as deleted from POP3 server.
          oClient.Delete(info);
        }

        // Quit and purge emails marked as deleted from POP3 server.
        oClient.Quit();
      }
      catch (Exception ep)
      {
        Console.WriteLine(ep.Message);
      }

    }
  }
}
