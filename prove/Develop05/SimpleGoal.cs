public class SimpleGoal : Goal
{
    public SimpleGoal(string goal, int points) : base(goal, points)
    {
    }

    public override void RecordAnEvent()
    {
        MarkComplete();
    }
}