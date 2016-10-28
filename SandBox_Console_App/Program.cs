using SandBox_Console_App;
using System;

public class Program
{
    public struct Rectangle { public double Length { get; set; } public double Width { get; set; } }
    public static void Main()
    {

        Rectangle r1, r2;
        r1 = new Rectangle { Length = 10.0, Width = 20.0 };
        r2 = r1;
        r2.Length = 30;
        Console.WriteLine(r1.Length);

        //Rectangle o = new Rectangle() { Length = 10, Width = 20f };
        //Rectangle o1 = null;
        //Triangle o=new Triangle();

        //Polygon p = (o != null) ? o as Polygon : (Polygon)o;
        //Console.WriteLine();   
    }
}