using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using PokerHandDomainModels;
using PokerHandDomainModels.Enums;

namespace PokerHandLogicHandlers.Finders
{
	public static class HighestValueFinder
	{
		/// <summary>
		/// The Finder to identify Highest value card in the card collection.
		/// </summary>
		/// <param name="cards"></param>
		/// <returns></returns>
		public static CardModel HighestValue(IList<CardModel> cards)
		{
			CardModel HighestValueCard = new CardModel(null);

			foreach (CardModel element in cards)
			{
				int value = -1;
				if (int.TryParse(element.Value.ToString(), out value))
				{
					int highestValue = int.MinValue;
					if (int.TryParse(HighestValueCard.Value.ToString(), out highestValue))
					{
						HighestValueCard = highestValue < value ? element : HighestValueCard;
					}
					else
					{
						SpecialCardEnum highestCard;
						Enum.TryParse(HighestValueCard.Value.ToString(), out highestCard);
						HighestValueCard = (int)highestCard < value ? element : HighestValueCard;
					}
				}
				else
				{
					SpecialCardEnum elementCard;
					Enum.TryParse(element.Value.ToString(), out elementCard);
					int highestValue = int.MinValue;
					if (int.TryParse(HighestValueCard.Value.ToString(), out highestValue))
					{
						HighestValueCard = highestValue < (int)elementCard ? element : HighestValueCard;
					}
					else
					{
						SpecialCardEnum highestCard;
						Enum.TryParse(HighestValueCard.Value.ToString(), out highestCard);
						HighestValueCard = highestCard < elementCard ? element : HighestValueCard;
					}
				}
			}

			return new CardModel(HighestValueCard.Value.ToString() + HighestValueCard.Suit);
		}

		/// <summary>
		/// This method will give me the next highest card from the given card reference.
		/// </summary>
		/// <param name="cards"></param>
		/// <param name="givenCard"></param>
		/// <returns></returns>
		public static CardModel FindTheNextHighCardFromTheGiven(IList<CardModel> cards, CardModel givenCard)
		{
			var orderedCardsByValue = cards.OrderBy(x => x.Value).ToList();
			var matchedGivenCard = cards.Where(x => x.Value == givenCard.Value && x.Suit == givenCard.Suit).FirstOrDefault();
			var givenCardIndex = orderedCardsByValue.IndexOf(matchedGivenCard);
			orderedCardsByValue.RemoveAt(givenCardIndex);

			CardModel nextHighestCard = null;

			foreach (CardModel card in orderedCardsByValue)
			{
				if (nextHighestCard == null)
					nextHighestCard = card;
				else if (nextHighestCard.Value < card.Value)
					nextHighestCard = card;
			}

			return nextHighestCard;
		}

	}
}
