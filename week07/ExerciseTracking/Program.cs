// W07 Foundation Program: Exercise Tracking
// Author : Onaimor Godspower
// Class : CSE210
// Demonstrates the principles of Inheritance and Polymorphism.


class Program
{
    static void Main()
    {
        // Create a list to hold all activity types together
        List<Activity> activities = new List<Activity>();

        // Create at least one of each activity type and add to the list
        activities.Add(new Running("03 Nov 2022", 30, 3.0));
        activities.Add(new Running("10 Nov 2022", 45, 5.5));
        activities.Add(new Cycling("05 Nov 2022", 30, 12.0));
        activities.Add(new Cycling("12 Nov 2022", 60, 15.0));
        activities.Add(new Swimming("07 Nov 2022", 30, 20));
        activities.Add(new Swimming("14 Nov 2022", 45, 30));

        // Polymorphism: same GetSummary() call works for every activity type
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}