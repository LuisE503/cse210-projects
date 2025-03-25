using System;

public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void SetDuration(int duration)
    {
        _duration = duration;
    }

    public int GetDuration()
    {
        return _duration;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine(_description);
        Console.WriteLine($"How many seconds would you like to do this activity?");
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine($"Good job! You have completed {_duration} seconds of the {_name}.");
        PauseWithSpinner(3);
    }

    public void PauseWithSpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        while (DateTime.Now < endTime)
        {
            Console.Write("|");
            System.Threading.Thread.Sleep(300);
            Console.Write("\b \b");
            Console.Write("/");
            System.Threading.Thread.Sleep(300);
            Console.Write("\b \b");
            Console.Write("-");
            System.Threading.Thread.Sleep(300);
            Console.Write("\b \b");
            Console.Write("\\");
            System.Threading.Thread.Sleep(300);
            Console.Write("\b \b");
        }
    }

    public abstract void RunActivity();
}
