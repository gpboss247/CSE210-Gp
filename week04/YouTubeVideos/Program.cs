// W04 Foundation Program 1: YouTube Videos
// Demonstrates the principle of Abstraction.
// This program creates a list of YouTube videos and the comments on them,
// then displays each video along with its details and comments.

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold all the videos
        List<Video> videos = new List<Video>();

        // Video 1 
        Video video1 = new Video("10 Tips for Learning C#", "CodeWithMosh", 742);
        video1.AddComment(new Comment("JaneDev", "This helped me so much, thank you!"));
        video1.AddComment(new Comment("AlexCodes", "Tip number 7 was a game changer for me."));
        video1.AddComment(new Comment("SarahT", "Could you do a follow up video on classes?"));
        video1.AddComment(new Comment("MikeR", "Best C# tutorial I have found so far."));
        videos.Add(video1);

        // Video 2 
        Video video2 = new Video("Morning Routine for Productivity", "LifeWithLaura", 518);
        video2.AddComment(new Comment("TomW", "I tried this and felt so much better!"));
        video2.AddComment(new Comment("EmmaJ", "The journaling step really works."));
        video2.AddComment(new Comment("BenH", "What planner are you using in the video?"));
        videos.Add(video2);

        // Video 3 
        Video video3 = new Video("How to Make Sourdough Bread", "BakingWithBob", 1203);
        video3.AddComment(new Comment("FoodieAna", "Mine came out perfect on the first try!"));
        video3.AddComment(new Comment("ChefKris", "Great explanation of the fermentation step."));
        video3.AddComment(new Comment("NathanB", "Can I use whole wheat flour instead?"));
        video3.AddComment(new Comment("LisaM", "I have been baking sourdough for years and this is the clearest tutorial I have seen."));
        videos.Add(video3);

        // Video 4
        Video video4 = new Video("Understanding the Stock Market", "InvestSmart", 965);
        video4.AddComment(new Comment("RyanP", "Finally a video that explains this simply."));
        video4.AddComment(new Comment("OliviaK", "I wish I had found this before I started investing."));
        video4.AddComment(new Comment("DanielF", "What app do you recommend for beginners?"));
        videos.Add(video4);

        // Display all videos 
        Console.WriteLine("===== YouTube Video Report =====");
        Console.WriteLine();

        foreach (Video video in videos)
        {
            video.Display();
        }
    }
}