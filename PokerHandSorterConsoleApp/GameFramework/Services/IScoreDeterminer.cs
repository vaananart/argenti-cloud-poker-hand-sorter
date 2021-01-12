using PokerHandDomainModels;
using PokerHandDomainModels.Enums;

namespace GameFramework.Services
{
	public interface IScoreDeterminer
	{
		RankEnum DetermineRank(PlayerModel player);
	}
}
