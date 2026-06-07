// Base class for all mindfulness activities.
// to hold the shared attributes and
// behaviors that all activities have in common, so they do not need
// to be repeated in every child class.
public abstract class Activity
{
   
    private string _name;
    private string _description;
    private int _duration;

   
    public Activity(string name, string description)
    {
        _name        = name;
        _description = description;
        _duration    = 0;
    }

    
    public int GetDuration()
    {
        return _duration;
    }

    
    public string GetName()
    {
        return _name;
    }

    public void ShowStartMessage()
    {
        Console.Clear();
        Console.WriteLine("--- " + _name + " ---");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get ready...");
        Console.WriteLine();
        ShowSpinner(3);
    }

    
    public void ShowEndMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(2);
        Console.WriteLine("You have completed the " + _name + " activity.");
        Console.WriteLine("You spent " + _duration + " seconds on this activity.");
        ShowSpinner(3);
    }

    // Shows a spinner animation for the given number of seconds.
    // Protected so child classes can use it directly.
    protected void ShowSpinner(int seconds)
    {
        string[] spinnerFrames = { "|", "/", "-", "\\" };
        int totalFrames        = seconds * 8;

        for (int i = 0; i < totalFrames; i++)
        {
            Console.Write(spinnerFrames[i % spinnerFrames.Length]);
            Thread.Sleep(125);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    // Shows a numeric countdown from the given number down to 1.
    // Protected so child classes can use it directly.
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            
            Console.Write("\b \b");
        }
    }

    
    public abstract void Run();
}