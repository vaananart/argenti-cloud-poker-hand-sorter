using System.Collections.Generic;
using System.Linq;
using PokerHandDomainModels;
using PokerHandLogicHandlers.ModelExtensions;
using PokerHandLogicHandlers.Utils;

namespace PokerHandLogicHandlers.Finders
{

	public static class StraightFinder
	{
		/// <summary>
		/// Finder to identify Straight rank in the card collection.
		/// </summary>
		/// <param name="sampleCards"></param>
		/// <returns></returns>
		public static bool IsStraight(IList<CardModel> sampleCards)
		{
			IList<CardModel> sortedCards = sampleCards.OrderingByCardValue().ToList();

			var initCard = sortedCards[0];
			sortedCards.RemoveAt(0);

			foreach (CardModel element in sortedCards)
			{
				if (element.Value != initCard.NextCardInAscOrder().Value)
					return false;
				else
					initCard = element;
			}

			return true;
		}
	}
}
