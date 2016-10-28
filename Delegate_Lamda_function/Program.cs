namespace Delegate_Lamda_function
{
  delegate double MathAction(double num);
  class Delegate_Lamda_function
  {
    // 3. Regular method that matches signature:
    static double DoubleD(double input)
    {
      return input * 2;
    }
    static double TrippleD(double input)
    {
      return input * 3;
    }

    static void Main()
    {
      // 1.Instatiate delegate with anonymous method
      MathAction ma = delegate (double input)
      {
        return input * input;
      };

      double square = ma(5);

      System.Console.WriteLine("square: {0}", square);

      //--------------------------------------------------->
      //2. Instantiate delegate with lambda expression
      MathAction ma2 = s => s * s * s;
      double cube = ma2(3);
      System.Console.WriteLine("square1: {0}", cube);

      //--------------------------------------------------->
      //3. Instantiate delegate with named method: Point declaration of MathAction to named method
      MathAction ma3 = DoubleD;
      ma3 += TrippleD;

      // Invoke delegate ma:
   


    }
  }
}
