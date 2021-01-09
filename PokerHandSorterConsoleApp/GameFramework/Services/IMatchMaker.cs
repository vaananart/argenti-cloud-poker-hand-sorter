using PokerHandDomainModels;

namespace GameFramework.Services
{
	public interface IMatchMaker
	{
		GameModel SetupMatch(string matchInput);
	}
}
