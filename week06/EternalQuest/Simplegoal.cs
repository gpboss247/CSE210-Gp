// A simple goal that can be marked complete once and gives points.

public class SimpleGoal : Goal
{
    
    private bool _isComplete;

 
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    // Records the goal as complete and returns the points earned.
    // If already complete, returns 0 points (can't earn twice).
    public override int RecordEvent()
    {
        if (_isComplete)
        {
            Console.WriteLine("This goal is already complete!");
            return 0;
        }

        _isComplete = true;
        return GetPoints();
    }

    // Returns a display string showing [X] if complete or [ ] if not
    public override string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        return status + " " + GetName() + " (" + GetDescription() + ")";
    }

    // Returns a string for saving to a file
    // Format: SimpleGoal|name|description|points|isComplete
    public override string GetStringRepresentation()
    {
        return "SimpleGoal|" + GetName() + "|" + GetDescription() + "|" + GetPoints() + "|" + _isComplete;
    }
}