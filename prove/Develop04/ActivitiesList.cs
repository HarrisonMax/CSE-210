using System;
using System.Collections.Generic;
using System.Threading;

namespace WellnessActivitiesProgram
{
    public class ListingActivity : Activity
    {
        private readonly string[] Prompts = {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life.")
        {
        }

        public override void PerformActivity()
        {
            string prompt = Prompts[new Random().Next(Prompts.Length)];
            Console.WriteLine($"\nThink about the prompt:\n{prompt}\n");
            PauseWithSpinner(5);
            Console.WriteLine("Start listing...");

            List<string> items = new List<string>();
            DateTime startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < Duration)
            {
                Console.Write("Enter an item (or press Enter to finish): ");
                string item = Console.ReadLine();
                if (!string.IsNullOrEmpty(item))
                {
                    items.Add(item);
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine($"\nYou listed {items.Count} items.");
        }
    }
}