
// using System.Collections.Generic;

// namespace Deck_of_Cards
// {
//     public class Player
//     {
//         public string name;
//         private List<Card> hand;

//         public Player(string n)
//         {
//             hand = new List<Card>();
//             name = n;
//         }

//         public void DrawFrom(Deck currentDeck)
//         {
//             hand.Add(currentDeck.Deal());
//         }

//         public Card Discard(int idx)
//         {
//             Card temp = hand[idx];
//             hand.RemoveAt(idx);
//             return temp;
//         }
//     }
// }

using System.Collections.Generic;

namespace Deck_of_Cards
{
    public class Player
    {
        string name;
        public List<Card> hand;

        public Player(string person)
        {
            name = person;
            hand = new List<Card>();
        }

        public Card draw(Deck onDeck)
        {
            Card member = onDeck.deal();
            hand.Add(member);
            return member;
        }

        public Card discard(int i)
        {
            if (i < 0 || i > hand.Count)
            {

                return null;
            }
            else
            {
                //remove
                Card res = hand[i];
                hand.RemoveAt(i);
                return res;
            }
        }
    }
}