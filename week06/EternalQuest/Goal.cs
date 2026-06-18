// Abstract base class for all goal types.
// The responsibility of Goal is to hold the shared attributes and
// define the contract (abstract methods) that every child class must fulfill.
public abstract class Goal
{
    // Private member variables shared by all goal types
    private string _name;
    private string _description;
    private int _points;

    
    public Goal(string name, string description, int points)
    {
        _name        = name;
        _description = description;
        _points      = points;
    }

       public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    // Abstract methods - every child class MUST provide its own version.
    // This is the polymorphism contract.

    // Records that this goal was completed. Returns the points earned.
    public abstract int RecordEvent();

    // Returns a string showing the goal's status for display on screen.
    public abstract string GetDetailsString();

   
    public abstract string GetStringRepresentation();
}