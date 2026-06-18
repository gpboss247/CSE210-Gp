// This class holds the reference for a scripture
// To store and display the scripture reference.
public class Reference
{
    // Private member variables - only this class can access them directly
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    // Constructor for a single verse like john 3:16
    public Reference(string book, int chapter, int verse)
    {
        _book       = book;
        _chapter    = chapter;
        _startVerse = verse;
        _endVerse   = verse;
    }

    // Constructor for a verse range like Proverbs 3:5-6
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book       = book;
        _chapter    = chapter;
        _startVerse = startVerse;
        _endVerse   = endVerse;
    }

    // Returns the reference as a readable string like "John 3:16" or "Proverbs 3:5-6"
    public string GetDisplayText()
    {
        if (_startVerse == _endVerse)
        {
            return _book + " " + _chapter + ":" + _startVerse;
        }
        else
        {
            return _book + " " + _chapter + ":" + _startVerse + "-" + _endVerse;
        }
    }
}