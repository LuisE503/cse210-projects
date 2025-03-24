using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("How to Cook Pasta", "Chef Luigi", 300);
        Video video2 = new Video("Learn Guitar in 10 Minutes", "Guitar Hero", 600);

        video1.AddComment(new Comment("Anna", "This is so helpful!"));
        video1.AddComment(new Comment("John", "Yummy recipe, thanks!"));

        video2.AddComment(new Comment("Peter", "I learned so much, thanks!"));
        video2.AddComment(new Comment("Lily", "This was fun to watch."));

        List<Video> videos = new List<Video> { video1, video2 };

        Console.WriteLine($"Title: {video1.GetTitle()}");
        Console.WriteLine($"Author: {video1.GetAuthor()}");
        Console.WriteLine($"Length: {video1.GetLength()} seconds");
    }
}
