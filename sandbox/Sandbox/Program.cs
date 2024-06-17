using System;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");
        
        Circle myCircle = new Circle(10);
        Console.WriteLine($"{myCircle.GetArea()}");

        Circle unitCircle = new Circle(1);
        Console.WriteLine($"{unitCircle.GetCircumference()}");
        Console.WriteLine($"{unitCircle.GetDiameter()}");
    }


}