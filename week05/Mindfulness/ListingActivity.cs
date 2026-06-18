// Listing activity guides the user to list as many positive things
// as they can think of in a given area.
// Inherits all shared behavior from the Activity base class.
public class ListingActivity : Activity
{
    // Private list of prompts
    private List<string> _prompts;

    // EXCEEDING REQUIREMENT: remaining list so no prompt repeats until all are used
    private List<string> _remainingPrompts;

    private Random _random;

    // Constructor sets up the prompt list and passes name/description to base class
    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _remainingPrompts = new List<string>(_prompts);
    }

    // EXCEEDING REQUIREMENT: Returns a prompt and removes it from the remaining list.
    // When the list runs out it refills so no prompt repeats until all are used.
    private string GetNextPrompt()
    {
        if (_remainingPrompts.Count == 0)
        {
            _remainingPrompts = new List<string>(_prompts);
        }
        int index = _random.Next(_remainingPrompts.Count);
        string prompt = _remainingPrompts[index];
        _remainingPrompts.RemoveAt(index);
        return prompt;
    }

  
    public override void Run()
    {
        ShowStartMessage();

        Console.WriteLine(GetNextPrompt());
        Console.WriteLine();
        Console.WriteLine("You will have a few seconds to think before you start listing.");
        Console.WriteLine();
        ShowCountdown(5);
        Console.WriteLine();
        Console.WriteLine("Start listing items. Press Enter after each one.");
        Console.WriteLine("(The activity will stop automatically when time is up.)");
        Console.WriteLine();

        int itemCount        = 0;
        DateTime startTime   = DateTime.Now;
        double secondsElapsed = 0;

        while (secondsElapsed < GetDuration())
        {
            Console.Write("> ");
            string item = Console.ReadLine();

            if (item != "")
            {
                itemCount++;
            }

            secondsElapsed = (DateTime.Now - startTime).TotalSeconds;
        }

        Console.WriteLine();
        Console.WriteLine("You listed " + itemCount + " items!");

        ShowEndMessage();
    }
}