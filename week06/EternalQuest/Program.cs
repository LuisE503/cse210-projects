using System;
using System.Collections.Generic;
using System.IO;

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
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
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
                    SaveGoals(goals, totalScore);
                    break;
                case "5":
                    (goals, totalScore) = LoadGoals();
                    break;
                case "6":
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
        Console.WriteLine("\n1. Simple Goal");
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
        Console.WriteLine("\nSelect a goal to record an event:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetDetails()}");
        }

        Console.Write("Enter the number of the goal: ");
        int choice = int.Parse(Console.ReadLine()) - 1;
        goals[choice].RecordEvent();
        return goals[choice].GetPoints();
    }

    static void ShowGoals(List<Goal> goals, int totalScore)
    {
        Console.WriteLine("\nYour Goals:");
        foreach (Goal goal in goals)
        {
            Console.WriteLine(goal.GetDetails());
        }
        Console.WriteLine($"\nTotal Score: {totalScore}");
    }

    static void SaveGoals(List<Goal> goals, int totalScore)
    {
        Console.Write("Enter the filename to save the goals: ");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            // Guardar el puntaje total
            outputFile.WriteLine(totalScore);

            // Guardar cada meta
            foreach (Goal goal in goals)
            {
                string goalType = goal.GetType().Name; // Obtener el tipo de meta
                string goalData = $"{goalType}:{goal.GetName()}:{goal.GetDescription()}:{goal.GetPoints()}";

                if (goal is ChecklistGoal checklistGoal)
                {
                    goalData += $":{checklistGoal.IsCompleted()}:{checklistGoal.GetRequiredTimes()}:{checklistGoal.GetBonusPoints()}";
                }
                else if (goal is SimpleGoal simpleGoal)
                {
                    goalData += $":{simpleGoal.IsCompleted()}";
                }

                outputFile.WriteLine(goalData);
            }

            Console.WriteLine("Goals saved successfully!");
        }
    }

    static (List<Goal>, int) LoadGoals()
    {
        Console.Write("Enter the filename to load the goals: ");
        string fileName = Console.ReadLine();

        List<Goal> goals = new List<Goal>();
        int totalScore = 0;

        string[] lines = File.ReadAllLines(fileName);

        // Leer el puntaje total
        totalScore = int.Parse(lines[0]);

        // Leer cada meta
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            string goalType = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            if (goalType == "SimpleGoal")
            {
                bool isComplete = bool.Parse(parts[4]);
                var goal = new SimpleGoal(name, description, points);
                if (isComplete)
                {
                    goal.RecordEvent();
                }
                goals.Add(goal);
            }
            else if (goalType == "EternalGoal")
            {
                goals.Add(new EternalGoal(name, description, points));
            }
            else if (goalType == "ChecklistGoal")
            {
                bool isComplete = bool.Parse(parts[4]);
                int requiredTimes = int.Parse(parts[5]);
                int bonusPoints = int.Parse(parts[6]);
                var goal = new ChecklistGoal(name, description, points, requiredTimes, bonusPoints);
                if (isComplete)
                {
                    for (int j = 0; j < requiredTimes; j++)
                    {
                        goal.RecordEvent();
                    }
                }
                goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully!");
        return (goals, totalScore);
    }
}
