using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int totalScore = 0;

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nEternal Quest Program");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(goals);
                    break;
                case "2":
                    totalScore += RecordEvent(goals);
                    break;
                case "3":
                    ShowGoals(goals, totalScore);
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void CreateGoal(List<Goal> goals)
    {
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("What type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter the description: ");
        string description = Console.ReadLine();
        Console.Write("Enter the points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                goals.Add(new SimpleGoal(name, description, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("Enter the number of required completions: ");
                int requiredTimes = int.Parse(Console.ReadLine());
                Console.Write("Enter the bonus points: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, description, points, requiredTimes, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid type.");
                break;
        }
    }

    static int RecordEvent(List<Goal> goals)
    {
        Console.WriteLine("Select a goal to record an event:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetails()}");
        }

        int choice = int.Parse(Console.ReadLine()) - 1;
        goals[choice].RecordEvent();
        return goals[choice].GetPoints();
    }

    static void ShowGoals(List<Goal> goals, int totalScore)
    {
        Console.WriteLine("\nGoals:");
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.GetDetails());
        }
        Console.WriteLine($"\nTotal Score: {totalScore}");
    }
}
