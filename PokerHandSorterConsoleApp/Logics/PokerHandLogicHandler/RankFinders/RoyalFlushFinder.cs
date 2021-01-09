using System.Collections.Generic;
using System.Linq;
using PokerHandDomainModels;

namespace PokerHandLogicHandlers.Finders
{
	public static class RoyalFlushFinder
	{
		/// <summary>
		/// The Finder to identify Royal Flush rank in the card collection.
		/// </summary>
		/// <param name="sampleCards"></param>
		/// <returns></returns>
		public static bool IsRoyalFlush(IList<CardModel> sampleCards)
		{
			IList<CardModel> sortedCards = sampleCards.OrderBy(x => x.Value).ToList();

			var matchBy10 = sampleCards.Where(x => x.Value == 'T' && x.Suit == sampleCards[0].Suit);
			var matchByJack = sampleCards.Where(x => x.Value == 'J' && x.Suit == sampleCards[0].Suit);
			var matchByQueen = sampleCards.Where(x => x.Value == 'Q' && x.Suit == sampleCards[0].Suit);
			var matchByKing = sampleCards.Where(x => x.Value == 'K' && x.Suit == sampleCards[0].Suit);
			var matchByAce = sampleCards.Where(x => x.Value == 'A' && x.Suit == sampleCards[0].Suit);

			return (matchByJack.Count() == 1) && (matchByQueen.Count() == 1) && (matchByKing.Count() == 1) && (matchByAce.Count() == 1);
		}
	}
}
