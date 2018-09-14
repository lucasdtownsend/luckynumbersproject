using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luckynumbersproject
{
    class Program
    {
        static void Main(string[] args)
        {
            int jackpot = 100;
            Console.WriteLine("Welcome to Lucky Number Guessing Game! Today's jackpot is $" + jackpot + ".");
            Console.WriteLine("Please enter the lowest possible number.");
            int min = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the highest possible number.");
            int max = int.Parse(Console.ReadLine());
            Console.WriteLine("Now input six numbers between " + min + " and " + max + ". Press Enter after each number. Do not enter the same number more than once.");
            int[] userNumbers = new int[6];
            for (int i = 0; i < userNumbers.Length; i++)
            {
                string input = Console.ReadLine();
                int inputNum = int.Parse(input);
                while (inputNum < min || inputNum > max)
                {
                    Console.WriteLine("Number outside of range. Please enter number between " + min + " and " + max + ".");
                    inputNum = int.Parse(Console.ReadLine());
                }
                userNumbers[i] = inputNum;
            }

            int[] randomNumbers = new int[6];
            Random randoCalrissian = new Random();
            for (int i = 0; i < randomNumbers.Length; i++)
            {
                int rand = randoCalrissian.Next(min, max + 1);
                while (randomNumbers.Contains(rand))
                {
                    rand = randoCalrissian.Next(min, max + 1);
                }
                randomNumbers[i] = rand;
            }
            int wins = 0;
            foreach (int num in userNumbers)
            {
                if (randomNumbers.Contains(num))
                {
                    wins++;
                }
                else { }
            }
            Console.WriteLine();
            foreach (int num in randomNumbers)
            {
                Console.WriteLine("Lucky Number: " + num);
            }
            Console.WriteLine();
            Console.WriteLine(wins + " correct matches!");
            int winningsShare = userNumbers.Length + 1 - wins;
            int payout = jackpot / winningsShare;
            Console.WriteLine("Your winnings: $" + payout);
            Console.WriteLine("Would you like to play again? Type yes or no.");
            string playAgain = Console.ReadLine();
            if (playAgain == "no")
            {
                Console.WriteLine("Thanks for playing!");
                Environment.Exit(0);
            }
            else if (playAgain == "yes")
            {
                string[] restart = new string[0];
                Main(restart);
            }
        }
    }
}