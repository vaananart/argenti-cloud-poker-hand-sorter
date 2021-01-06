using System;
using System.Linq;

using PokerHandLogicHandlers.Finders;

namespace PokerHandDomainModels.Extensions
{
	public static class PlayerModelExtension
	{
		public static bool HasAFlush(this PlayerModel player)
		{
			return FlushFinder.IsFlush(player.CardsAtHand);
		}

		public static bool HasDoublePair(this PlayerModel player)
		{
			var result = DoublePairFinder.FindTwoPair(player.CardsAtHand);

			return result != null ? true : false; 
		}

		public static bool HasFourOfAKind(this PlayerModel player)
		{
			var result = FourOfAKindFinder.FindFourOfAKind(player.CardsAtHand);
			return result.Count() == 4 ? true : false;
		}

		public static bool HasFullHouse(this PlayerModel player)
		{
			var fullHouseResult = FullHouseFinder.FindFullHouse(player.CardsAtHand);

			return fullHouseResult != null ? true : false;
		}

		public static bool HasAPair(this PlayerModel player)
		{
			var result = PairFinder.FindAPair(player.CardsAtHand);

			return result != null ? true : false ;
		}

		public static bool HasRoyalFlush(this PlayerModel player)
		{
			return RoyalFlushFinder.IsRoyalFlush(player.CardsAtHand);
		}

		public static bool HasStraight(this PlayerModel player)
		{
			return StraightFinder.IsStraight(player.CardsAtHand);
		}

		public static bool HasStraightFlush(this PlayerModel player)
		{
			return StraightFlushFinder.IsStraightFlush(player.CardsAtHand);
		}

		public static bool HasThreeOfAKind(this PlayerModel player)
		{
			var result = ThreeOfAKindFinder.FindThreeOfKind(player.CardsAtHand);

			return result != null ? true : false;
		}

		public static CardModel ShowHighestValueCare(this PlayerModel player)
		{
			return HighestValueFinder.HighestValue(player.CardsAtHand);
		}

		public static CardModel FindTheNextHighestCardFromGiven(this PlayerModel player, CardModel givenCard)
		{
			return HighestValueFinder.FindTheNextHighCardFromTheGiven(player.CardsAtHand, givenCard);
		}


	}
}
