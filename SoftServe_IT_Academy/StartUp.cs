namespace SoftServe_IT_Academy
{
  using Animals;
  using System;
  public class StartUp
  {
    public static void Main()
    {
      Dog sharo = new Dog("Sharo", "");
      Cat catya = new Cat("Katya", "I said Miauu Miau!");
      Dog rex = new Dog("Rex", "I said Bauuu Bauu Bauuu!");

      Petshop.AddPet(sharo);
      Petshop.AddPet(catya);
      Petshop.AddPet(rex);

      //Console.WriteLine(sharo.Introduce());
      //Console.WriteLine(catya.Introduce());
      //Console.WriteLine(rex.Introduce());
      try
      {
        Console.WriteLine(Petshop.IntorduceAll());
      }
      catch
      {

      }
      
    }
  }
}
