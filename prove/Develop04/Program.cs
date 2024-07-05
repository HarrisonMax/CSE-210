using System;
// This is what my brother in law told me to do for this activity
namespace WellnessActivitiesProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Wellness Activities Program!\n");

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BreathingActivity breathingActivity = new BreathingActivity();
                        ExecuteActivity(breathingActivity);
                        break;
                    case "2":
                        ReflectionActivity reflectionActivity = new ReflectionActivity();
                        ExecuteActivity(reflectionActivity);
                        break;
                    case "3":
                        ListingActivity listingActivity = new ListingActivity();
                        ExecuteActivity(listingActivity);
                        break;
                    case "4":
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 4.\n");
                        break;
                }
            }
        }

        static void ExecuteActivity(Activity activity)
        {
            activity.SetDuration();
            activity.StartActivity();
            activity.PerformActivity();
            activity.EndActivity();
        }
    }
}
