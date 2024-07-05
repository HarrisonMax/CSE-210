using System;
using System.Threading;

namespace WellnessActivitiesProgram
{
    public abstract class Activity
    {
        protected string Name { get; }
        protected string Description { get; }
        protected int Duration { get; set; }

        public Activity(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public void SetDuration()
        {
            while (true)
            {
                Console.Write($"Enter duration in seconds for {Name}: ");
                if (int.TryParse(Console.ReadLine(), out int duration) && duration > 0)
                {
                    Duration = duration;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Duration must be a positive integer.");
                }
            }
        }

        public void StartActivity()
        {
            Console.WriteLine($"\nStarting {Name}...");
            Console.WriteLine($"{Description}\n");
            Console.WriteLine("Prepare to begin in 5 seconds...");
            PauseWithSpinner(5);
        }

        public void EndActivity()
        {
            Console.WriteLine($"\nCongratulations! You've completed {Name} for {Duration} seconds.");
            PauseWithSpinner(3);
        }

        protected void PauseWithSpinner(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        public abstract void PerformActivity();
    }
}