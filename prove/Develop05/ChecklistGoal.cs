public class ChecklistGoal : Goal
{
    private int _maxRepetitions;
    private int _completedRepetitions;
    private int _bonusPoints;

    public ChecklistGoal(string goal, int points, int maxRepetitions, int bonusPoints) : base(goal, points)
    {
        _maxRepetitions = maxRepetitions;
        _bonusPoints = bonusPoints;
        _completedRepetitions = 0;
    }

    public override void DisplayGoal()
    {
        string status = _completed ? $"Completed {_completedRepetitions}/{_maxRepetitions} times" : $"[ ] {_completedRepetitions}/{_maxRepetitions}";
        Console.WriteLine($"{status} {_goal} - {_points} points");
    }

    public override void RecordAnEvent()
    {
        if (!_completed)
        {
            _completedRepetitions++;
            if (_completedRepetitions == _maxRepetitions)
            {
                _completed = true;
            }
        }
        else
        {
            Console.WriteLine("Goal already completed.");
        }
    }
}