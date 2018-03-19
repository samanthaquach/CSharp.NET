using System;

namespace Human
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // creating objects
            Human firstborn = new Human("Ashley");
            // Console.WriteLine("This first born strength is " + firstborn.strength + "!");
            // Console.WriteLine("This first born intelligence is " + firstborn.intelligence + "!");
            // Console.WriteLine("This first born dexterity is " + firstborn.dexterity + "!");
            // Console.WriteLine("This first born health is " + firstborn.health + "!");
            // Console.WriteLine("This first born changed name to " + firstborn.name + "!");

            Human2 secondborn = new Human2("Robert");
            // Console.WriteLine("This second born strength is " + secondborn.strength + "!");
            // Console.WriteLine("This second born intelligence is " + secondborn.intelligence + "!");
            // Console.WriteLine("This second born dexterity is " + secondborn.dexterity + "!");
            // Console.WriteLine("This second born health is " + secondborn.health + "!");
            // Console.WriteLine("This second born changed name to " + secondborn.name + "!");
            // set attributes in my contructor
            // if check in my contructor

            string healthactivity = firstborn.Attack(secondborn, firstborn.strength);
            Console.WriteLine(healthactivity);
            // Console.WriteLine("{0}'s health is now: {1}", firstborn.name, firstborn.health);
            string healthactivity2 = secondborn.Attack(firstborn, secondborn.strength);
            Console.WriteLine(healthactivity2);




        }
    }
}
