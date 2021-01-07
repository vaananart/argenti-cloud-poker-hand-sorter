using PokerHandDomainModels;

namespace GameFramework.Services
{
	public interface IScoreDeterminer
	{
		int DetermineRank(PlayerModel player);
	}
}
