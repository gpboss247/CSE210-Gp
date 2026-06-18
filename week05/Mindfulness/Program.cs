// W05 Project: Mindfulness Program
// Author : Onaimor Godspower
// Class : CSE 210 - Programming with classes 

// EXCEEDING REQUIREMENTS:
// 1. Activity Log fo how the program tracks how many times each activity has
//    been completed during the session and displays this count on the menu.
//    This helps users see how much mindfulness work they have done.
//
// 2. No repeat prompts or questions for ReflectionActivity and ListingActivity
//    both use a "remaining" list approach. A prompt or question is removed
//    from the list once used and only refills when all have been shown.
//    This means the user sees every prompt at least once before any repeats.

class Program
{
    static void Main()
    {
        // Activity log - tracks how many times each activity was run
        int breathingCount   = 0;
        int reflectionCount  = 0;
        int listingCount     = 0;

        // Create one instance of each activity to reuse across the session
        BreathingActivity  breathingActivity  = new BreathingActivity();
        ReflectionActivity reflectionActivity = new ReflectionActivity();
        ListingActivity    listingActivity    = new ListingActivity();

        string menuChoice = "";

        while (menuChoice != "4")
        {
            Console.Clear();
            Console.WriteLine("=== Mindfulness Program ===");
            Console.WriteLine();
            Console.WriteLine("Activities completed this session:");
            Console.WriteLine("  Breathing:  " + breathingCount  + " time(s)");
            Console.WriteLine("  Reflection: " + reflectionCount + " time(s)");
            Console.WriteLine("  Listing:    " + listingCount    + " time(s)");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1 - Breathing Activity");
            Console.WriteLine("  2 - Reflection Activity");
            Console.WriteLine("  3 - Listing Activity");
            Console.WriteLine("  4 - Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");

            menuChoice = Console.ReadLine();

            if (menuChoice == "1")
            {
                breathingActivity.Run();
                breathingCount++;
            }
            else if (menuChoice == "2")
            {
                reflectionActivity.Run();
                reflectionCount++;
            }
            else if (menuChoice == "3")
            {
                listingActivity.Run();
                listingCount++;
            }
            else if (menuChoice != "4")
            {
                Console.WriteLine("Please enter a number between 1 and 4.");
                Thread.Sleep(1500);
            }
        }

        Console.Clear();
        Console.WriteLine("Thank you for taking time for mindfulness today. Goodbye!");
        Console.WriteLine();
    }
}