using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<string> journal = new List<string>(); // Lista para almacenar entradas
        bool running = true;

        while (running)
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Exit");
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter your journal entry: ");
                    string entry = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();
                    journal.Add($"[{date}] {entry}");
                    Console.WriteLine("Entry added successfully!\n");
                    break;

                case "2":
                    Console.WriteLine("\nJournal Entries:");
                    foreach (string log in journal)
                    {
                        Console.WriteLine(log);
                    }
                    Console.WriteLine();
                    break;

                case "3":
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
