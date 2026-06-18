// Breathing activity  guides the user through slow breathing in and out.
// Inherits all shared behavior from the Activity base class.
public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    // Runs the breathing activity.
    // Alternates between Breathe in and Breathe out with a countdown,
    // continuing until the user's chosen duration has been reached.
    public override void Run()
    {
        ShowStartMessage();

        int secondsElapsed = 0;
        bool breathingIn   = true;

        while (secondsElapsed < GetDuration())
        {
            if (breathingIn)
            {
                Console.Write("Breathe in...   ");
            }
            else
            {
                Console.Write("Breathe out...  ");
            }

            
            int pauseSeconds = 4;
            ShowCountdown(pauseSeconds);
            Console.WriteLine();

            secondsElapsed += pauseSeconds;
            breathingIn     = !breathingIn;
        }

        ShowEndMessage();
    }
}