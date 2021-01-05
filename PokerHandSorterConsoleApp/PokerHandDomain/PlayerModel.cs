using System.Collections.Generic;

namespace PokerHandDomainModels
{
	public class PlayerModel
	{
		public IList<CardModel> CardsAtHand { get; private set; }

		public PlayerModel(string cards)
		{
			var cardString = cards.Split(" ");
			this.CardsAtHand = new List<CardModel>();

			foreach (string card in cardString)
			{
				this.CardsAtHand.Add(new CardModel(card));
			}
		}
		public int GetRank()
		{
			return -1;
		}

	}
}
