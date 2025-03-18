using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5);
        Scripture scripture = new Scripture(reference, "Trust in the Lord with all your heart");

        Console.WriteLine(scripture.GetDisplayText());
    }
}
