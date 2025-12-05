using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Welcome to Eternal Quest ===\n");
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}