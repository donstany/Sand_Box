namespace SoftServe_IT_Academy.Animals
{
  public class Cat : Pet
  {
    public Cat(string name, string breed)
      : base(name, breed)
    {
    }

    public override string Introduce()
    {
      return $"I’m {this.Name} of {this.Breed}. I’m a {this.GetType().Name.ToLower()} .";
    }
  }
}