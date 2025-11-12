public class Word
{
    private string _text;
    private bool _hidden;

    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }

    public void Hide()
    {
        _hidden = true;
    }

    public bool Hidden()
    {
        return _hidden;
    }

    public string  GetDisplayText()
    {
        if (_hidden)
        {
            return new string('_', _text.Length);
        }
        return _text;
    }
}