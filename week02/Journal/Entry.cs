using System;
public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;

    public void Display()
    {

     Console.WriteLine($"\nDate: {_date}");
     Console.WriteLine($"Prompt: {_Prompt}");
     Console.WriteLine($"Answer: {_response}\n");

    }
}