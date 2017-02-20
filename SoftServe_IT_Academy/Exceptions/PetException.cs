namespace SoftServe_IT_Academy.Exceptions
{
  using System;
  public class PetException : Exception
  {
    private const string MessageException = "Please enter pet name: ";
    public PetException(string message = MessageException)
      : base(message)
    {
    }
  }
}
