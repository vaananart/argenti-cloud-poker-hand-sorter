namespace PokerHandDomainModels
{
	public class CardModel
	{
		public CardModel(string cardString)
		{
			this.Value = cardString != null ? cardString[0] : char.MinValue;
			this.Suit = cardString != null ? cardString[1] : char.MinValue;
		}

		public char  Value { get; private set; }
		public char Suit { get; private set; }

		public override string ToString()
		{
			return Value.ToString() + Suit.ToString();
		}
	}
}
