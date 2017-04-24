using System;
using System.Collections.Generic;

namespace BlackJack_Curtis
{
    public abstract class Card
    {
        public Card(string name, string suit, int value)
        {
            _name = name;
            _suit = suit;
            _value = value;
        }

        public override string ToString()
        {
            return $"{_name} of {_suit}";
        }

        public int GetValue()
        {
            return _value;
        }

        private string _name;
        private string _suit;
        private int _value;
    }
}
