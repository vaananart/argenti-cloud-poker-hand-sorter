using PokerHandDomainModels;
using PokerHandDomainModels.Enums;

namespace GameFramework.Services
{
	public interface IHighestValueinSubsetSearcher
	{
		CardModel GetTheHighestCardOfTheRank(PlayerModel player, RankEnum rank);
	}
}
