using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Great! You've earned {GetPoints()} points.");
    }

    public override bool IsCompleted()
    {
        return false; 
    }

    public override string GetDetails()
    {
        return $"[∞] {base.GetDetails()}";
    }
}
