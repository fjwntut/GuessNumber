using System;

namespace GuessNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerno, round, min = 0, max = 0, answer;
            string input;
            bool end = false;
            Console.WriteLine("Let's guess number!");

            int getNum(string q, int rmin = 0, int rmax = 0)
            {
                Console.Write(q);
                input = Console.ReadLine();
                if (input == "quit")
                {
                    Console.WriteLine("Game quitted");
                    Environment.Exit(0);
                    return 0;
                }
                else if (input == "r")
                {
                    Random random1 = new Random();
                    int i = random1.Next(rmin + 1, rmax);
                    Console.WriteLine("(" + i + ")");
                    return i;
                }
                else if (input == "m")
                {
                    return (rmin + rmax) / 2;
                }
                else
                {
                    try
                    {
                        return int.Parse(input);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Sorry, I dont understand. Please enter a integer, 'm' for mid number, 'r' for random integer, or 'quit' to quit the game. ");
                        int i = getNum(q, rmin, rmax);
                        return i;
                    }
                }

            }

            playerno = getNum("How many players do you have? ", rmax: 10);
            if (playerno < 2)
            {
                Console.WriteLine("I will play with you! Just type r in my turn.");
                playerno = 2;

            }
            min = getNum("Minimum number(exclusive): ", 0, 1);
            max = getNum("Maximum number(exclusive): ", min, 1000000);
            while (max - min < 2)
            {
                Console.WriteLine("The maximum number should be bigger than minimum number, try again!");
                min = getNum("Minimum number(exclusive): ", min, max);
                max = getNum("Maximum number(exclusive): ", min, max);
            }

            Console.WriteLine("We have " + playerno + " players, the answer is between " + max + " and " + min + ".");

            Console.Write("Generating random number......");
            Random random = new Random();
            answer = random.Next(min + 1, max);
            Console.WriteLine("DONE!!!\n Let's get started! ");

            round = 1;
            while (!end && round < 100)
            {
                Console.WriteLine("-------------ROUND " + round + "------------");
                for (int i = 1; i <= playerno; i++)
                {

                    int ii = getNum("Player " + i + ": ", min, max);
                    while (ii >= max || ii <= min)
                    {
                        ii = getNum("The answer should be between " + min + " and " + max + ", try again: ");
                    }
                    if (ii < answer)
                    {
                        min = ii;
                        Console.WriteLine("The answer is between " + min + " and " + max);
                    }
                    else if (ii > answer)
                    {
                        max = ii;
                        Console.WriteLine("The answer is between " + min + " and " + max);
                    }
                    else
                    {
                        Console.WriteLine("You LOSE!!! The answer is " + answer + ".");
                        end = true;
                        break;
                    }
                }
                round++;
            }

        }
    }
}