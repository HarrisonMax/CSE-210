using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // using System.Collections.Generic;
        // List<int> numbers;
        // numbers = new List<int>();
        // List<int> numbers = new List<int>();
        // List<string> words = new List<string>();
        // words.Add("phone");
        // words.Add("keyboard");
        // words.Add("mouse");
        // Console.WriteLine(words.Count);
        List<int> numbers = new List<int>();
        int inputNumber = -1;

        while (inputNumber != 0)
        {
            Console.Write("Enter a list of numbers, type 0 when finished.");           
            inputNumber = int.Parse(Console.ReadLine());

            if (inputNumber != 0)
            {
                numbers.Add(inputNumber);
            }

        }
        int sum = 0;

        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is : {sum}");


        int largest = numbers[0];

        foreach (int number in numbers)
        {
            if (number > largest)
            {
                largest = number;
            }
        }
        Console.WriteLine($"The largest number is: {largest}");
        // Console.WriteLine("Hello Prep4 World!");
    }
}