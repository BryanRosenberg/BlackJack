using System;
using System.Collections.Generic;

namespace BlackJack_Curtis
{
    public class BlackJackGame
    {
        public void Play()
        {
            _discardPile = new List<Card>();
            
            // create a player
            _player = new Player();

            // create a dealer;
            _dealer = new Dealer();

            // create some cards
            _deck = new DeckOfCards();
            _deck.Shuffle(); // Changes the state of the deck but don't want a return

            while (true)
            {
                List<Card> discards;
                discards = _player.ClearYourHand();
                _discardPile.AddRange(discards);
                discards = _dealer.ClearYourHand();
                _discardPile.AddRange(discards);

                // deal cards
                Card cardToDeal;

                cardToDeal = GetTopCardFromDeck();
                _player.PutInHand(cardToDeal);

                cardToDeal = GetTopCardFromDeck();
                _dealer.PutInHand(cardToDeal);

                cardToDeal = GetTopCardFromDeck();
                _player.PutInHand(cardToDeal);

                cardToDeal = GetTopCardFromDeck();
                _dealer.PutInHand(cardToDeal);

                // print the state of the game
                PrintTheGame();

                // hit the player until they don't wanna be hit no more
                while (_player.HasNotGoneOver21() && _player.WantsAnotherCard())
                {
                    cardToDeal = GetTopCardFromDeck();
                    _player.PutInHand(cardToDeal);
                    PrintTheGame();
                }

                // stop if the player busts
                if (_player.HasGoneOver21())
                {
                    PrintTheGame();
                    Console.WriteLine("You're busted.");
                }
                else
                {
                    _dealer.ShowAllOfYourCards();
                    // hit the dealer until is over 17
                    while (_dealer.HasNotGoneOver21() && _dealer.WantsAnotherCard())
                    {
                        cardToDeal = GetTopCardFromDeck();
                        _dealer.PutInHand(cardToDeal);
                    }
                    PrintTheGame();
                    if (_dealer.HasGoneOver21())
                    {
                        Console.WriteLine("You win, human.");
                    }
                    else
                    {
                        if (_player.TotalOfHand() >= _dealer.TotalOfHand())
                        {
                            Console.WriteLine("You win.");
                        }
                        else
                        {
                            Console.WriteLine("You lose.");
                        }
                    }
                }

                // figure out the winner


                // see if the player wants to go another hand
                Console.WriteLine("Would you like to play again? (y/n)");
                string input = Console.ReadLine().ToLower();
                while (input != "y" && input != "n")
                {
                    Console.WriteLine("Please enter 'y' or 'n'");
                    input = Console.ReadLine().ToLower();
                }
                if (input == "n")
                {
                    break;
                }
            }
        }

        private Card GetTopCardFromDeck()
        {
            if (_deck.AreYouEmpty())
            {
                _deck.Restock(_discardPile);
                _discardPile.Clear();
                _deck.Shuffle();
            }
            return _deck.GiveMeTopCard();
        }

        private void PrintTheGame()
        {
            Console.Clear();
            Console.WriteLine(_dealer);
            Console.WriteLine(_player);
        }

        private Player _player;
        private Dealer _dealer;
        private DeckOfCards _deck;
        private List<Card> _discardPile;
    }
}