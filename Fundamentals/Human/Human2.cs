namespace Human
{

    public class Human2 {

        // second contstructor
        public string name;
        public int strength = 4; // default values of 4
        public int intelligence = 4;
        public int dexterity = 4;
        public int health = 100; // defaul values of 100


        public Human2(string str)
        {
            name = str;
        }

        //setting attributes
        public Human2(int val)
        {
            strength = val;
            intelligence = val;
            dexterity = val;
            health = val;
        }

        public string Attack(object thing, int damage)
        {
            if (thing is Human)
            {
                Human person = (Human)thing;
                damage = strength * 5;
                person.health -= damage;
                strength += 1;
                // return ("person");
                return $"{person.name} was damaged {damage}. Health is now {person.health}. {name}'s strength is now {strength}.";
            }
            else
            {
                return ("Not attacking human!");
            }
        }



    }
}