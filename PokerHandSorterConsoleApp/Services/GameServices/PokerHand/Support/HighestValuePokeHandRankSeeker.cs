using System.Linq;
using GameFramework.Services;
using PokerHandDomainModels;
using PokerHandDomainModels.Enums;

using PokerHandLogicHandlers.Finders;

namespace GameServices.PokerHand.Support
{
	public class HighestValuePokeHandRankSeeker : IHighestValueinSubsetSearcher
	{
		public CardModel GetTheHighestCardOfTheRank(PlayerModel player, RankEnum rank)
		{
			switch (rank)
			{
				case RankEnum.RoyalFlush:
					return HighestValueFinder.HighestValue(player.CardsAtHand);
				case RankEnum.StraightFlush:
					return HighestValueFinder.HighestValue(player.CardsAtHand);
				case RankEnum.FourOfAKind:
					return HighestValueFinder.HighestValue(FourOfAKindFinder.FindFourOfAKind(player.CardsAtHand).ToList());
				case RankEnum.FullHouse:
					{
						var threeOfAKind = ThreeOfAKindFinder.FindThreeOfKind(player.CardsAtHand);
						var aPair = PairFinder.FindAPair(player.CardsAtHand);
						var valueOfThree = HighestValueFinder.HighestValue(threeOfAKind.ToList());
						var valueOfTwo = HighestValueFinder.HighestValue(aPair.ToList());
						return valueOfThree.Value < valueOfTwo.Value ? valueOfTwo : valueOfThree;
					}
				case RankEnum.Flush:
					return HighestValueFinder.HighestValue(player.CardsAtHand);
				case RankEnum.Straight:
					return HighestValueFinder.HighestValue(player.CardsAtHand);
				case RankEnum.ThreeOfAKind:
					{
						var threeOfAKind = ThreeOfAKindFinder.FindThreeOfKind(player.CardsAtHand);
						return HighestValueFinder.HighestValue(threeOfAKind.ToList());
					}
				case RankEnum.DoublePair:
					{
						var doublePairs = DoublePairFinder.FindTwoPair(player.CardsAtHand);
						return HighestValueFinder.HighestValue(doublePairs.ToList());
					}
				case RankEnum.Pair:
					{
						var result = PairFinder.FindAPair(player.CardsAtHand);
						return result != null ? result.FirstOrDefault() : null;

					}
				case RankEnum.HighCard:
					return HighestValueFinder.HighestValue(player.CardsAtHand);
				default:
					return HighestValueFinder.HighestValue(player.CardsAtHand);
			}
		}
	}
}
