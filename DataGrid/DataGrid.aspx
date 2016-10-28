<%--http://www.c-sharpcorner.com/uploadfile/anjudidi/example-of-datagrid-in-asp-net/--%>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataGrid.aspx.cs" Inherits="DataGrid.DataGrid" %>

<!DOCTYPE html>
<form id="form1" runat="server">
  <div>
    <asp:datagrid id="Grid" runat="server" pagesize="5" allowpaging="True" datakeyfield="EmployeeID"
      autogeneratecolumns="False" cellpadding="4" forecolor="#333333" gridlines="None" onpageindexchanged="Grid_PageIndexChanged" oncancelcommand="Grid_CancelCommand"
      ondeletecommand="Grid_DeleteCommand" oneditcommand="Grid_EditCommand" onupdatecommand="Grid_UpdateCommand">
    <Columns>
      <asp:BoundColumn HeaderText ="EmployeeID"   DataField="EmployeeID"></asp:BoundColumn>
      <asp:BoundColumn HeaderText ="FirstName"    DataField="FirstName" ></asp:BoundColumn>
      <asp:BoundColumn HeaderText ="LastName"     DataField="LastName"  ></asp:BoundColumn>
      <asp:BoundColumn HeaderText ="City"         DataField="City"      ></asp:BoundColumn>
      <asp:BoundColumn HeaderText ="HomePhone"    DataField="HomePhone"   ></asp:BoundColumn>
      <asp:BoundColumn HeaderText ="HireDate"     DataField="HireDate"  ></asp:BoundColumn>
      <asp:EditCommandColumn  HeaderText="Edit"   EditText ="Edit"   CancelText="Cancel" UpdateText="Update"></asp:EditCommandColumn>
      <asp:ButtonColumn Text="Delete" CommandName="Delete" HeaderText="Delete" ></asp:ButtonColumn>
    </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Mode="NumericPages" />
        <AlternatingItemStyle BackColor="White" />
        <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />

       
</asp:datagrid>

    <table>
      <tr>
        <td>
          <asp:label id="lblEmpId" runat="server" text="EmployeeIDLb"></asp:label>
          <asp:textbox id="TextBox1" runat="server"></asp:textbox>
        </td>
        <td>
          <asp:label id="lblfname" runat="server" text="FirstNameLb"></asp:label>
          <asp:textbox id="TextBox2" runat="server"></asp:textbox>
        </td>
        <td>
          <asp:label id="lblLname" runat="server" text="LastNameLb"></asp:label>
          <asp:textbox id="TextBox3" runat="server"></asp:textbox>
        </td>
        <td>
          <asp:label id="lblCity" runat="server" text="CityLb"></asp:label>
          <asp:textbox id="TextBox4" runat="server"></asp:textbox>
        </td>
        <td>
          <asp:label id="lblHomePhone" runat="server" text="HomePhone"></asp:label>
          <asp:textbox id="TextBox5" runat="server"></asp:textbox>
        </td>
        <td>
          <asp:label id="lblEmpHireDate" runat="server" text="HireDate"></asp:label>
          <asp:textbox id="TextBox6" runat="server"></asp:textbox>
        </td>
      </tr>
    </table>
    <asp:button id="btnsubmit" runat="server" text="Submit" onclick="btnsubmit_Click" />
    <asp:button id="btnReset" runat="server" text="Reset" onclick="btnReset_Click" />
    <asp:button id="btnOk" runat="server" text="OK" onclick="btnOk_Click" />
  </div>

  <hr />
  <div>
    <asp:datagrid id="Grid1" runat="server" pagesize="5" allowpaging="True" autogeneratecolumns="False" cellpadding="4" forecolor="#333333" gridlines="None">
             <Columns>
                 <asp:BoundColumn HeaderText="EmployeeID" DataField="EmployeeID"></asp:BoundColumn>
                 <asp:BoundColumn HeaderText="FirstName"  DataField="FirstName"></asp:BoundColumn>
                 <asp:BoundColumn HeaderText="LastName"   DataField="LastName"></asp:BoundColumn>
                 <asp:BoundColumn HeaderText="City"       DataField="City"   ></asp:BoundColumn>
                 <asp:BoundColumn HeaderText="HomePhone"  DataField="HomePhone" ></asp:BoundColumn>
                 <asp:BoundColumn HeaderText="HireDate"   DataField="HireDate" > </asp:BoundColumn>
             </Columns>
                 <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                 <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                 <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Mode="NumericPages" />
                 <AlternatingItemStyle BackColor="White" />
                 <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />
                 <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
         </asp:datagrid>
  </div>
</form>
</body>
</html>
