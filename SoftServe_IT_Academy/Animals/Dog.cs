namespace SoftServe_IT_Academy.Animals
{
  public class Dog : Pet
  {
    public Dog(string name, string breed) 
      : base(name, breed)
    {
    }

    public override string Introduce()
    {
      return string.Format(base.Introduce(), this.Name, this.Breed, this.GetType().Name.ToLower());
    }
  }
}
