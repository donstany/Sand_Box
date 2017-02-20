namespace EmailClientOutlook
{
  using D.Net.EmailClient;
  using D.Net.EmailInterfaces;
  using OpenPop.Pop3;
  using System;
  using System.Collections.Generic;
  using System.Data;
  using System.Globalization;
  using System.Web.UI;
  using static LumiSoft.Net.MIME.MIME_MediaTypes;
  using OpenPop.Common.Logging;
  using OpenPop.Mime;
  using OpenPop.Mime.Decode;
  using OpenPop.Mime.Header;
  using Outlook = Microsoft.Office.Interop.Outlook;
  using OpenPop.Pop3.Exceptions;

  public partial class StartUp : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      //from.SelectedDate = DateTime.Now;
      //to.SelectedDate = DateTime.Now;
    }
    private static DataTable InitializeDataTable()
    {
      DataTable dt = new DataTable("Inbox");
      dt.Columns.Add("No", typeof(int));
      dt.Columns.Add("Date", typeof(string));
      dt.Columns.Add("Sender Email Address", typeof(string));
      dt.Columns.Add("Subject", typeof(string));
      dt.Columns.Add("Sender Name", typeof(string));
      dt.Columns.Add("Body Format", typeof(string));
      return dt;
    }

    protected void Recieve_Email_Click(object sender, EventArgs e)
    {
      try
      {
        Outlook._Application _app = new Outlook.Application();
        Outlook._NameSpace _ns = _app.GetNamespace("MAPI");
        Outlook.MAPIFolder inbox = _ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);
        _ns.SendAndReceive(true);

        DataTable dt = InitializeDataTable();

        string from1 = from.Text;
        string to1 = to.Text;

        DateTime dtFr =
            DateTime.ParseExact(from1, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        DateTime dtTo =
           DateTime.ParseExact(to1, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        int count = 0;
        foreach (Outlook.MailItem item in inbox.Items)
        {
          if (dtFr <= item.SentOn && item.SentOn < dtTo.AddDays(1))
          {
            count++;
            dt.Rows.Add(new object[] {count,
                                      item.SentOn.ToLongDateString() + " " + item.SentOn.ToLongTimeString(),
                                      item.SenderEmailAddress,
                                      item.Subject,
                                      item.SenderName         ,
                                      item.Body
                                   });
          }
        }

        dataGrid.DataSource = dt;
        dataGrid.DataBind();
      }
      catch (Exception ex)
      {
        ScriptManager.RegisterClientScriptBlock(
            this,
            typeof(Page),
            "TScript",
             "alert('There is an error when reading email!')",
            true);

      }
    }
    //-------------------------------------------------------------------->
    //   Here is an example of how you can download all messages from one POP3 server.It takes the various connection settings as arguments.

    /// <summary>
    /// Example showing:
    ///  - how to fetch all messages from a POP3 server
    /// </summary>
    /// <param name="hostname">Hostname of the server. For example: pop3.live.com</param>
    /// <param name="port">Host port to connect to. Normally: 110 for plain POP3, 995 for SSL POP3</param>
    /// <param name="useSsl">Whether or not to use SSL to connect to server</param>
    /// <param name="username">Username of the user on the server</param>
    /// <param name="password">Password of the user on the server</param>
    /// <returns>All Messages on the POP3 server</returns>
    public static List<OpenPop.Mime.Message> FetchAllMessages(string hostname, int port, bool useSsl, string username, string password)
    {
      // The client disconnects from the server when being disposed
      using (Pop3Client client = new Pop3Client())
      {
        // Connect to the server
        client.Connect(hostname, port, useSsl);

        // Authenticate ourselves towards the server
        client.Authenticate(username, password);

        // Get the number of messages in the inbox
        int messageCount = client.GetMessageCount();

        // We want to download all messages
        List<OpenPop.Mime.Message> allMessages = new List<OpenPop.Mime.Message>(messageCount);

        // Messages are numbered in the interval: [1, messageCount]
        // Ergo: message numbers are 1-based.
        // Most servers give the latest message the highest number
        for (int i = messageCount; i > 0; i--)
        {
          allMessages.Add(client.GetMessage(i));
        }

        // Now return the fetched messages
        return allMessages;
      }
    }


    //------------------------------------------------------------------->
    // http://hpop.sourceforge.net/
    protected void Recieve_Email_Click_Only_Pop_abv(object sender, EventArgs e)
    {
      // Disable buttons while working
      //connectAndRetrieveButton.Enabled = false;
      //uidlButton.Enabled = false;
      //progressBar.Value = 0;
      Pop3Client pop3Client = new Pop3Client();
      try
      {
        //if (pop3Client.Connected)
        //  pop3Client.Disconnect();
        //pop3Client.Connect(popServerTextBox.Text, int.Parse(portTextBox.Text), useSslCheckBox.Checked);
        pop3Client.Connect("pop3.abv.bg", 995, true);

        //pop3Client.Authenticate(loginTextBox.Text, passwordTextBox.Text);
        pop3Client.Authenticate("test.stanev@abv.bg", "test.stanev2801");
        int count = pop3Client.GetMessageCount();
        //totalMessagesTextBox.Text = count.ToString();
        //messageTextBox.Text = "";
        //messages.Clear();
        //listMessages.Nodes.Clear();
        //listAttachments.Nodes.Clear();
        DataTable dt = InitializeDataTable();
        int success = 0;
        int fail = 0;
        int countNum = 1;
        for (int i = count; i >= 1; i -= 1)
        {
          // Check if the form is closed while we are working. If so, abort
          //if (IsDisposed)
          //  return;

          // Refresh the form while fetching emails
          // This will fix the "Application is not responding" problem
          //Application.DoEvents();
       

          try
          {
            OpenPop.Mime.Message message = pop3Client.GetMessage(i);
            string strBody = String.Empty;
            if ((message.MessagePart.Body != null)){
               strBody = System.Text.Encoding.UTF8.GetString(message.MessagePart.Body);
            }
           

            dt.Rows.Add(new object[] {countNum,
                                      message.Headers.DateSent.ToString(),
                                      message.Headers.From.Address,
                                      message.Headers.Subject,
                                      message.Headers.From.DisplayName,
                                      strBody
                                   });

            dataGrid.DataSource = dt;
            dataGrid.DataBind();

            // Add the message to the dictionary from the messageNumber to the Message
            // messages.Add(i, message);

            // Create a TreeNode tree that mimics the Message hierarchy
            //  TreeNode node = new TreeNodeBuilder().VisitMessage(message);

            // Set the Tag property to the messageNumber
            // We can use this to find the Message again later
            // node.Tag = i;

            // Show the built node in our list of messages
            // listMessages.Nodes.Add(node);

            success++;
          }
          catch (Exception ex)
          {
            DefaultLogger.Log.LogError(
              "TestForm: Message fetching failed: " + ex.Message + "\r\n" +
              "Stack trace:\r\n" +
              ex.StackTrace);
            fail++;
          }

          // progressBar.Value = (int)(((double)(count - i) / count) * 100);
        }

        // MessageBox.Show(this, "Mail received!\nSuccesses: " + success + "\nFailed: " + fail, "Message fetching done");

        //if (fail > 0)
        //{
        //  MessageBox.Show(this,
        //                  "Since some of the emails were not parsed correctly (exceptions were thrown)\r\n" +
        //                  "please consider sending your log file to the developer for fixing.\r\n" +
        //                  "If you are able to include any extra information, please do so.",
        //                  "Help improve OpenPop!");
        //}
      }
      catch (InvalidLoginException)
      {
        return;
        //MessageBox.Show(this, "The server did not accept the user credentials!", "POP3 Server Authentication");
      }
      //catch (PopServerNotFoundException)
      //{
      //  MessageBox.Show(this, "The server could not be found", "POP3 Retrieval");
      //}
      //catch (PopServerLockedException)
      //{
      //  MessageBox.Show(this, "The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
      //}
      //catch (LoginDelayException)
      //{
      //  MessageBox.Show(this, "Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
      //}
      //catch (Exception e)
      //{
      //  MessageBox.Show(this, "Error occurred retrieving mail. " + e.Message, "POP3 Retrieval");
      //}
      //finally
      //{
      //  // Enable the buttons again
      //  connectAndRetrieveButton.Enabled = true;
      //  uidlButton.Enabled = true;
      //  progressBar.Value = 100;
      //}
    }
    protected void Recieve_Email_Click_Pop_IMAP(object sender, EventArgs e)
    {
      try
      {
        // for Gmail
        IEmailClient imapClient = EmailClientFactory.GetClient(EmailClientEnum.POP3);
        imapClient.Connect("imap.gmail.com", "test.stanev@gmail.com", "test.stanev2801", 993, true);
        imapClient.SetCurrentFolder("INBOX");

        // I assume that 5 is the last "ID" readed by my client. 
        // If I want to read all messages i use "ImapClient.LoadMessages();"
        // to take min of UI count and messages.Count
        int cMail = int.Parse(CountMail.Text);
       // int msgCount = imapClient.Messages.Count;
      //  int minCount = Math.Min(cMail, msgCount);
        imapClient.LoadRecentMessages(cMail);


        DataTable dt = InitializeDataTable();
        // To read all my messages loaded:
        int count = 0;
        //for (int i = 0; i < ImapClient.Messages.Count; i++)
        for (int i = 0; i < cMail; i++)
        {
          IEmail msm = (IEmail)imapClient.Messages[i];
          // Load all infos include attachments
          msm.LoadInfos();
          count++;
          dt.Rows.Add(new object[] {count,
                                      msm.Date.ToString(),
                                      msm.From[0],
                                      msm.Subject,
                                      ""        ,
                                      msm.TextBody
                                   });
          //Console.WriteLine(msm.Date.ToString() + " - " + msm.From[0] + " - " +
          //                  msm.Subject + " - " + msm.TextBody + msm.Attachments.Count);
        }

        dataGrid.DataSource = dt;
        dataGrid.DataBind();

      }
      catch (Exception ex)
      {
        ScriptManager.RegisterClientScriptBlock(
                                               this,
                                               typeof(Page),
                                               "TScript",
                                                "alert('There is an error when reading email!')",
                                               true);
      }

    }
  }
}