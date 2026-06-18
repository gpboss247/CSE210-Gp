// W06 Project: Eternal Quest Program

// Author : Onaimor Godspower 

// Class : CSE210

// EXCEEDS REQUIREMENTS:
// 1. Leveling System - every 1000 points the user advances a level with a
//    title (Novice, Apprentice, Journeyman, Warrior, Champion, Hero, Legend,
//    Eternal Master). A level-up message is shown when it happens.
//    This adds gamification excitement as the user progresses.
//
// 2. Negative Goal - a fourth goal type, NegativeGoal that subtracts points
//    when a bad habit is recorded. This gives users a way to track and
//    discourage negative behaviors alongside their positive goals.

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        string menuChoice   = "";

        while (menuChoice != "6")
        {
            Console.WriteLine();
            Console.WriteLine("You have " + manager.GetScore() + " points  |  Level: " +
                              manager.GetLevel() + " - " + manager.GetLevelTitle());
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create new goal");
            Console.WriteLine("  2. List goals");
            Console.WriteLine("  3. Save goals");
            Console.WriteLine("  4. Load goals");
            Console.WriteLine("  5. Record event");
            Console.WriteLine("  6. Quit");
            Console.WriteLine();
            Console.Write("Select a choice from the menu: ");

            menuChoice = Console.ReadLine();

            if (menuChoice == "1")
            {
                manager.CreateGoal();
            }
            else if (menuChoice == "2")
            {
                Console.WriteLine();
                Console.WriteLine("The goals are:");
                manager.DisplayGoals();
            }
            else if (menuChoice == "3")
            {
                Console.Write("What is the filename for the goal file? ");
                string filename = Console.ReadLine();
                manager.SaveGoals(filename);
            }
            else if (menuChoice == "4")
            {
                Console.Write("What is the filename for the goal file? ");
                string filename = Console.ReadLine();
                manager.LoadGoals(filename);
            }
            else if (menuChoice == "5")
            {
                manager.RecordEvent();
            }
            else if (menuChoice != "6")
            {
                Console.WriteLine("Please enter a number between 1 and 6.");
            }
        }

        Console.WriteLine("Goodbye! Keep working on your Eternal Quest!");
    }
}