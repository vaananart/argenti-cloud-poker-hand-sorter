using PokerHandDomainModels;

namespace GameFramework.Services
{
	public interface IGameExecutor
	{
		GameWonModel PlayPoker(GameModel game);
	}
}
