using PokerHandDomainModels;

namespace GameFramework.Services
{
	public interface IHighestValueinSubsetSearcher
	{
		CardModel GetTheHighestCardOfTheRank(PlayerModel player, int rank);
	}
}
