using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("This feature is under development.\n");
                    break;

                case "2":
                    Console.WriteLine("This feature is under development.\n");
                    break;

                case "3":
                    Console.WriteLine("This feature is under development.\n");
                    break;

                case "4":
                    Console.WriteLine("This feature is under development.\n");
                    break;

                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!\n");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.\n");
                    break;
            }
        }
    }
}
