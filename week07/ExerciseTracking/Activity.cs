// Abstract base class for all exercise activities.
// The responsibility of Activity is to hold the shared attributes (date and
// minutes) and define the contract that every child class must fulfill.

public abstract class Activity
{
   
    private string _date;
    private int _minutes;

  
    public Activity(string date, int minutes)
    {
        _date    = date;
        _minutes = minutes;
    }

    // Getters - child classes and GetSummary need to read these
    public string GetDate()
    {
        return _date;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    // Abstract methods - every child class MUST provide its own version.
    // The spec says to declare but not implement these in the base class.
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // GetSummary is defined once here in the base class.
    // It calls GetDistance(), GetSpeed(), and GetPace() which are abstract —
    // so polymorphism automatically calls the correct child version at runtime.
    public string GetSummary()
    {
        return _date + " " + GetType().Name + " (" + _minutes + " min)" +
               " - Distance: " + Math.Round(GetDistance(), 1) + " miles," +
               " Speed: " + Math.Round(GetSpeed(), 1) + " mph," +
               " Pace: " + Math.Round(GetPace(), 2) + " min per mile";
    }
}