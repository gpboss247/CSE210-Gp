using System;

class Program
{
    static void Main(string[] args)
    {
       Random randomGenerator = new Random();
       int MagicNumber = randomGenerator.Next(1,101);

       int guess = -1;

       while (guess != MagicNumber)
       {
        Console.Write("What is your guess? ");
        guess = int.Parse(Console.ReadLine());

        if (MagicNumber > guess)
            {
                Console.WriteLine("guess higher");
            }
            else if (MagicNumber < guess)
            {
                Console.WriteLine("guess lower");
            }
            else
            {
                Console.WriteLine("you guessed it!");
            }

            
        }






    }
}