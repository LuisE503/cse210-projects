using System;

public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _requiredTimes;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int requiredTimes, int bonusPoints)
        : base(name, description, points)
    {
        _timesCompleted = 0;
        _requiredTimes = requiredTimes;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        _timesCompleted++;
        int pointsEarned = GetPoints();

        if (_timesCompleted >= _requiredTimes)
        {
            pointsEarned += _bonusPoints;
            Console.WriteLine($"Congratulations! You've completed the goal and earned a bonus of {_bonusPoints} points!");
        }

        Console.WriteLine($"You've earned {pointsEarned} points.");
    }

    public override bool IsCompleted()
    {
        return _timesCompleted >= _requiredTimes;
    }

    public override string GetDetails()
    {
        string status = IsCompleted() ? "[X]" : "[ ]";
        return $"{status} {base.GetDetails()} (Completed {_timesCompleted}/{_requiredTimes} times)";
    }

    public int GetRequiredTimes() => _requiredTimes;
    public int GetBonusPoints() => _bonusPoints;
}
