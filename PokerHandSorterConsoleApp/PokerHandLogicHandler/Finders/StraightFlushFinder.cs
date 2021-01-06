﻿using System.Collections.Generic;
using System.Linq;

using PokerHandDomainModels;

using PokerHandLogicHandlers.ModelExtensions;

using PokerHandLogicHandlers.Utils;

namespace PokerHandLogicHandlers.Finders
{
	public static class StraightFlushFinder
	{
		public static bool IsStraightFlush(IList<CardModel> sampleCards)
		{
			IList<CardModel> sortedCards = sampleCards.OrderingByCardValue().ToList();

			var initCard = sortedCards[0];
			sortedCards.RemoveAt(0);
			foreach (CardModel element in sortedCards)
			{
				if (element.Value != initCard.NextCardInAscOrder().Value || element.Suit != initCard.Suit)
					return false;
				else
					initCard = element;
			}

			return true;
		}
	}
}
