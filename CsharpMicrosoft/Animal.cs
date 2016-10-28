using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CsharpMicrosoft
{
  // Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NORTHWND;Persist Security Info=True;User ID=Stani;Password=***********
  class Animal
  {
    private const string sqlConectionString = @"(localdb)\MSSQLLocalDB;Initial Catalog = NORTHWND; Persist Security Info=True;User ID = Stani; Password=Stani";

    public string Title { get; set; }
    public string FirstName { get; set; }
  
  private static IEnumerable<Animal> GetAnimals()/*(string sqlConectionString)*/
  {
    var animals = new List<Animal>();
    SqlConnection sqlConnection = new SqlConnection(sqlConectionString);

    sqlConnection.Open(); // important!
    using (sqlConnection)
    {
      SqlCommand sqlCommand = new SqlCommand("SELECT Title, FirstName FROM Employees", sqlConnection);
      using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
      {
        while (sqlDataReader.Read()) // important!
        {
          var animal = new Animal();
          animal.FirstName = (string)sqlDataReader["Name"];
          animal.Title = (string)sqlDataReader["ColorName"];
          animals.Add(animal);
        }
        
      }
    }
    return animals;
  }
  }

}
