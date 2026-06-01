// W03 Project: Scripture Memorizer Program
// Author : Onaimor Godspower
// Class : CSE 210 - Programming with Classes


// EXCEEDS REQUIREMENTS:
// 1. Scripture Library loaded from a scriptures.txt file
//    Instead of always memorizing the same scripture, the program loads a
//    list of scriptures from a file called scriptures.txt and picks one at
//    random each time the program runs. 

// 2. Only hides words that are not already hidden as part of the stretch challenge
//    The HideRandomWords method in Scripture.cs builds a list of only the
//    visible words and picks from those, so the same word is never hidden twice.

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = LoadScripture();

        // Keep going until all words are hidden or the user quits
        while (true)
        {
            Console.Clear();
            scripture.Display();

            // Stop the loop if every word is hidden
            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("You have hidden all the words. Great job!");
                break;
            }

            Console.Write("Press Enter to continue or type 'quit' to exit: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

        
            scripture.HideRandomWords();
        }
    }

    // Tries to load a scripture from the library file.
    // If the file is not found, falls back to a built  in default scripture.
    static Scripture LoadScripture()
    {
        ScriptureLibrary library = new ScriptureLibrary();
        library.LoadFromFile("scriptures.txt");

        if (library.HasScriptures())
        {
            return library.GetRandomScripture();
        }

        // Default fallback scripture if no file is found
        Reference reference = new Reference("John", 3, 16);
        return new Scripture(reference, "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life.");
    }
}