using System;

public class Program
{
    public static void Main()
    {
        Menu menu = new Menu();
        GoalTracker tracker = new GoalTracker();

        while (true)
        {
            menu.DisplayMainMenu();
            int mainChoice = int.Parse(Console.ReadLine());

            switch (mainChoice)
            {
                case 1:
                    Console.WriteLine("Choose goal type:");
                    Console.WriteLine("1. Simple Goal");
                    Console.WriteLine("2. Eternal Goal");
                    Console.WriteLine("3. Tracked Goal");
                    int goalTypeChoice = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter goal description:");
                    string goalDescription = Console.ReadLine();
                    Console.WriteLine("Enter points for completing the goal:");
                    int points = int.Parse(Console.ReadLine());

                    Goal goal = CreateGoal(goalTypeChoice, goalDescription, points);
                    tracker.AddGoal(goal);
                    break;

                case 2:
                    tracker.DisplayGoals();
                    break;

                case 3:
                    tracker.Save();
                    break;

                case 4:
                    tracker.Load();
                    break;

                case 5:
                    Console.WriteLine("Exiting program.");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    private static Goal CreateGoal(int goalTypeChoice, string goalDescription, int points)
    {
        switch (goalTypeChoice)
        {
            case 1: 
                return new SimpleGoal(goalDescription, points);

            case 2: 
                return new EternalGoal(goalDescription, points);

            case 3: 
                Console.WriteLine("Enter maximum repetitions:");
                int maxRepetitions = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter bonus points:");
                int bonusPoints = int.Parse(Console.ReadLine());
                return new ChecklistGoal(goalDescription, points, maxRepetitions, bonusPoints);

            default:
                throw new ArgumentException("Invalid goal type choice.");
        }
    }
}