using System;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Sandbox World!");
        
        Circle myCircle = new Circle(10);
        Console.WriteLine($"{myCircle.GetArea()}");
    }
}