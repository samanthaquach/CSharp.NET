using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {

            Human myPerson = new Human(5);
            Console.WriteLine(myPerson.health);

            Human2 myOther = new Human2(1);
            Console.WriteLine(myOther.strength);
            // public class Human
            // {
            //     public int name = 3;
            //     public int strength = 3;
            //     public int intelligence = 3;
            //     public int dexterity = 3;
            //     public int health = 100;

            // }


        }
    }
}
