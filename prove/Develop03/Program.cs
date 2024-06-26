using System;

class Program
{
    static void Main(string[] args)
    {
        string scriptureText = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";

        Scripture scripture = new Scripture("John 3:16", scriptureText);

        do
        {
            scripture.Display();
            Console.WriteLine("\nPress Enter to hide a word or type 'quit' to exit.");
            string input = Console.ReadLine().Trim();

            if (input.ToLower() == "quit")
                break;

            bool wordHidden = scripture.HideRandomWord();

            if (!wordHidden)
            {
                Console.WriteLine("All words in the scripture are now hidden.");
                break;
            }

        } while (!scripture.AllWordsHidden());

        Console.WriteLine("Program ended. Press any key to exit.");
        Console.ReadKey();
    }
}