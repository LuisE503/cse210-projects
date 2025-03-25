using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Mindfulness Program");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity (to be implemented)");
        Console.WriteLine("3. Listing Activity (to be implemented)");
        Console.WriteLine("4. Quit");

        bool running = true;

        while (running)
        {
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.RunActivity();
                    break;
                case "2":
                    Console.WriteLine("Reflection Activity is under construction.");
                    break;
                case "3":
                    Console.WriteLine("Listing Activity is under construction.");
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
