/* Journal - I added another section that asks for your mood as well. */
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator prompts = new PromptGenerator();

        Console.WriteLine("90-Second Journal – Streak & Mood!");

        while (true)
        {
            int streak = journal.GetStreak();
            if (streak > 0)
                Console.WriteLine($"Welcome back! Streak: {streak} days!");

            Console.WriteLine("\nMENU");
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save to TXT");
            Console.WriteLine("4. Load from TXT");
            Console.WriteLine("5. Exit");
            Console.Write("Choose (1-5): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteEntry(journal, prompts);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Save as: ");
                    journal.SaveToFile(Console.ReadLine() + ".txt");
                    break;

                case "4":
                    Console.Write("Load file: ");
                    journal.LoadFromFile(Console.ReadLine() + ".txt");
                    break;

                case "5":
                    Console.WriteLine("See you tomorrow!");
                    return;
                    
                default:
                    Console.WriteLine("Please pick 1–5.");
                    break;
            }
        }
    }

    static void WriteEntry(Journal journal, PromptGenerator prompts)
    {
        var entry = new Entry
        {
            _date = DateTime.Now.ToString("MMMM dd, yyyy"),
            _prompt = prompts.GetRandomPrompt()
        };

        Console.WriteLine($"\nPrompt: {entry._prompt}");
        Console.Write("Your answer: ");
        entry._response = Console.ReadLine();

        Console.WriteLine("\nMood?");
        Console.WriteLine("1. Great   2. Good   3. Okay   4. Tired   5. Stressed");
        entry._mood = Console.ReadLine() switch
        {
            "1" => "Great",
            "2" => "Good",
            "3" => "Okay",
            "4" => "Tired",
            "5" => "Stressed",
            _ => "Okay"
        };

        journal.AddEntry(entry);
        Console.WriteLine($"Saved! Streak: {journal.GetStreak()} days");
    }
}