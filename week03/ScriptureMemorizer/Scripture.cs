using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int count = 3)
    {
        var visibleWords = _words.Where(w => !w.Hidden()).ToList();
        if (visibleWords.Count == 0) return;

        int toHide = Math.Min(count, visibleWords.Count);
        var random = new Random();

        for (int i = 0; i < toHide; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsFullyHidden()
    {
        return _words.All(w => w.Hidden());
    }

    public Reference GetReference() => _reference;

    public void Display()
    {
        Console.Clear();
        Console.WriteLine($"{_reference.GetDisplayText()}\n");
        Console.WriteLine(string.Join(" ", _words.Select(w => w.GetDisplayText())));
        Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
    }
}