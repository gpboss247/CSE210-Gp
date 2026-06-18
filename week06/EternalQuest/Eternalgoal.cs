// An eternal goal that never completes but gives points every time it is recorded.

public class EternalGoal : Goal
{
    // Constructor
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    // Always returns the points — this goal never ends
    public override int RecordEvent()
    {
        return GetPoints();
    }

    // Always shows [ ] because an eternal goal is never finished
    public override string GetDetailsString()
    {
        return "[ ] " + GetName() + " (" + GetDescription() + ")";
    }


    public override string GetStringRepresentation()
    {
        return "EternalGoal|" + GetName() + "|" + GetDescription() + "|" + GetPoints();
    }
}