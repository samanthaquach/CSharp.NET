namespace Human{

    public class Human
    {
        public int name = 3;
        public string first = "Ashley";
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;

        public Human(int val)
        {
            health = health - val;
        }

    }

    public class Human2
    {
        public string name = "Bob";
        public int strength = 3;
        public int health = 100;

        public Human2(int val)
        {
            strength = strength - val;
        }
    }




    // public class Human : System.Attribute{
    //     private string name;
    //     private string strength;
    //     private string intelligence;
    //     private string dexterity;
    //     public Human(string name, string strength, string intelligence, string dexterity)
    //     {
    //         this.name = name;
    //         this.strength = strength;
    //         this.intelligence = intelligence;
    //         this.dexterity = dexterity;
    //     }
    // }
}
