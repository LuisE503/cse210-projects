using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") 
    { }

    public override void RunActivity()
    {
        DisplayStartingMessage();
        
        Console.Write("Enter the duration in seconds: ");
        SetDuration(int.Parse(Console.ReadLine()));

        Console.WriteLine("Prepare to begin...");
        PauseWithSpinner(3);

        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            System.Threading.Thread.Sleep(4000);
            Console.WriteLine("Breathe out...");
            System.Threading.Thread.Sleep(4000);
        }

        DisplayEndingMessage();
    }
}
