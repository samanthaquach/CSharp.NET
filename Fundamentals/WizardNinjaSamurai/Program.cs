using System;

namespace WizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Kid = new Human("Kid");
            Wizard Harry = new Wizard("Harry");
            Ninja Mitch = new Ninja("Mitch");
            Samurai Duff = new Samurai("Duff");


            // ----------------------------------- Game to see points ----------------------
            Mitch.Steal(Harry);
            Console.WriteLine("Mitch steals from {0}. {1} goes to Mitch!", Harry.name, Mitch.health);
            Mitch.get_away();
            Console.WriteLine("Mitch tries to get away! Health decrease {0}", Mitch.health);
            Harry.fireball(Mitch);
            Console.WriteLine("Harry fire back at {0}, and {0} health decrease to {1}", Mitch.name, Mitch.health);
            Duff.meditate();
            Console.WriteLine("Duff does not want to fight! His health is {0}", Duff.health);

            // Console.WriteLine(count);
            // Duff.how_many();
        }
    }
}
