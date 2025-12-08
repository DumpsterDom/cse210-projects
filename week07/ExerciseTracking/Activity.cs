using System;

public abstract class Activity
{
    private string _date;
    private int _length; 

    public Activity(string date, int length)
    {
        _date = date;
        _length = length;
    }

    // Getters
    public string GetDate() => _date;
    public int GetLength() => _length;

    // Abstract 
    public abstract double GetDistance(); 
    public abstract double GetSpeed();    
    public abstract double GetPace();     

    // Summary
    public virtual string GetSummary()
    {
        return $"{_date} {this.GetType().Name} ({_length} min): " +
               $"Distance {GetDistance():0.0} miles, " +
               $"Speed {GetSpeed():0.0} mph, " +
               $"Pace {GetPace():0.0} min per mile";
    }
}
