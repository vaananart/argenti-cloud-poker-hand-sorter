using System.Collections.Generic;
using System.Linq;

using PokerHandDomainModels;

namespace PokerHandLogicHandlers.Finders
{
	public static class FourOfAKindFinder
	{
		/// <summary>
		/// The Finder to identify Four-of-a-Kind rank in the card collection.
		/// </summary>
		/// <param name="sampleCards"></param>
		/// <returns></returns>
		public static IEnumerable<CardModel> FindFourOfAKind(IList<CardModel> sampleCards)
		{
			IDictionary<char, int> cardSummaryLookup = CardsLookupBuilder.Build(sampleCards);

			var matchedPairValue = cardSummaryLookup.Where(x => x.Value == 4).FirstOrDefault();

			var result = sampleCards.Where(x => x.Value == matchedPairValue.Key);
			return result;
		}
	}
}
