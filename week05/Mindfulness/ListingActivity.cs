using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity() : base("Listing Activity", 
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") 
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
    }

    public override void RunActivity()
    {
        DisplayStartingMessage();
        
        Console.Write("Enter the duration in seconds: ");
        SetDuration(int.Parse(Console.ReadLine()));

        Console.WriteLine("Prepare to begin...");
        PauseWithSpinner(3);

        Random random = new Random();
        Console.WriteLine("\nPrompt:");
        Console.WriteLine(_prompts[random.Next(_prompts.Count)]);

        Console.WriteLine("\nStart listing items:");
        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        List<string> items = new List<string>();

        while (DateTime.Now < endTime)
        {
            Console.Write("Item: ");
            items.Add(Console.ReadLine());
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
        DisplayEndingMessage();
    }
}
