// W02 Project : Journal Program
// Author : Onaimor Godspower
// Progaram : CSE 210 - Programming with classes 
//
// EXCEEDS REQUIREMENTS:
// 1. Mood Tracker - when writing a new entry, the user is asked to pick
//    their current mood (Happy, Content, Neutral, Stressed, Sad).
//    The mood is saved with the entry and shown when entries are displayed.
//    This helps people track how they are feeling over time to time.
// 2. Journal Statistics (menu option 5) - shows the user a summary of 
//    their journal including total entries, total words written, average
//    words per entry, and a breakdown of how many times each mood appeared.
//    This helps people notice patterns in their journaling and emotions.
 
class Program
{
    static void Main(string[] args)
    {
        Journal journal       = new Journal();
        PromptLibrary prompts = new PromptLibrary();
        string menuChoice     = "";

        Console.WriteLine("Welcome to the Journal Program!");

        while (menuChoice != "6")
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1 - Write a new entry");
            Console.WriteLine("2 - Display the journal");
            Console.WriteLine("3 - Save journal to file");
            Console.WriteLine("4 - Load journal from file");
            Console.WriteLine("5 - View journal statistics");
            Console.WriteLine("6 - Quit");
            Console.Write("> ");

            menuChoice = Console.ReadLine();

            if (menuChoice == "1")
            {
                WriteNewEntry(journal, prompts);
            }
            else if (menuChoice == "2")
            {
                journal.Display();
            }
            else if (menuChoice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.Save(filename);
            }
            else if (menuChoice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.Load(filename);
            }
            else if (menuChoice == "5")
            {
                journal.ShowStats();
            }
            else if (menuChoice != "6")
            {
                Console.WriteLine("Please enter a number between 1 and 6.");
            }
        }

        Console.WriteLine("Goodbye!");
    }

    // Gets a random prompt, reads the response, and asks for mood.
    static void WriteNewEntry(Journal journal, PromptLibrary prompts)
    {
        string date   = DateTime.Now.ToShortDateString();
        string prompt = prompts.GetRandomPrompt();

        Console.WriteLine("Date: " + date);
        Console.WriteLine("Prompt: " + prompt);
        Console.Write("> ");
        string response = Console.ReadLine();

        // EXCEEDS REQUIREMENTS: ask user for their mood
        string mood = GetMood();

        Entry newEntry = new Entry(date, prompt, response, mood);
        journal.AddEntry(newEntry);

        Console.WriteLine("Entry saved!");
    }

    // EXCEEDS REQUIREMENTS: Asks  user to select their current mood.
    // Recording mood alongside each entry helps users track emotional patterns over time 
    
    static string GetMood()
    {
        Console.WriteLine("How are you feeling right now?");
        Console.WriteLine("1 - Happy");
        Console.WriteLine("2 - Content");
        Console.WriteLine("3 - Neutral");
        Console.WriteLine("4 - Stressed");
        Console.WriteLine("5 - Sad");
        Console.Write("Enter a number (1-5): ");

        string input = Console.ReadLine();

        if (input == "1") return "Happy";
        if (input == "2") return "Content";
        if (input == "3") return "Neutral";
        if (input == "4") return "Stressed";
        if (input == "5") return "Sad";

        return "Neutral";
    }
}