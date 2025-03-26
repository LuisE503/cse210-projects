using System;

class Program
{
    static void Main(string[] args)
    {
        int breathingCount = 0;
        int reflectingCount = 0;
        int listingCount = 0;

        Console.WriteLine("Mindfulness Program");
        Console.WriteLine("1. Breathing Activity");
        Console.WriteLine("2. Reflection Activity");
        Console.WriteLine("3. Listing Activity");
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
                    breathingCount++; 
                    break;
                case "2":
                    ReflectionActivity reflecting = new ReflectionActivity();
                    reflecting.RunActivity();
                    reflectingCount++; 
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.RunActivity();
                    listingCount++; 
                    break;
                case "4":
                    running = false;

                    Console.WriteLine("\nActivity Summary:");
                    Console.WriteLine($"Breathing Activity completed: {breathingCount} times.");
                    Console.WriteLine($"Reflection Activity completed: {reflectingCount} times.");
                    Console.WriteLine($"Listing Activity completed: {listingCount} times.");
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
