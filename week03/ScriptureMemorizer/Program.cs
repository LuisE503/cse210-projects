using System;

class Program
{
    static void Main(string[] args)
    {
        // Creamos la biblioteca de escrituras
        ScriptureLibrary library = new ScriptureLibrary();
        library.AddScripture(new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding"));
        library.AddScripture(new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life"));
        library.AddScripture(new Scripture(new Reference("Psalm", 23, 1), "The Lord is my shepherd; I shall not want"));

        // Elegimos una escritura al azar
        Scripture scripture = library.GetRandomScripture();

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nAll words are hidden. Program will end.");
                break;
            }

            Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}
