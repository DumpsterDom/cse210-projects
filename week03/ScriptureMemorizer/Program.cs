using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Scriptures
        var scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16),
                "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),

            new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),

            new Scripture(new Reference("Nephi", 2, 27),
                "They are free to choose liberty and eternal life, through the great Mediator of all men, and they are free to choose bondage of the devil, for he cometh to make all men miserable, like unto himself."),

            new Scripture(new Reference("Moroni", 10, 4, 5),
                "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost."),

            new Scripture(new Reference("Mosiah", 18, 9),
                "And it came to pass that the people of the church, all the children of the land, were called the people of Christ. And behold, they were happy; and they that mourned, because of the iniquities of the people, were called the people of God; and the people of God were happy; and they that mourned, because of the iniquities of the people, were called the people of God.")
        };

        Random random = new Random();

        // Game loop
        while (true)
        {
            // Random scripture
            Scripture scripture = scriptures[random.Next(scriptures.Count)];

            Console.Clear();
            Console.WriteLine($"=== Today's Scripture ===");
            Console.WriteLine($"{scripture.GetReference().GetDisplayText()}\n");
            Console.WriteLine("Press ENTER to begin memorizing...");
            Console.ReadLine();

            // Memory Loop
            while (true)
            {
                scripture.Display();

                if (scripture.IsFullyHidden())
                {
                    Console.WriteLine("\nCongratulations! All words hidden!");
                    break;
                }

                string input = Console.ReadLine()?.Trim().ToLower() ?? "";

                if (input == "quit")
                {
                    Console.WriteLine("Goodbye!");
                    return; 
                }

                scripture.HideRandomWords(3);
            }

            // Play again
            Console.WriteLine("\nWould you like to practice another scripture? (y/n)");
            string response = Console.ReadLine()?.Trim().ToLower() ?? "n";

            if (response != "y" && response != "yes")
            {
                Console.WriteLine("Thanks for practicing! Goodbye!");
                break;
            }
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}