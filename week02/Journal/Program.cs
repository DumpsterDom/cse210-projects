using System;

class Program
{
    static void Main(string[] args)
    {
        Journal Journal = new Journal():
        PromptGenerator prompts = new PromptGenerator();

        Console.WriteLine("Welcome to your daily journal!");

        while (true)
        {
            console.WriteLine("\nMenu:");
            console.WriteLine("1. New Entry");
            console.WriteLine("2. Read Journal");
            console.WriteLine("3. Save Journal");
            console.WriteLine("4. Load Journal");
            console.WriteLine("5. Exit");
            console.Write("Please make a choice:")

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Entry entry = new Entry();
                    entry._prompt = prompts.GetRandomPrompt():
                    Console.WriteLine($"\nPrompt: {entry._prompt}");
                    Console.Writew("Your Answer:" );
                    entry._response = Console.ReadLine();
                    entry._date = DateTime.Now.ToString("MMMM dd, yyyy");
                    journal.AddEntry(entry);
                    Console.WriteLine("Saved!");
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Save As:");
                    journal.SaveToFile(Console.ReadLine() + ".txt");
                    break;

                case "4":
                    Console.Write("Load File:");
                    journal.LoadFromFile(Console.ReadLine() + ".txt");
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLiune("Try 1-5");
                    break;
            }
        }
    }
}