using System.Collections.Generic;
using System.Linq;
using PokerHandDomainModels;

namespace PokerHandLogicHandlers.Finders
{
	public static class ThreeOfAKindFinder
	{
		/// <summary>
		/// The Finder to identify Three-of-a-Kind  rank in the card collection.
		/// </summary>
		/// <param name="sampleCards"></param>
		/// <returns></returns>
		public static IEnumerable<CardModel> FindThreeOfKind(IList<CardModel> sampleCards)
		{
			IDictionary<char, int> cardSummaryLookup = CardsLookupBuilder.Build(sampleCards);

			var matchedPairValue = cardSummaryLookup.Where(x => x.Value == 3).FirstOrDefault();

			var result = sampleCards.Where(x => x.Value == matchedPairValue.Key);
			return result.Count() != 0 ? result : null;
		}
	}
}
