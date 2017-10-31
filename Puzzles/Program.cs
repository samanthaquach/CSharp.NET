using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            randomArray();
            TossMultipleCoins(100);
        }
        static void randomArray()
        {
            Console.WriteLine("Random Array");
            // Random Array
            // Create a function called RandomArray() that returns an integer array  
            List<int> randlist = new List<int>();

            Random rand = new Random();
            for (int x = 0; x < 10; x++)
            {
                randlist.Add(rand.Next(5, 25));
            }
            int[] numArray = randlist.ToArray();

            foreach (int value in randlist)
            {
                Console.WriteLine(value);
            }

            //Print the min and max values of the array
            //Print the sum of all the values
            int max = numArray[0];
            int min = numArray[0];
            int sum = numArray[0];
            for (int i = 1; i < numArray.Length; i++)
            {
                if (numArray[i] < min)
                {
                    min = numArray[i];
                }
                if (numArray[i] > max)
                {
                    max = numArray[i];
                }
                sum += numArray[i];
            }
            Console.WriteLine("Min = " + min + " Max = " + max + ".");
            Console.WriteLine("Sum of array values = " + sum + ".");

        }

        public static string TossCoin()
        {
            Console.WriteLine("Tossing Coin!");
            //Create a function called TossCoin() that returns a string
            //Have the function print "Tossing a Coin!"
            //Randomize a coin toss with a result signaling either side of the coin 
            //Have the function print either "Heads" or "Tails"
            //Finally, return the result

            //Create another function called TossMultipleCoins(int num) that returns a Double
            //Have the function call the tossCoin function multiple times based on num value
            //Have the function return a Double that reflects the ratio of head toss to total toss

            List<int> randlist = new List<int>();

            Random rand = new Random();

            for (int x = 0; x < 100; x++)
            {
                randlist.Add(rand.Next(5, 1000));
            }
            int[] numArray = randlist.ToArray();
            int sum = numArray[0];

            for (int i = 0; i < numArray.Length; i++)
            {
                sum += numArray[i];
            }

            int randcoin = sum * 101;
            randcoin = randcoin / 51;
            Console.WriteLine(randcoin);

            string coin;

            if (randcoin % 2 != 0)
            {
                coin = "Heads";
            }
            else
            {
                coin = "Tails";
            }
            Console.WriteLine("Your toss was : " + coin);
            return coin;
        }
        public static double TossMultipleCoins(int num)
        {
            Console.WriteLine("Tossing a Coin " + num + " times");
            // Create another function called TossMultipleCoins(int num) that returns a Double
            // Have the function call the tossCoin function multiple times based on num value

            double headcount = 0;
            double tailcount = 0;
            double ratioheadstotails = 0;

            Random rand = new Random();

            for (int x = 0; x < num; x++)
            {
                int currrand = rand.Next(5, 1000);
                if (currrand % 2 == 0)
                {
                    headcount++;
                }
                else
                {
                    tailcount++;
                }
            }

            // Have the function return a Double that reflects the ratio of head toss to total toss
            Console.WriteLine("Getting ratio of heads to tails... ");
            ratioheadstotails = (headcount / tailcount) * 100;
            ratioheadstotails = Math.Round(ratioheadstotails, 2);
            Console.WriteLine("You asked to flip " + num + " coins. Done! Ratio of heads to tails was " + ratioheadstotails + "% heads to tails. I counted " + headcount + " heads and " + tailcount + " tails.");

            return ratioheadstotails;
        
        }
        public static string [] Names()
        {
            string[] names = new string[5] { "Todd", "Tiffany", "Charlie", "Geneva", "Sydney" };
            Random rand = new Random();
            for (var i = 0; i < names.Length - 1; i++)
            {
                int random = rand.Next(i + 1, names.Length - 1);
                string temp = names[i];
                names[i] = names[random];
                names[random] = temp;
                Console.WriteLine(names[i]);
            }
            Console.WriteLine(names[names.Length - 1]);

            List<string> nameList = new List<string>();
            foreach (var name in names)
            {
                nameList.Add(name);
            }
            return nameList.ToArray();

        }
        
    }
}
