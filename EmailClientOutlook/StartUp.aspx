<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StartUp.aspx.cs" Inherits="EmailClientOutlook.StartUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Синхронизиране с email</title>
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
  <link rel="stylesheet" href="/resources/demos/style.css">
  <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
  <script>
    $(function () {
      var dateFormat = "mm/dd/yy",
        from = $("#from")
          .datepicker({
            defaultDate: "+1w",
            changeMonth: true,
            numberOfMonths: 2
          })
          .on("change", function () {
            to.datepicker("option", "minDate", getDate(this));
          }),
        to = $("#to").datepicker({
          defaultDate: "+1w",
          changeMonth: true,
          numberOfMonths: 2
        })
        .on("change", function () {
          from.datepicker("option", "maxDate", getDate(this));
        });

      function getDate(element) {
        var date;
        try {
          date = $.datepicker.parseDate(dateFormat, element.value);
        } catch (error) {
          date = null;
        }

        return date;
      }
    });
  </script>
  <style type="text/css">
    .auto-style1 {
      width: 380px;
    }
  </style>
</head>
<body>
  <form id="form1" runat="server">
    <table border="1"  style="border-collapse: collapse;">
      <tr>
        <td>
          <asp:Button ID="Button1" runat="server" Text="Recieve mail" OnClick="Recieve_Email_Click" /></td>
        <td class="auto-style1" style="background-color:orange">
          <asp:Label Text="Синхронизиране с Outlook" runat="server" /></td>
      </tr>
      <tr>
        <td>
          <asp:Button ID="Button3" runat="server" Text="Recieve mail" OnClick="Recieve_Email_Click_Only_Pop_abv" /></td>
        <td class="auto-style1" style="background-color:orange">
          <asp:Label Text="Синхронизиране с Abv.bg" runat="server" /></td>
      </tr>

      <%--Comment--%>
    <asp:Label ID="Label1" runat="server" Text="From" AssociatedControlID="from"></asp:Label>
    <asp:TextBox ID="from" runat="server" name="from"></asp:TextBox>

    <label for="to">To</label>
    <asp:TextBox ID="to" runat="server" name="from"> </asp:TextBox>
  
    </table>
        <table border="1"  style="border-collapse: collapse;">
      <tr>
        <td>
          <asp:Button ID="Button2" runat="server" Text="Recieve mail" OnClick="Recieve_Email_Click_Pop_IMAP" /></td>
        <td style="background-color:aquamarine">
          <asp:Label Text="Синхронизиране сървър през IMAP - безплатна библиотека от разработчици" runat="server" /></td>
                <td style="background-color:aquamarine">
          <asp:TextBox ID="CountMail" runat="server" /></td>
         <td><asp:Label Text="брой мейли" runat="server" /></td>
      </tr>
    </table>
    <div></div>
    <asp:GridView ID="dataGrid" runat="server" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="Horizontal">
      <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
      <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
      <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
      <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
      <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
      <SortedAscendingCellStyle BackColor="#F1F1F1" />
      <SortedAscendingHeaderStyle BackColor="#594B9C" />
      <SortedDescendingCellStyle BackColor="#CAC9C9" />
      <SortedDescendingHeaderStyle BackColor="#33276A" />
    </asp:GridView>
    <div>
    </div>
  </form>
</body>
</html>
