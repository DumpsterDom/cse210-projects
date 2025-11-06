using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private readonly List<string> _prompts = new()
    {
        "What was the best part of your day?",
        "What are you grateful for right now?",
        "What was your favorite snack, meal or treat today?",
        "What did you learn today?",
        "What can make tomorrow even better than today?",
        "Who did you have a positive interaction with today?"
    };

    public string GetRandomPrompt()
    {
        return _prompts[new Random().Next(_prompts.Count)];
    }
}