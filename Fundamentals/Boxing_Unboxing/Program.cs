using System;
using System.Collections.Generic;


namespace Boxing_Unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            List<object> stuff = new List<object>();
            stuff.Add(7);
            stuff.Add(28);
            stuff.Add(-1);
            stuff.Add(true);
            stuff.Add("Chair");

            object ActuallyString = "Chair";
            string ExplicitString = ActuallyString as string;

            var sum = 0;
            foreach (var item in stuff)
            {
                if (item is int)
                {
                    int a = (int)item;
                    sum += a;

                    // Console.WriteLine("No. it's not string!");
                    Console.WriteLine(sum);
                }
                // if (item is string)
                // {
                //     Console.WriteLine("Yes. it's string!");
                // }


            } 
            }
        }
    }

