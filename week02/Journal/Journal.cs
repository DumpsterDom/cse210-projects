using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    private readonly List<Entry> _entries = new();

    public void AddEntry(Entry e) => _entries.Add(e);

    public void DisplayAll()
    {
        if (!_entries.Any())
        {
            Console.WriteLine("No entries yet – start your streak!");
            return;
        }

        Console.WriteLine($"\nYOUR JOURNAL ({_entries.Count} entries)\n");
        foreach (var e in _entries) e.Display();
        Console.WriteLine($"Streak: {GetStreak()} days!");
    }

    public int GetStreak()
    {
        if (!_entries.Any()) return 0;
        var dates = _entries.Select(e => DateTime.Parse(e._date))
                            .OrderBy(d => d)
                            .Distinct()
                            .ToList();

        int streak = 0;
        DateTime? prev = null;
        foreach (var d in dates)
        {
            if (prev == null || d.Date == prev.Value.AddDays(1).Date)
            {
                streak++;
                prev = d;
            }
            else break;
        }
        return streak;
    }

    public void SaveToFile(string file)
    {
        using var sw = new StreamWriter(file);
        foreach (var e in _entries)
        {
            sw.WriteLine($"[DATE]{e._date}");
            sw.WriteLine($"[PROMPT]{e._prompt}");
            sw.WriteLine($"[RESPONSE]{e._response}");
            sw.WriteLine($"[MOOD]{e._mood}");
            sw.WriteLine("---END---");
        }
        Console.WriteLine($"Saved → {file}");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(file))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();
        var lines = File.ReadAllLines(file);
        Entry cur = null;

        foreach (var line in lines)
        {
            if (line.StartsWith("[DATE]")) cur = new Entry { _date = line[6..] };
            else if (line.StartsWith("[PROMPT]")) cur._prompt = line[8..];
            else if (line.StartsWith("[RESPONSE]")) cur._response = line[10..];
            else if (line.StartsWith("[MOOD]")) cur._mood = line[6..];
            else if (line == "---END---" && cur != null)
            {
                _entries.Add(cur);
                cur = null;
            }
        }
        Console.WriteLine($"Loaded {_entries.Count} entries.");
    }
}