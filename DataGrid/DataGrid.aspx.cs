using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace DataGrid
{
  public partial class DataGrid : System.Web.UI.Page
  {
    SqlDataAdapter da;
    // can use DataTable
    DataSet ds = new DataSet();
    SqlCommand cmd = new SqlCommand();
    SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!Page.IsPostBack)
      {
        BindData();
      }
    }
    public void BindData()
    {
      //con = new SqlConnection(ConfigurationManager.AppSettings["connect"].ToString());
      string conectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = NORTHWND; Persist Security Info=True;User ID = Stani; Password=Stani";

      con = new SqlConnection(conectionString);
      cmd.CommandText = "Select * from Employees";
      cmd.Connection = con;
      da = new SqlDataAdapter(cmd);
      da.Fill(ds);
      con.Open();
      cmd.ExecuteNonQuery();
      Grid.DataSource = ds;
      Grid.DataBind();
      con.Close();
    }

    protected void Grid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
      Grid.CurrentPageIndex = e.NewPageIndex;
      BindData();
    }

    protected void Grid_EditCommand(object source, DataGridCommandEventArgs e)
    {
      Grid.EditItemIndex = e.Item.ItemIndex;
      BindData();
    }

    protected void Grid_CancelCommand(object source, DataGridCommandEventArgs e)
    {
      Grid.EditItemIndex = -1;
      BindData();
    }

    protected void Grid_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
      //con = new SqlConnection(ConfigurationManager.AppSettings["connect"].ToString());
      string conectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = NORTHWND; Persist Security Info=True;User ID = Stani; Password=Stani";
      con = new SqlConnection(conectionString);
      cmd.Connection = con;
      int EmpId = (int)Grid.DataKeys[(int)e.Item.ItemIndex];
      cmd.CommandText = "Delete from Employees where EmployeeId=" + EmpId;
      cmd.Connection.Open();
      cmd.ExecuteNonQuery();
      cmd.Connection.Close();
      Grid.EditItemIndex = -1;
      BindData();
    }

    protected void Grid_UpdateCommand(object source, DataGridCommandEventArgs e)
    {
      //con = new SqlConnection(ConfigurationManager.AppSettings["connect"]);
      string conectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = NORTHWND; Persist Security Info=True;User ID = Stani; Password=Stani";
      con = new SqlConnection(conectionString);

      cmd.Parameters.Add("@EmpId"  , SqlDbType.Int).Value   = ((TextBox)e.Item.Cells[0].Controls[0]).Text;
      cmd.Parameters.Add("@F_Name" , SqlDbType.Char).Value =  ((TextBox)e.Item.Cells[1].Controls[0]).Text;
      cmd.Parameters.Add("@L_Name" , SqlDbType.Char).Value =  ((TextBox)e.Item.Cells[2].Controls[0]).Text;
      cmd.Parameters.Add("@City"   , SqlDbType.Char).Value =  ((TextBox)e.Item.Cells[3].Controls[0]).Text;
      cmd.Parameters.Add("@HomePhone", SqlDbType.Char).Value =  ((TextBox)e.Item.Cells[4].Controls[0]).Text;
      cmd.Parameters.Add("@HireDate", SqlDbType.DateTime).Value = DateTime.Now.ToString();
      cmd.CommandText = "Update Employees set FirstName=@F_Name,LastName=@L_Name,City=@City,HomePhone=@HomePhone,HireDate=@HireDate where EmployeeId=@EmpId";
      cmd.Connection = con;
      cmd.Connection.Open();
      cmd.ExecuteNonQuery();
      cmd.Connection.Close();
      Grid.EditItemIndex = -1;
      BindData();
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
      SqlConnection con;
      //con = new SqlConnection(ConfigurationManager.AppSettings["connect"]);
      string conectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = NORTHWND; Persist Security Info=True;User ID = Stani; Password=Stani";

      con = new SqlConnection(conectionString);
      con.Open();
      SqlCommand cmd;
      cmd = new SqlCommand("SET IDENTITY_INSERT Employees ON Insert into Employees (EmployeeId,FirstName,LastName,City,HomePhone,HireDate) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "') SET IDENTITY_INSERT Employees OFF", con);
      cmd.ExecuteNonQuery();
      con.Close();
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
      TextBox1.Text = "";
      TextBox2.Text = "";
      TextBox3.Text = "";
      TextBox4.Text = "";
      TextBox5.Text = "";
      TextBox6.Text = "";
    }

    protected void btnOk_Click(object sender, EventArgs e)
    {
      BindData1();
    }

    public void BindData1()
    {
      //con = new SqlConnection(ConfigurationManager.AppSettings["connect"]);
      string conectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = NORTHWND; Persist Security Info=True;User ID = Stani; Password=Stani";
      con = new SqlConnection(conectionString);

      cmd.CommandText = "Select * from Employees";
      cmd.Connection = con;
      da = new SqlDataAdapter(cmd);
      da.Fill(ds);
      con.Open();
      cmd.ExecuteNonQuery();
      Grid1.DataSource = ds;
      Grid1.DataBind();
      con.Close();
    }



  }
}
