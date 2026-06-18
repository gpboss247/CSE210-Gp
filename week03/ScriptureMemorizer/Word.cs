// This class represents one word in a scripture.
// to store the word text and track whether that word has been hidden during the memorization game.
public class Word
{
    // Private member variables
    private string _text;
    private bool _isHidden;

    // Constructor - every Word starts visible and not hidden
    public Word(string text)
    {
        _text     = text;
        _isHidden = false;
    }

    // Hides this word so it shows as underscores
    public void Hide()
    {
        _isHidden = true;
    }

    // Returns true if this word has already been hidden
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Returns the word for display.
    // If the word is hidden, returns underscores matching the word length.
    // If the word is visible, returns the original text.
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            
            string underscores = "";
            for (int i = 0; i < _text.Length; i++)
            {
                underscores += "_";
            }
            return underscores;
        }
        else
        {
            return _text;
        }
    }
}