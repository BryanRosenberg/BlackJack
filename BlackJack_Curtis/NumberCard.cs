namespace BlackJack_Curtis
{
    public class NumberCard : Card
    {
        public NumberCard(string suit, int value)
            : base(value.ToString(), suit, value)
        {
        }
    }
}