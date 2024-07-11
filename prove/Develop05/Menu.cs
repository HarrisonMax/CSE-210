
using System;

public class Menu
{
    public void DisplayMainMenu()
    {
        Console.WriteLine("Main Menu:");
        Console.WriteLine("1. Add Goal");
        Console.WriteLine("2. Display Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Exit");
    }

    public void DisplaySubMenu()
    {
        Console.WriteLine("Sub Menu:");
        Console.WriteLine("1. Mark Goal Complete");
        Console.WriteLine("2. Record Event");
        Console.WriteLine("3. Back to Main Menu");
    }
}