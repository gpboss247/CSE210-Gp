// A checklist goal that must be completed a set number of times.
// Each recording gives points, and reaching the target gives a bonus.

public class ChecklistGoal : Goal
{
    // Private member variables
    private int _timesCompleted;
    private int _targetCount;
    private int _bonusPoints;

    // Constructor
    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _timesCompleted = 0;
        _targetCount    = targetCount;
        _bonusPoints    = bonusPoints;
    }

    // Constructor used when loading from a file (includes saved progress)
    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints, int timesCompleted)
        : base(name, description, points)
    {
        _timesCompleted = timesCompleted;
        _targetCount    = targetCount;
        _bonusPoints    = bonusPoints;
    }

    // Records one completion. Returns points earned (plus bonus if target is reached).
    public override int RecordEvent()
    {
        if (_timesCompleted >= _targetCount)
        {
            Console.WriteLine("This goal is already complete!");
            return 0;
        }

        _timesCompleted++;
        int earned = GetPoints();

        if (_timesCompleted == _targetCount)
        {
            earned += _bonusPoints;
            Console.WriteLine("Congratulations! You completed the goal and earned a bonus of " + _bonusPoints + " points!");
        }

        return earned;
    }

    // Returns a display string showing completion status and progress count
    public override string GetDetailsString()
    {
        string status = (_timesCompleted >= _targetCount) ? "[X]" : "[ ]";
        return status + " " + GetName() + " (" + GetDescription() + ")" +
               " -- Completed " + _timesCompleted + "/" + _targetCount + " times";
    }

   
    public override string GetStringRepresentation()
    {
        return "ChecklistGoal|" + GetName() + "|" + GetDescription() + "|" + GetPoints() + "|" +
               _targetCount + "|" + _bonusPoints + "|" + _timesCompleted;
    }
}