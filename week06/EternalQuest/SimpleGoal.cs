using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) 
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Great job! You've earned {GetPoints()} points.");
    }

    public override bool IsCompleted()
    {
        return _isComplete;
    }

    public override string GetDetails()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return $"{status} {base.GetDetails()}";
    }
}
