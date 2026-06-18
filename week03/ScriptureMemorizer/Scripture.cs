// This class represents a complete scripture with its reference and text.
// The responsibility of Scripture is to display itself and manage
// the process of hiding words during memorization practice.
public class Scripture
{
    // Private member variables
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    // Constructor - takes a Reference and the full scripture text as a string.
    // It breaks the text into individual Word objects automatically.
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _random    = new Random();
        _words     = new List<Word>();

        // Split the text into individual words and create a Word object for each one
        string[] wordArray = text.Split(' ');
        foreach (string w in wordArray)
        {
            _words.Add(new Word(w));
        }
    }

    // Displays the scripture reference and text to the screen.
    // Words that have been hidden will show as underscores.
    public void Display()
    {
        Console.WriteLine(_reference.GetDisplayText());
        Console.WriteLine(GetScriptureText());
        Console.WriteLine();
    }

    // Hides a few random words that are not already hidden.
    // EXCEEDS: only picks from words that are still visible - as part of the stretch challenge
    public void HideRandomWords()
    {
        // Build a list of only the words that are not yet hidden
        List<Word> visibleWords = new List<Word>();
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWords.Add(word);
            }
        }

        // Hide up to 3 random words from the visible ones
        int wordsToHide = 3;
        if (visibleWords.Count < wordsToHide)
        {
            wordsToHide = visibleWords.Count;
        }

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    // Returns true when every word in the scripture has been hidden
    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

    // Builds and returns the full scripture text with hidden words as underscores.
    
    private string GetScriptureText()
    {
        string result = "";
        for (int i = 0; i < _words.Count; i++)
        {
            if (i > 0)
            {
                result += " ";
            }
            result += _words[i].GetDisplayText();
        }
        return result;
    }
}