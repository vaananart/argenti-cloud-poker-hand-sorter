using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using PokerHandDomainModels;

namespace PokerHandLogicHandlers.Finders
{
	public static class StraightFinder
	{
		public static bool IsStraight(IList<CardModel> sampleCards)
		{
			IList<CardModel> sortedCards = sampleCards.OrderBy(x => x.Value).ToList();
			Debugger.Break();
			var initCard = sortedCards[0];
			sortedCards.RemoveAt(0);

			foreach (CardModel element in sortedCards)
			{
				if (element.Value != (initCard.Value + 1))
					return false;
				else
					initCard = element;
			}

			return true;
		}
	}
}
