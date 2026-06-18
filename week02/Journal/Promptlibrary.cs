// This class stores a list of journal prompts and returns a random one.

public class PromptLibrary
{
    
    public List<string> _prompts = new List<string>();
    public Random _random = new Random();


    public PromptLibrary()
    {
        _prompts.Add("Who was the most interesting person I interacted with today?");
        _prompts.Add("What was the best part of my day?");
        _prompts.Add("How did I see the hand of the Lord in my life today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I had one thing I could do over today, what would it be?");
        _prompts.Add("If you could change one thing that happened to you today, what would it be?");
    }

    // Picks and returns a random prompt from the list
    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}