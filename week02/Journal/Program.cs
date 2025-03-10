using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a JSON file");
            Console.WriteLine("4. Load the journal from a JSON file");
            Console.WriteLine("5. Display statistics");
            Console.WriteLine("6. Exit");
            Console.Write("Your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"\n{prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();

                    DateTime currentDate = DateTime.Now;
                    string dateText = currentDate.ToShortDateString();
                    Entry newEntry = new Entry(dateText, prompt, response);

                    journal.AddEntry(newEntry);
                    Console.WriteLine("\nEntry added successfully!\n");
                    break;

                case "2":
                    Console.WriteLine("\nJournal Entries:");
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter the filename to save to (e.g., journal.json): ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToJson(saveFilename);
                    Console.WriteLine("\nJournal saved successfully in JSON format!\n");
                    break;

                case "4":
                    Console.Write("Enter the filename to load from (e.g., journal.json): ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromJson(loadFilename);
                    Console.WriteLine("\nJournal loaded successfully from JSON format!\n");
                    break;

                case "5":
                    journal.DisplayStatistics();
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("\nGoodbye!");
                    break;

                default:
                    Console.WriteLine("\nInvalid option. Please try again.\n");
                    break;
            }
        }
    }
}
