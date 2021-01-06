using System.Collections.Generic;

using PokerHandDomainModels;

namespace PokerHandLogicHandlers
{
	internal static class CardsLookupBuilder
	{
		/// <summary>
		/// The method prepares the structure required to lookup the content
		/// in the card. At series of cards are passed to make a dictionary
		/// lookup to determine the rank cleanly.
		/// </summary>
		/// <param name="sampleCards"></param>
		/// <returns></returns>
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
