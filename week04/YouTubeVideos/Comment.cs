// The responsibility of a Comment is to store the name of the person
// who made the comment and the text of the comment.
public class Comment
{
    
    public string _commenterName = "";
    public string _text = "";

    // Constructor to create a comment with a name and text
    public Comment(string commenterName, string text)
    {
        _commenterName = commenterName;
        _text          = text;
    }
}