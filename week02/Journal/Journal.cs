using System;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty. Write your first entry");
            return;
        }

        Console.WriteLine("\nYour Journal Entries:");
        Console.WriteLine("=============================");
        foreach (Entry e in _entries)
        {
            e.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            foreach (Entry e in _entries)
            {
            writer.WriteLine($"[DATE]{e._date}");
            writer.WriteLine($"[PROMPT]{e._prompt}");
            writer.WriteLine($"[RESPONSE]{e._response}");
            writer.WriteLine("-------------");
            }
        }
        Console.WriteLine($"Journal saved to {file}!");
    }

    public void LoadFromFile(string file)
    {
        if (!File.Exists(File))
        {
            Console.WriteLine("File Not Found.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(file);
        Entry current - null;

        foreach (string line in lines)
        {
            if (line.StartsWith("DATE"))
                current = new Entry { _date = line.Substring(6) };
            else if (line.StartsWith("PROMPT"))
                current._prompt = line.Substring(8);
            else if (line.StartsWith("RESPONSE"))
                current._response = line.Substring(10);
            else if (line == "-------------" && current != null)
            {
                _entries.Add(current);
                current = null;
            }
        }
        Console.WriteLine($"Loaded {_entries.Count} entries!");
    }
}