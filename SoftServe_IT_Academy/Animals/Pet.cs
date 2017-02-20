namespace SoftServe_IT_Academy.Animals
{
  using Exceptions;
  using Interfaces;
  public abstract class Pet : IBreedable
  {
    private string name;
    private string breed;
    protected Pet(string name, string breed)
    {
      this.Name = name;
      this.Breed = breed;
    }
    public string Name
    {
      get { return this.name; }
      private set
      {
        if (string.IsNullOrEmpty(value)) { throw new PetException(); };
        this.name = value;
      }
    }
    public string Breed
    {
      get { return this.breed; }
      private set
      {
        if (string.IsNullOrEmpty(value)) { throw new PetException(); }
        this.breed = value;
      }
    }

    public virtual string Introduce()
    {
      return "I’m {0} of {1}. I’m a {2} .";
    }

  }
}
