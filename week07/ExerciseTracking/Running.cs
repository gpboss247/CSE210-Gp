// Running activity - stores the distance run in miles.

public class Running : Activity
{
   
    private double _distance;

    // Constructor - passes date and minutes to base class, stores distance
    public Running(string date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    // Distance is stored directly, so just return it
    public override double GetDistance()
    {
        return _distance;
    }

    // Speed = (distance / minutes) * 60
    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60;
    }

    // Pace = minutes / distance
    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}