// Cycling activity - stores the speed in mph.

public class Cycling : Activity
{
    // Private member variable - speed is stored directly for cycling
    private double _speed;

    // Constructor - passes date and minutes to base class, stores speed
    public Cycling(string date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    // Distance = (speed * minutes) / 60
    public override double GetDistance()
    {
        return (_speed * GetMinutes()) / 60;
    }

    // Speed is stored directly, so just return it
    public override double GetSpeed()
    {
        return _speed;
    }

    // Pace = 60 / speed
    public override double GetPace()
    {
        return 60 / GetSpeed();
    }
}