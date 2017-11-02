using System;

namespace Deck_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck theDeck = new Deck();
            Player one = new Player("Sam");
            Console.WriteLine(theDeck.cards.Count);

            one.draw(theDeck);
            Console.WriteLine(one.hand.Count);
            one.draw(theDeck);
            one.draw(theDeck);
            one.draw(theDeck);
            one.draw(theDeck);
            one.draw(theDeck);
            one.draw(theDeck);
            one.draw(theDeck);
            one.draw(theDeck);
            Console.WriteLine(one.hand.Count);
            one.discard(4);
            Console.WriteLine(one.hand.Count);

        }
    }
}
