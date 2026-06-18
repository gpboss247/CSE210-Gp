// EXCEEDS REQUIREMENTS: A negative goal that subtracts points when a bad habit is recorded.
// This helps users track habits they want to stop, such as eating junk food or skipping exercise.

public class NegativeGoal : Goal
{
    // Constructor - points stored as a positive number, subtracted on RecordEvent
    public NegativeGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    // Returns a negative value so the GoalManager subtracts from the score
    public override int RecordEvent()
    {
        return -GetPoints();
    }

    // Always shows [ ] — a negative goal has no completion state
    public override string GetDetailsString()
    {
        return "[-] " + GetName() + " (" + GetDescription() + ") [Negative Goal: -" + GetPoints() + " pts]";
    }

    // Returns a string for saving to a file
    // Format: NegativeGoal|name|description|points
    public override string GetStringRepresentation()
    {
        return "NegativeGoal|" + GetName() + "|" + GetDescription() + "|" + GetPoints();
    }
}