namespace FreeClientmail
{
  using System.Net.Mail;
  using System.Net;
  public class ClientFree
  {
    public static void Main()
    {
      try
      {
        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
        client.Credentials = new NetworkCredential("test.stanev", "test.stanev2801");
        MailMessage msg = new MailMessage();
        msg.To.Add(new MailAddress("test.stanev@gmail.com"));
        msg.From=new MailAddress("test.stanev@gmail.com");
        msg.Subject = "test";
        msg.Body = "Body";
        client.EnableSsl = true;
        client.Send(msg);
      }
      catch
      {
        System.Console.WriteLine("Sorry");
      }

      try
      {
        SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
        client.Credentials = new NetworkCredential("test.stanev", "test.stanev2801");
        MailMessage msg = new MailMessage();
        msg.To.Add(new MailAddress("test.stanev@gmail.com"));
        msg.From = new MailAddress("test.stanev@gmail.com");
        msg.Subject = "test";
        msg.Body = "Body";
        client.EnableSsl = true;
        client.Send(msg);
      }
      catch
      {
        System.Console.WriteLine("Sorry");
      }
    }
  }
}