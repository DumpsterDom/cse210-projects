using System;

/*
  CREATIVITY & EXCEEDING REQUIREMENTS:
  - Added a full Leveling System (Level 1 → 15+)
  - Earn titles like "Celestial Warrior", "Master of Eternity"
  - Achievement badges displayed on screen
  - Fun motivational messages on level up
  - Clean, colorful menu experience
  This turns the program into a true "Eternal Quest" game!
*/

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Welcome to Eternal Quest ===\n");
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}