using System.Collections.Generic;
using PokerHandDomainModels;

namespace PokerHandLogicHandlers
{
	internal static class CardsLookupBuilder
	{
		public static IDictionary<char, int> Build(IList<CardModel> sampleCards)
		{
			IDictionary<char, int> cardSummaryLookup = new Dictionary<char, int>();
			foreach (CardModel element in sampleCards)
			{
				if (!cardSummaryLookup.ContainsKey(element.Value))
				{
					cardSummaryLookup[element.Value] = 0;
				}

				cardSummaryLookup[element.Value]++;
			}

			return cardSummaryLookup;
		}
	}
}
