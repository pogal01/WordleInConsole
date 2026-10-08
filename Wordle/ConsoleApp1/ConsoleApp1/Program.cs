namespace ConsoleApp1
{
    internal class Program
    {
        public static List<string> Words = new List<string>(new string[] {"Games","Kirby","Mario","Sonic"});
        public static Random rand = new Random();
        public static string TheWord;
        public static bool ValidWordInputed = false;
        public static bool WordGuessedCorrectly = false;
        public static string Guess;
        public static int GuessLimit = 7;
        public static int Guesses;
        static void Main(string[] args)
        {
            TheWord = RandomiseWord();
            Guesses = 0;
            while (WordGuessedCorrectly == false)
            {
                ValidWordInputed = false;
                Console.WriteLine("Please guess a 5 letter word. any correct letters but in the wrong place will be yellow, in the right place they will be green but if they're not included they will stay white");
                Console.WriteLine("");
                while (ValidWordInputed == false)
                {
                    Guess = Console.ReadLine();
                    
                    if (Guess.Length != 5)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Please guess a 5 letter word. any correct letters but in the wrong place will be yellow, in the right place they will be green but if they're not included they will stay white");

                    }
                    else
                    {
                       WordGuessedCorrectly = ValidateAwnser();
                        if (WordGuessedCorrectly == true)
                        {
                            break;
                        }
                        ValidWordInputed = true;
                    }
                }
            }
          
           


        }

        static string RandomiseWord()
        {
            return Words[rand.Next(0, Words.Count - 1)];


        }

        public static bool ValidateAwnser()
        {
            int Index = 0; 
            foreach(char letter in Guess)
            {
                if(Guess == TheWord)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(Guess);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("");
                    Console.WriteLine("Congratulations you gussed the word");
                    return true;
                }

                if(TheWord.Contains(letter) == true && TheWord[Index] == letter)
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                }
                else if(TheWord.Contains(letter) == true && TheWord[Index] != letter)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
                else if(TheWord.Contains(letter) == false)
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    //Console.WriteLine("Letter " + letter + " Isn't included");
                }

                Console.Write(letter);
                Console.ForegroundColor = ConsoleColor.Gray;
                Index++;
            }
            Console.WriteLine("");
            Guesses++;
            if(Guesses == GuessLimit)
            {
                Console.WriteLine("Guesses " + Guesses + " " + GuessLimit);
                Console.WriteLine("You have used all your guesses");
                

            }
            else
            {
                Console.WriteLine("Guesses " + Guesses + "/" + GuessLimit);
            }
            return false;

        }

    }
}
