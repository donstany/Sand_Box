namespace SoftServe_IT_Academy.Animals
{
  using System;
  using System.Collections.Generic;
  using System.Text;

  public class Petshop
  {
    // simulate in-memory database
    private static IList<Pet> pets = new List<Pet>();

    // this method is static because here is assumed that exist only one instantion of PetShop
    public static void AddPet(Pet pet)
    {
      pets.Add(pet);
      Console.WriteLine($"Pet with name {pet.Name} sucessfuly added!");
    }
    public static string IntorduceAll()
    {
      StringBuilder sb = new StringBuilder();
      foreach (Pet pet in pets)
      {
        sb.AppendLine(pet.Introduce());
      }
      return sb.ToString();
    }
  }
}
