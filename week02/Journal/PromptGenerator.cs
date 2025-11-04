using System;

public claass PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "What was the best part of your day?",
        "What are you grateful for right now?",
        "What was your favorite snack, meal or treat today?",
        "What did you learn today?",
        "What can make tomorrow even better then today?",
        "Who did you have a positive interaction with today?",

    }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }
}