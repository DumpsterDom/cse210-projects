using System;
using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    
    private List<Comment> comments;

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
        comments = new List<Comment>();
    }

    public void AddComment(string name, string text)
    {
        comments.Add(new Comment(name, text));
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public List<Comment> GetComments()
    {
        return comments;
    }

    // Helper method to format length nicely (optional but nice)
    public string GetLengthFormatted()
    {
        int minutes = LengthInSeconds / 60;
        int seconds = LengthInSeconds % 60;
        return $"{minutes}:{seconds:D2}";
    }
}