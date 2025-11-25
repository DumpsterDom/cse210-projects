using System;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity breathing = new BreathingActivity();
        ReflectingActivity reflecting = new ReflectingActivity();
        ListingActivity listing = new ListingActivity();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1") breathing.Run();
            else if (choice == "2") reflecting.Run();
            else if (choice == "3") listing.Run();
            else if (choice == "4") break;
            else Console.WriteLine("Invalid choice. Press Enter to continue...");
        }

        Console.WriteLine("Thank you for using the Mindfulness Program!");
    }
}