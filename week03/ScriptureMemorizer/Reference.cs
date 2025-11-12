public class Reference
{
    private string _book;
    private int _chapter;
    private int _firstVerse;
    private int? _lastVerse;

    // Single verse
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _firstVerse = verse;
        _lastVerse = null;
    }

    // Verse range
    public Reference(string book, int chapter, int firstVerse, int lastVerse)
    {
        _book = book;
        _chapter = chapter;
        _firstVerse = firstVerse;
        _lastVerse = lastVerse;
    }

    public string GetDisplayText() 
    {
        if (_lastVerse == null)
            return $"{_book} {_chapter}:{_firstVerse}";
        else
            return $"{_book} {_chapter}:{_firstVerse}-{_lastVerse}";
    }
}