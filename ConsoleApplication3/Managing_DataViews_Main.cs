using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
  class Managing_DataViews_Main
  {
    static void Main(string[] args)
    {
      // Assumes connection is a valid SqlConnection to Northwind.
      // Create a Connection, DataAdapters, and a DataSet.
      SqlDataAdapter custDA = new SqlDataAdapter(
  "SELECT CustomerID, CompanyName FROM Customers", connection);
      SqlDataAdapter orderDA = new SqlDataAdapter(
        "SELECT OrderID, CustomerID FROM Orders", connection);
      SqlDataAdapter ordDetDA = new SqlDataAdapter(
        "SELECT OrderID, ProductID, Quantity FROM [Order Details]", connection);
    }
  }
}
