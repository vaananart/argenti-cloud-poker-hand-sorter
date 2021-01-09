using System.Collections.Generic;
using System.Linq;
using PokerHandDomainModels;

namespace PokerHandLogicHandlers.Finders
{
	public static class PairFinder
	{
		/// <summary>
		/// The Finder to identify a Pair rank in the card collection.
		/// </summary>
		/// <param name="sampleCards"></param>
		/// <returns></returns>
		public static IEnumerable<CardModel> FindAPair(IList<CardModel> sampleCards)
		{
			IDictionary<char, int> cardSummaryLookup = CardsLookupBuilder.Build(sampleCards);


			var matchedPairValue = cardSummaryLookup.Where(x => x.Value == 2).FirstOrDefault();

			var result = sampleCards.Where(x => x.Value == matchedPairValue.Key);
			return result.Count() == 2 ? result : null;
		}
	}
}
