using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("How to Cook Pasta", "Chef Luigi", 300);
        Video video2 = new Video("Learn Guitar in 10 Minutes", "Guitar Hero", 600);
        Video video3 = new Video("Top 10 Travel Destinations", "Wanderlust", 720);

        video1.AddComment(new Comment("Anna", "This is so helpful!"));
        video1.AddComment(new Comment("John", "Yummy recipe, thanks!"));
        video1.AddComment(new Comment("Maria", "Can't wait to try this!"));

        video2.AddComment(new Comment("Peter", "I learned so much, thanks!"));
        video2.AddComment(new Comment("Lily", "This was fun to watch."));
        video2.AddComment(new Comment("Sam", "Great tips!"));

        video3.AddComment(new Comment("Emily", "I love all of these destinations."));
        video3.AddComment(new Comment("Tom", "Adding these to my bucket list."));
        video3.AddComment(new Comment("Sophie", "Such a great video!"));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine(); 
        }
    }
}
