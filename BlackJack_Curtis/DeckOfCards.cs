using System;
using System.Collections.Generic;

namespace BlackJack_Curtis
{
    public class DeckOfCards
    {
        public DeckOfCards()
        {
            _cards = new List<Card>();

            string[] suits = new string[]
            {
                "Hearts", "Spades", "Diamonds", "Clubs"
            };

            int[] values = new int[]
            {
                2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            foreach (string suit in suits)
            {
                _cards.Add(new AceCard(suit));

                foreach (int value in values)
                {
                    _cards.Add(new NumberCard(suit, value));
                }

                _cards.Add(new FaceCard("Jack", suit));
                _cards.Add(new FaceCard("Queen", suit));
                _cards.Add(new FaceCard("King", suit));
            }
        }

        public Card GiveMeTopCard()
        {
            Card card = _cards[0];
            _cards.RemoveAt(0);
            return card;
        }
        
        public void Shuffle()
        {
            Random random = new Random();
            for (int i = 0; i < 7; i += 1)
            {
                List<Card> left = new List<Card>();
                List<Card> right = new List<Card>();

                //Split cards into 2 piles
                for (int cardIndex = 0; cardIndex < _cards.Count / 2; cardIndex += 1)
                {
                    Card cardToMove = _cards[cardIndex];
                    left.Add(cardToMove);
                }
                for (int cardIndex = _cards.Count / 2; cardIndex < _cards.Count; cardIndex += 1)
                {
                    Card cardToMove = _cards[cardIndex];
                    right.Add(cardToMove);
                }

                _cards.Clear();

                while (left.Count > 0 || right.Count > 0)
                {
                    if (left.Count == 0)
                    {
                        _cards.AddRange(right);
                        right.Clear();
                    }
                    else if (right.Count == 0)
                    {
                        _cards.AddRange(left);
                        left.Clear();
                    }
                    else
                    {
                        int choice = random.Next(2);
                        if (choice == 0)
                        {
                            Card card = left[0]; // Selects first card
                            left.RemoveAt(0); // Removes it from the left deck
                            _cards.Add(card); // Adds it to the main deck
                        }
                        else
                        {
                            Card card = right[0]; // Selects first card
                            right.RemoveAt(0); // Removes it from the right deck
                            _cards.Add(card); // Adds it to the main deck
                        }
                    }
                }
            }

            Console.WriteLine($"You have {_cards.Count} cards");

            foreach (Card card in _cards)
            {
                Console.WriteLine(card);
            }
            Console.ReadLine();
        }
        
        public bool AreYouEmpty()
        {
            return _cards.Count == 0;
        }

        public void Restock(List<Card> discardPile)
        {
            _cards.AddRange(discardPile);
        }

        private List<Card> _cards;

    }
}