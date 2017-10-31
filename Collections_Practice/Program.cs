using System;
using System.Collections.Generic;

namespace Collections_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOfInts = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] myNames = { "Tim", "Martin", "Nikki", "Sara" };

            bool[] array = new bool[10];
            array [0] = true;
            array [2] = true;
            array [4] = true;
            array [6] = true;
            array [8] = true;
            foreach (bool value in array)
            {
                Console.WriteLine(value);
            }
            for (int i = 0; i < array.Length; i += 2)
            {
                array[i] = true;
            }

            for (int i = 0; i <= 10; i++)
            {
                Console.Write(i + "\t");
                for (int j = 1; j <= 10; j++)
                {
                    if (i > 0) Console.Write(i * j + "\t");
                    else Console.Write(j + "\t");
                }
                Console.Write("\n");
            }
            List<string> icecream = new List<string>();
            icecream.Add("vanilla");
            icecream.Add("matcha");
            icecream.Add("chocolate");
            icecream.Add("lemon");
            icecream.Add("strawberry");
            Console.WriteLine(icecream.Count);
            Console.WriteLine(icecream[3]);
            icecream.Remove("lemon");
            Console.WriteLine(icecream.Count);

            Dictionary<string, string> profile = new Dictionary<string, string>();
            profile.Add("Tim", "Vanilla");
            profile.Add("Martin", "Matcha");
            profile.Add("Nikki", "Chocolate");
            profile.Add("Sara", "Lemon");
            foreach (KeyValuePair<string, string> entry in profile)
            {
                Console.WriteLine(entry.Key + " - " + entry.Value);
            }
        }

    }
}
