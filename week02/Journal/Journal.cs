// This class manages a list of journal entries.
public class Journal
{
    // Member variable - the list that holds all entries
    public List<Entry> _entries = new List<Entry>();

    // Adds a new entry to the journal
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // Displays all entries in the journal to the screen
    public void Display()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            return;
        }

        Console.WriteLine("===== Journal Entries =====");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Saves all entries to a text file
    public void Save(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.GetEntryText());
            }
        }

        Console.WriteLine("Journal saved to " + filename);
    }

    // Loads entries from a text file and replaces the current journal
    public void Load(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found: " + filename);
            return;
        }

        _entries.Clear();

        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');

            if (parts.Length >= 4)
            {
                string date     = parts[0];
                string prompt   = parts[1];
                string response = parts[2];
                string mood     = parts[3];

                Entry entry = new Entry(date, prompt, response, mood);
                _entries.Add(entry);
            }
        }

        Console.WriteLine("Journal loaded from " + filename);
    }

    // EXCEEDS REQUIREMENTS: Displays a statistics summary of the journal.
    // Shows total entries, total words, average words per entry,
    // and a breakdown of moods recorded across all entries.
    public void ShowStats()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to show statistics for.");
            return;
        }

        int totalWords    = 0;
        int happyCount    = 0;
        int contentCount  = 0;
        int neutralCount  = 0;
        int stressedCount = 0;
        int sadCount      = 0;

        foreach (Entry entry in _entries)
        {
            string[] words = entry._response.Split(' ');
            totalWords += words.Length;

            if (entry._mood == "Happy")    happyCount++;
            if (entry._mood == "Content")  contentCount++;
            if (entry._mood == "Neutral")  neutralCount++;
            if (entry._mood == "Stressed") stressedCount++;
            if (entry._mood == "Sad")      sadCount++;
        }

        double avgWords = (double)totalWords / _entries.Count;

        Console.WriteLine("===== Journal Statistics =====");
        Console.WriteLine("Total entries: "           + _entries.Count);
        Console.WriteLine("Total words written: "     + totalWords);
        Console.WriteLine("Average words per entry: " + avgWords);
        Console.WriteLine("--- Mood Breakdown ---");
        Console.WriteLine("Happy: "    + happyCount);
        Console.WriteLine("Content: "  + contentCount);
        Console.WriteLine("Neutral: "  + neutralCount);
        Console.WriteLine("Stressed: " + stressedCount);
        Console.WriteLine("Sad: "      + sadCount);
        Console.WriteLine("------------------------------");
    }
}