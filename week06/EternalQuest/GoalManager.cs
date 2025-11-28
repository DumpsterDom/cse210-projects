using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;
    private List<string> _achievements = new List<string>();

    public void Start()
    {
        while (true)
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice: ");
            
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": SaveGoals(); break;
                case "4": LoadGoals(); break;
                case "5": RecordEvent(); break;
                case "6": return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        UpdateLevel();
        Console.WriteLine($"You have {_score} points | Level {_level} Eternal Seeker");
        if (_achievements.Count > 0)
            Console.WriteLine($"Achievements: {string.Join(", ", _achievements)}");
    }

    private void UpdateLevel()
    {
        int newLevel = _score / 500 + 1;
        if (newLevel > _level)
        {
            for (int i = _level + 1; i <= newLevel; i++)
            {
                string title = i switch
                {
                    2 => "Novice Disciple",
                    5 => "Steadfast Saint",
                    10 => "Celestial Warrior",
                    15 => "Master of Eternity",
                    _ => $"Level {i} Eternal Seeker"
                };
                _achievements.Add(title);
                Console.WriteLine($"\n*** LEVEL UP! You are now {title}! ***\n");
            }
            _level = newLevel;
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("Types of Goals:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type? ");
        string type = Console.ReadLine();

        Console.Write("Goal name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        Goal goal = type switch
        {
            "1" => new SimpleGoal(name, desc, points),
            "2" => new EternalGoal(name, desc, points),
            "3" => {
                Console.Write("How many times to accomplish? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus for completion: ");
                int bonus = int.Parse(Console.ReadLine());
                yield return new ChecklistGoal(name, desc, points, target, bonus);
            },
            _ => null
        };

        if (goal != null)
        {
            _goals.Add(goal);
            Console.WriteLine("Goal created!\n");
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Create one!\n");
            return;
        }

        Console.WriteLine("Your Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
        Console.WriteLine();
    }

    public void RecordEvent()
    {
        ListGoalDetails();
        Console.Write("Which goal did you accomplish? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            int points = _goals[index].RecordEvent();
            _score += points;
            Console.WriteLine($"Congratulations! You earned {points} points!\n");
        }
    }

    public void SaveGoals()
    {
        Console.Write("Enter filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved!\n");
    }

    public void LoadGoals()
    {
        Console.Write("Enter filename to load: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);
            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                string type = parts[0];
                string[] data = parts[1].Split(',');

                Goal goal = type switch
                {
                    "SimpleGoal" => new SimpleGoal(data[0], data[1], int.Parse(data[2])) { /* hack to set private field via reflection or just re-record if needed */ },
                    "EternalGoal" => new EternalGoal(data[0], data[1], int.Parse(data[2])),
                    "ChecklistGoal" => new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4])),
                    _ => null
                };

                if (goal != null) _goals.Add(goal);
            }
            Console.WriteLine("Goals loaded!\n");
        }
    }
}