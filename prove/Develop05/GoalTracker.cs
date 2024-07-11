using System;
using System.Collections.Generic;

public class GoalTracker
{
    private List<Goal> _goals;

    public GoalTracker()
    {
        _goals = new List<Goal>();
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void Save()
    {
        Console.WriteLine("Goals saved successfully.");
    }

    public void Load()
    {
        Console.WriteLine("Goals loaded successfully.");
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Current Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.Write($"[{i + 1}] ");
            _goals[i].DisplayGoal();
        }
    }

    public void MarkGoalComplete(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            _goals[goalIndex].MarkComplete();
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            _goals[goalIndex].RecordAnEvent();
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }
}