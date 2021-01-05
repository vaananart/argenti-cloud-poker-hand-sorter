using System.Collections.Generic;
using System.Linq;

using PokerHandDomainModels;

namespace PokerHandLogicHandlers.Finders
{
	public static class DoublePairFinder
	{
		public static IEnumerable<CardModel> FindTwoPair(IList<CardModel> sampleCards)
		{
			IDictionary<char, int> cardSummaryLookup = CardsLookupBuilder.Build(sampleCards);

			var matchedPairValue = cardSummaryLookup.Where(x => x.Value == 2);


			IList<CardModel> matchedCards = new List<CardModel>();
			foreach (var match in matchedPairValue)
			{
				var matchedCardsByValue = sampleCards.Where(x => x.Value == match.Key);
				foreach (CardModel element in matchedCardsByValue)
					matchedCards.Add(element);
			}

			return matchedCards.Count() == 4 ? matchedCards : null;
		}
	}
}
