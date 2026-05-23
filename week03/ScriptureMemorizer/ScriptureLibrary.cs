// EXCEEDS REQUIREMENTS: This class loads a library of scriptures from a file
// and picks one at random to present to the user. also using that same methods for the class 
// will also reference the output of the internal claas to the output of the function 
public class ScriptureLibrary
{
   
    private List<Scripture> _scriptures;
    private Random _random;

   
    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
        _random     = new Random();
    }

    // Loads scriptures from a text file.
    
    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("Scripture file not found: " + filename);
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            // Skip blank lines
            if (line.Trim() == "")
            {
                continue;
            }

            // Split the line into reference part and text part using |
            string[] parts = line.Split('|');
            if (parts.Length < 2)
            {
                continue;
            }

            string referencePart = parts[0].Trim();
            string text          = parts[1].Trim();

           
            int lastSpace    = referencePart.LastIndexOf(' ');
            string book      = referencePart.Substring(0, lastSpace);
            string chapterVerse = referencePart.Substring(lastSpace + 1);

            
            string[] chapterVerseParts = chapterVerse.Split(':');
            int chapter = int.Parse(chapterVerseParts[0]);
            string versePart = chapterVerseParts[1];

            
            if (versePart.Contains('-'))
            {
                string[] verseRange = versePart.Split('-');
                int startVerse = int.Parse(verseRange[0]);
                int endVerse   = int.Parse(verseRange[1]);
                Reference reference = new Reference(book, chapter, startVerse, endVerse);
                _scriptures.Add(new Scripture(reference, text));
            }
            else
            {
                int verse = int.Parse(versePart);
                Reference reference = new Reference(book, chapter, verse);
                _scriptures.Add(new Scripture(reference, text));
            }
        }
    }


    public bool HasScriptures()
    {
        return _scriptures.Count > 0;
    }

    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}