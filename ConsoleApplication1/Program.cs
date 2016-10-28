using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectToDB
{
  //Using.In the annotated C# language specification, we are advised to use the "using" statement when creating any object that implements the interface IDisposable.
  class Program
  {

    //"User=SYSDBA;Password=masterkey;Database=D:\Gen 2006\Sklad_2\SKLAD.GDB;DataSource=localhost;Port=3050;Dialect=3;Charset=NONE;Role=;Connection lifetime=0;Connection timeout=15;Pooling=True;Packet Size=8192;Server Type=0"
    //Data Source = @"(localdb)\MSSQLLocalDB;Initial Catalog = NORTHWND; Persist Security Info=True;User ID = Stani; Password=***********";
    static void Main()
    {
      string conectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = NORTHWND; Persist Security Info=True;User ID = Stani; Password=Stani";

      using (SqlConnection con = new SqlConnection(conectionString))
      {
        con.Open();
        using (SqlCommand command = new SqlCommand("SELECT CategoryID,CategoryName, Description FROM Categories", con))

        using (SqlDataReader reader = command.ExecuteReader())
        {
          while (reader.Read())
          {
            Console.WriteLine("{0} {1} {2}",
                              reader.GetInt32(0), (string)reader.GetValue(1), "|"+reader.GetValue(2));

          }
        }
      }
      // second example
    }
  }
}
