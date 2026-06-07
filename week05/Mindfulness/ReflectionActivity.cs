// Reflection activity guides the user to think deeply about a
// positive experience using a series of prompts and questions.
// Inherits all shared behavior from the Activity base class.
public class ReflectionActivity : Activity
{
   
    private List<string> _prompts;
    private List<string> _questions;

    // EXCEEDING REQUIREMENT: shuffled copies so no prompt or question repeats
    // until all have been used at least once
    private List<string> _remainingPrompts;
    private List<string> _remainingQuestions;

    private Random _random;

    public ReflectionActivity() : base(
        "Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life and excel.")
    {
        _random = new Random();

        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else other than yourself.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need even when it was inconvenient for you.",
            "Think of a time when you did something truly selfless to a random stranger."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        // Start with fresh copies to pull from
        _remainingPrompts   = new List<string>(_prompts);
        _remainingQuestions = new List<string>(_questions);
    }

    // EXCEEDIND REQUIREMENT: Returns a prompt and removes it from the remaining list.
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

    // EXCEEDING REQUIREMENT: Returns a question and removes it from the remaining list.
    // When the list runs out it refills so no question repeats until all are used.
    private string GetNextQuestion()
    {
        if (_remainingQuestions.Count == 0)
        {
            _remainingQuestions = new List<string>(_questions);
        }
        int index = _random.Next(_remainingQuestions.Count);
        string question = _remainingQuestions[index];
        _remainingQuestions.RemoveAt(index);
        return question;
    }

    // Runs the reflection activity.
    // Shows a random prompt then loops through questions with a spinner pause,
    // continuing until the user's chosen duration has been reached.
    public override void Run()
    {
        ShowStartMessage();

        Console.WriteLine(GetNextPrompt());
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        int secondsElapsed = 0;
        int pauseSeconds   = 5;

        while (secondsElapsed < GetDuration())
        {
            Console.Write("> " + GetNextQuestion() + "  ");
            ShowSpinner(pauseSeconds);
            secondsElapsed += pauseSeconds;
        }

        ShowEndMessage();
    }
}