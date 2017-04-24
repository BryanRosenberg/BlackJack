using System;
using System.Collections.Generic;

namespace BlackJack_Curtis
{
    public class Player
    {
        public Player()
        {
            _hand = new List<Card>();
        }

        public void PutInHand(Card cardToHold)
        {
            _hand.Add(cardToHold);
        }


        public override string ToString()
        {
            return string.Join(", ", _hand);
        }


        public bool WantsAnotherCard()
        {
            Console.WriteLine("Would you like another card? (y/n)");
            string input = Console.ReadLine().ToLower();
            while (input != "y" && input != "n")
            {
                Console.WriteLine("Please enter 'y' or 'n'");
                input = Console.ReadLine().ToLower();
            }
            return input == "y";
        }

        public List<Card> ClearYourHand()
        {
            List<Card> oldHand = _hand;
            _hand = new List<Card>();
            return oldHand;
        }

        public bool HasGoneOver21()
        {
            return TotalOfHand() > 21;
        }

        public bool HasNotGoneOver21()
        {
            return TotalOfHand() <= 21;
        }

        public int TotalOfHand()
        {
            int totalOfHand = 0;
            foreach (Card card in _hand)
            {
                totalOfHand += card.GetValue();
            }
            return totalOfHand;
        }

        private List<Card> _hand;

    }
}
