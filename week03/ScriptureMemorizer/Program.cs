using System;

class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary();
        library.AddScripture(new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding"));
        library.AddScripture(new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life"));
        library.AddScripture(new Scripture(new Reference("Psalm", 23, 1), "The Lord is my shepherd; I shall not want"));
        library.AddScripture(new Scripture(new Reference("2 Nephi", 2, 25), "Adam fell that men might be; and men are, that they might have joy."));
        library.AddScripture(new Scripture(new Reference("Mosiah", 2, 17), "When ye are in the service of your fellow beings ye are only in the service of your God."));

        bool continuePracticing = true;

        while (continuePracticing)
        {
            Scripture scripture = library.GetRandomScripture();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());

                if (scripture.IsCompletelyHidden())
                {
                    Console.WriteLine("\nAll words are hidden!");
                    break;
                }

                Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to exit.");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    continuePracticing = false;
                    break;
                }

                scripture.HideRandomWords(3);
            }

            if (continuePracticing)
            {
                Console.WriteLine("\nWould you like to practice another scripture? (s/n)");
                string response = Console.ReadLine().ToLower();

                if (response != "s")
                {
                    continuePracticing = false;
                }
            }
        }

        Console.WriteLine("Thank you for practicing. Goodbye!");
    }
}
