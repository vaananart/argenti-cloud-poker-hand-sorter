using System;
using System.Collections.Generic;
using System.Linq;
using PokerHandDomainModels;
using PokerHandDomainModels.Enums;

namespace PokerHandLogicHandlers.Utils
{
	public static class ListExtension
	{
		/// <summary>
		/// The method is used to order the list by the value of the card.
		/// The order is implemented as to the context of the card's value
		/// </summary>
		/// <param name="cards"></param>
		/// <returns></returns>
		public static IEnumerable<CardModel> OrderingByCardValue(this IList<CardModel> cards)
		{
			IDictionary<int, List<CardModel>> cardsLookup = new Dictionary<int, List<CardModel>>();

			foreach (CardModel element in cards)
			{
				int convertedIntValue = int.MinValue;
				if (int.TryParse(element.Value.ToString(), out convertedIntValue))
				{
					if (!cardsLookup.ContainsKey(convertedIntValue))
						cardsLookup[convertedIntValue] = new List<CardModel>();

					cardsLookup[convertedIntValue].Add(element);
				}
				else
				{
					SpecialCardEnum specialCardEnum;
					Enum.TryParse(element.Value.ToString(), out specialCardEnum);
					if (!cardsLookup.ContainsKey((int)specialCardEnum))
						cardsLookup[(int)specialCardEnum] = new List<CardModel>();

					cardsLookup[(int)specialCardEnum].Add(element);
				}
			}

			var sortedByKeyLookup = cardsLookup.OrderBy(x => x.Key);

			IList<CardModel> sortedCards = new List<CardModel>();

			foreach (var element in sortedByKeyLookup)
			{
				sortedCards = sortedCards.Concat(element.Value).ToList();
			}

			return sortedCards;
		}
	}
}
