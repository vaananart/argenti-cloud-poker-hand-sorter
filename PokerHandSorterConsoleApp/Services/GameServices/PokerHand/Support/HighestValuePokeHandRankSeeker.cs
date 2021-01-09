using System.Linq;
using GameFramework.Services;
using PokerHandDomainModels;
using PokerHandLogicHandlers.Finders;

namespace GameServices.PokerHand.Support
{
	public class HighestValuePokeHandRankSeeker : IHighestValueinSubsetSearcher
	{
		public CardModel GetTheHighestCardOfTheRank(PlayerModel player, int rank)
		{
			switch (rank)
			{
				case 10:
					return HighestValueFinder.HighestValue(player.CardsAtHand);
				case 9:
					return HighestValueFinder.HighestValue(player.CardsAtHand);
				case 8:
					return HighestValueFinder.HighestValue(FourOfAKindFinder.FindFourOfAKind(player.CardsAtHand).ToList());
				case 7:
					{
						var threeOfAKind = ThreeOfAKindFinder.FindThreeOfKind(player.CardsAtHand);
						var aPair = PairFinder.FindAPair(player.CardsAtHand);
						var valueOfThree = HighestValueFinder.HighestValue(threeOfAKind.ToList());
						var valueOfTwo = HighestValueFinder.HighestValue(aPair.ToList());
						return valueOfThree.Value < valueOfTwo.Value ? valueOfTwo : valueOfThree;
					}
				case 6:
					return HighestValueFinder.HighestValue(player.CardsAtHand);
				case 5:
					return HighestValueFinder.HighestValue(player.CardsAtHand);
				case 4:
					{
						var threeOfAKind = ThreeOfAKindFinder.FindThreeOfKind(player.CardsAtHand);
						return HighestValueFinder.HighestValue(threeOfAKind.ToList());
					}
				case 3:
					{
						var doublePairs = DoublePairFinder.FindTwoPair(player.CardsAtHand);
						return HighestValueFinder.HighestValue(doublePairs.ToList());
					}
				case 2:
					{
						var result = PairFinder.FindAPair(player.CardsAtHand);
						return result != null ? result.FirstOrDefault() : null;

					}
				case 1:
					return HighestValueFinder.HighestValue(player.CardsAtHand);
				default:
					return HighestValueFinder.HighestValue(player.CardsAtHand);
			}
		}
	}
}
