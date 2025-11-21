using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold all videos
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video("Learn C# in 10 Minutes", "CodeWithMike", 600);
        video1.AddComment("Alice", "Great tutorial! Very clear and helpful.");
        video1.AddComment("Bob", "I finally understand classes now, thanks!");
        video1.AddComment("Charlie", "Can you make a longer version?");
        video1.AddComment("Diana", "Best C# intro I've seen!");
        videos.Add(video1);

        // Video 2
        Video video2 = new Video("Cooking Perfect Pasta", "ChefAnna", 480);
        video2.AddComment("Emma", "My pasta came out perfect! Thank you!");
        video2.AddComment("Frank", "Don't forget to salt the water!!");
        video2.AddComment("Grace", "This changed my life lol");
        videos.Add(video2);

        // Video 3
        Video video3 = new Video("How to Draw a Cat", "ArtBySarah", 900);
        video3.AddComment("Henry", "My cat looks just like this now :D");
        video3.AddComment("Isabella", "So cute and easy to follow!");
        video3.AddComment("Jack", "I showed this to my cat and he approves");
        video3.AddComment("Katie", "Amazing! Subscribed!");
        videos.Add(video3);

        // Video 4 (optional 4th video)
        Video video4 = new Video("Morning Yoga Routine", "YogaWithLisa", 1200);
        video4.AddComment("Liam", "I feel so relaxed now, thank you!");
        video4.AddComment("Mia", "Perfect way to start the day");
        video4.AddComment("Noah", "My back feels so much better");
        videos.Add(video4);

        // Display all videos and their comments
        foreach (Video video in videos)
        {
            Console.WriteLine("========================================");
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.GetLengthFormatted()} ({video.LengthInSeconds} seconds)");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment}");
            }
            Console.WriteLine("========================================");
            Console.WriteLine();
        }
    }
}