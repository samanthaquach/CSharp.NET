using System;
using System.Collections.Generic;

namespace Deck_of_Cards
{
    public class Card
    {
        public string stringVal;
        public string suit;
        public int val;

        public Card(string name, string suitType, int value)
        {
            stringVal = name;
            suit = suitType;
            val = value;
        }
    }
    public class Deck
    {
        public List<Card> cards;

        public Deck()
        {
            reset();
            shuffle();
        }
        public Deck reset()
        {
            cards = new List<Card>();
            string[] suits = { "hearts", "diamonds", "spades", "clubs" };
            string[] stringVals = { "Ace", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "Jack", "Queen", "King" };
            // ----------- assembling the cards --------------
            foreach (string suit in suits)
            {
                // --------- building deck ---------
                for (int i = 0; i < stringVals.Length; i++)
                {
                    Card member = new Card(stringVals[i], suit, i + 1);
                    cards.Add(member);
                }
            }
            return this;
        }
        public Deck shuffle()
        {
            //-------- iterating --------
            Random rand = new Random();
            for (int end = cards.Count - 1; end > 0; end--)
            {
                // ------- grab a random card -------
                int randx = rand.Next(end);
                Card temp = cards[randx];
                // ------ swap it with out end value ------
                cards[randx] = cards[end];
                cards[end] = temp;
            }
            return this;
        }
        public Card deal()
        {
            if (cards.Count > 0)
            {

                //------- grab top card -------
                Card res = cards[0];
                //------ remove said card -----
                cards.RemoveAt(0);
                //----- return said card -------
                return res;
            }
            else
            {
                reset();
                return deal();
            }
        }
    }
}