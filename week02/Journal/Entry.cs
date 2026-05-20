// This class holds the information for one journal entry.
public class Entry
{

    public string _date = "";
    public string _prompt = "";
    public string _response = "";
    public string _mood = ""; // EXCEEDS REQUIREMENT: stores the user's mood with each entry

    // Constructor to set up a new entry with all its information
    public Entry(string date, string prompt, string response, string mood)
    {
        _date     = date;
        _prompt   = prompt;
        _response = response;
        _mood     = mood;
    }


    public string GetEntryText()
    {
        return _date + "|" + _prompt + "|" + _response + "|" + _mood;
    }

    public void Display()
    {
        Console.WriteLine("Date:     " + _date);
        Console.WriteLine("Mood:     " + _mood);
        Console.WriteLine("Prompt:   " + _prompt);
        Console.WriteLine("Response: " + _response);
        Console.WriteLine("------------------------------");
    }
}