using System;
using System.Collections.Generic;

namespace BlackJack_Curtis
{
    public class Dealer
    {
        public Dealer()
        {
            _hand = new List<Card>();
            _shouldShowAllCards = false;
        }

        public void PutInHand(Card cardToHold)
        {
            _hand.Add(cardToHold);
        }

        public override string ToString()
        {
            if (_shouldShowAllCards)
            {
                return string.Join(", ", _hand);
            }
            else
            {
                return $"{_hand[0]}, ??????";
            }
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

        public bool HasNotGoneOver21()
        {
            return TotalOfHand() <= 21;
        }

        public bool HasGoneOver21()
        {
            return TotalOfHand() > 21;
        }

        public bool WantsAnotherCard()
        {
            return TotalOfHand() < 17;
        }

        public void ShowAllOfYourCards()
        {
            _shouldShowAllCards = true;
        }

        public List<Card> ClearYourHand()
        {
            _shouldShowAllCards = false;
            List<Card> oldHand = _hand;
            _hand = new List<Card>();
            return oldHand;
        }

        private List<Card> _hand;
        private bool _shouldShowAllCards;
    }
}
