using System.Collections.Generic;

using PokerHandDomainModels;

namespace PokerHandLogicHandlers.Finders
{
	public static class FlushFinder
	{
		public static bool IsFlush(IList<CardModel> sampleCards)
		{
			var initCard = sampleCards[0];

			foreach (CardModel element in sampleCards)
			{
				if (element.Suit != initCard.Suit)
					return false;
			}

			return true;
		}
	}
}
