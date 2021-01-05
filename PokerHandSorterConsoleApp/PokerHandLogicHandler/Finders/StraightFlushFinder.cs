using System.Collections.Generic;
using System.Linq;

using PokerHandDomainModels;

namespace PokerHandLogicHandlers.Finders
{
	public static class StraightFlushFinder
	{
		public static bool IsStraightFlush(IList<CardModel> sampleCards)
		{
			IList<CardModel> sortedCards = sampleCards.OrderBy(x => x.Value).ToList();

			var initCard = sortedCards[0];
			sortedCards.RemoveAt(0);
			foreach (CardModel element in sortedCards)
			{
				if (element.Value != (initCard.Value + 1) || element.Suit != initCard.Suit)
					return false;
				else
					initCard = element;
			}

			return true;
		}
	}
}
