// The responsibility of a Video is to track the title, author, and length
// of a YouTube video, and to store a list of comments left on that video.
public class Video
{
   
    public string _title  = "";
    public string _author = "";
    public int _length    = 0;

    // A list of comments left on this video
    public List<Comment> _comments = new List<Comment>();

    // Constructor to create a video with a title, author, and length
    public Video(string title, string author, int length)
    {
        _title  = title;
        _author = author;
        _length = length;
    }

    // Adds a comment to this video's list of comments
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Returns the number of comments on this video
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Displays the video details and all of its comments to the screen
    public void Display()
    {
        Console.WriteLine("Title:    " + _title);
        Console.WriteLine("Author:   " + _author);
        Console.WriteLine("Length:   " + _length + " seconds");
        Console.WriteLine("Comments: " + GetNumberOfComments());
        Console.WriteLine("--- Comment List ---");

        foreach (Comment comment in _comments)
        {
            Console.WriteLine("  " + comment._commenterName + ": " + comment._text);
        }

        Console.WriteLine();
    }
}