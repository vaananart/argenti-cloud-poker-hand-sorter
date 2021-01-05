using System.Collections.Generic;
using System.Linq;

using PokerHandDomainModels;

namespace PokerHandLogicHandlers.Finders
{
	public static class ThreeOfAKindFinder
	{
		public static IEnumerable<CardModel> FindThreeOfKind(IList<CardModel> sampleCards)
		{
			IDictionary<char, int> cardSummaryLookup = CardsLookupBuilder.Build(sampleCards);

			var matchedPairValue = cardSummaryLookup.Where(x => x.Value == 3).FirstOrDefault();

			var result = sampleCards.Where(x => x.Value == matchedPairValue.Key);
			return result;
		}
	}
}
