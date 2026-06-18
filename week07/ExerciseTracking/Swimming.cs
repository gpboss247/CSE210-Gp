// Swimming activity - stores the number of laps completed.

public class Swimming : Activity
{
    // Private member variable - number of laps is stored directly for swimming
    private int _laps;

    // Constructor - passes date and minutes to base class, stores laps
    public Swimming(string date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    // Distance (miles) = laps * 50 / 1000 * 0.62
    public override double GetDistance()
    {
        return _laps * 50.0 / 1000.0 * 0.62;
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