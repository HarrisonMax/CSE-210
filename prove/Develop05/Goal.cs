public class Goal
{
    protected int _points;
    protected bool _completed;
    protected string _goal;

    public Goal(string goal, int points)
    {
        _goal = goal;
        _points = points;
        _completed = false;
    }

    public virtual void DisplayGoal()
    {
        string status = _completed ? "[X]" : "[ ]";
        Console.WriteLine($"{status} {_goal} - {_points} points");
    }

    public void MarkComplete()
    {
        _completed = true;
    }

    public virtual void RecordAnEvent()
    {
        // Implementation in derived classes
    }
}


