using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
  {
        //  string response = "yes";
        // // string colors = "orange";

        //  while (response == "yes")
        //  {
        //     Console.Write("Do you want to continue? ");
        //     response = Console.ReadLine();
        // }
        // do
        // {
        //     Console.Write("Do you want to continue?");
        //     response = Console.ReadLine();
        // }while (response == "yes");

        // for (int i = 0; i < 10; i++)
        // {
        //     Console.WriteLine(i);
        // }
        
        // foreach (string color in colors)
        // {
        //     Console.WriteLine(color);
        // }

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 11);
        int guessMagicNumber = -1;

        while (guessMagicNumber != magicNumber)
        {
            Console.WriteLine("What is your guess? ");
            guessMagicNumber = int.Parse(Console.ReadLine());
            
            if (guessMagicNumber < magicNumber)
            {
                Console.Write("your guess is too Low ");
            }
            else if (guessMagicNumber > magicNumber)
            {
                Console.Write("Your guess is too High");
            }
            else
            {
                Console.Write("You Guessed it!");
            }
        }

        
  }
}
