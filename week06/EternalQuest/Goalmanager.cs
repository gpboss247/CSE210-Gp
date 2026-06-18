// The responsibility of GoalManager is to manage the full list of goals,
// track the user's score and level, and handle saving and loading.

public class GoalManager
{
    // Private member variables
    private List<Goal> _goals;
    private int _score;

    // EXCEEDS: level titles for the leveling system
    private List<string> _levelTitles;

    // Constructor
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;

        // EXCEEDS: define the level title list
        _levelTitles = new List<string>
        {
            "Novice",
            "Apprentice",
            "Journeyman",
            "Warrior",
            "Champion",
            "Hero",
            "Legend",
            "Eternal Master"
        };
    }

    // ─── Getters ───────────────────────────────────────────────────────────

    public int GetScore()
    {
        return _score;
    }

    // EXCEEDS: returns the current level number (0-based, capped at list size)
    public int GetLevel()
    {
        int level = _score / 1000;
        if (level >= _levelTitles.Count)
        {
            level = _levelTitles.Count - 1;
        }
        return level;
    }

    // EXCEEDS: returns the current level title
    public string GetLevelTitle()
    {
        return _levelTitles[GetLevel()];
    }

    // ─── Display ───────────────────────────────────────────────────────────

    // Displays all goals with their current status
    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            // Polymorphism: GetDetailsString() calls the right version for each goal type
            Console.WriteLine((i + 1) + ". " + _goals[i].GetDetailsString());
        }
    }

    // ─── Create Goals ──────────────────────────────────────────────────────

    // Asks the user for goal details and creates the right type of goal
    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (lose points for bad habits)");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (choice == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (choice == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (choice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else if (choice == "4")
        {
            _goals.Add(new NegativeGoal(name, description, points));
        }
        else
        {
            Console.WriteLine("Invalid choice. Goal was not created.");
        }
    }

    // ─── Record Event ──────────────────────────────────────────────────────

    // Asks the user which goal they completed and updates their score
    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals to record. Create a goal first.");
            return;
        }

        Console.WriteLine("The goals are:");
        DisplayGoals();
        Console.Write("Which goal did you accomplish? ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int levelBefore = GetLevel();

        // Polymorphism: RecordEvent() calls the right version for each goal type
        int pointsEarned = _goals[goalIndex].RecordEvent();
        _score += pointsEarned;

        if (pointsEarned > 0)
        {
            Console.WriteLine("You have earned " + pointsEarned + " points!");
        }
        else if (pointsEarned < 0)
        {
            Console.WriteLine("You lost " + (-pointsEarned) + " points.");
        }

        // EXCEEDS: check if the user leveled up
        int levelAfter = GetLevel();
        if (levelAfter > levelBefore)
        {
            Console.WriteLine("*** You leveled up! You are now a " + GetLevelTitle() + "! ***");
        }

        Console.WriteLine("You now have " + _score + " points.");
    }

    // ─── Save and Load ─────────────────────────────────────────────────────

    // Saves all goals and the current score to a file
    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                // Polymorphism: GetStringRepresentation() calls the right version
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved to " + filename);
    }

    // Loads goals and score from a file, replacing the current list
    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found: " + filename);
            return;
        }

        _goals.Clear();

        string[] lines = File.ReadAllLines(filename);

        // First line is the score
        _score = int.Parse(lines[0]);

        // Remaining lines are goals
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            if (line.Trim() == "")
            {
                continue;
            }

            // Split on | to get the type and the data fields
            string[] parts = line.Split('|');
            string type    = parts[0];

            if (type == "SimpleGoal")
            {
                string name        = parts[1];
                string description = parts[2];
                int points         = int.Parse(parts[3]);
                bool isComplete    = bool.Parse(parts[4]);
                _goals.Add(new SimpleGoal(name, description, points, isComplete));
            }
            else if (type == "EternalGoal")
            {
                string name        = parts[1];
                string description = parts[2];
                int points         = int.Parse(parts[3]);
                _goals.Add(new EternalGoal(name, description, points));
            }
            else if (type == "ChecklistGoal")
            {
                string name        = parts[1];
                string description = parts[2];
                int points         = int.Parse(parts[3]);
                int targetCount    = int.Parse(parts[4]);
                int bonusPoints    = int.Parse(parts[5]);
                int timesCompleted = int.Parse(parts[6]);
                _goals.Add(new ChecklistGoal(name, description, points, targetCount, bonusPoints, timesCompleted));
            }
            else if (type == "NegativeGoal")
            {
                string name        = parts[1];
                string description = parts[2];
                int points         = int.Parse(parts[3]);
                _goals.Add(new NegativeGoal(name, description, points));
            }
        }

        Console.WriteLine("Goals loaded from " + filename + ". Score: " + _score);
    }
}