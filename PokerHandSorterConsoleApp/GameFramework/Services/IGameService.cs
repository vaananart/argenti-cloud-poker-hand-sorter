using System.Collections.Generic;

using PokerHandDomainModels;

namespace GameFramework.Services
{
	/// <summary>
	/// The purpose of this interface is to use later in Dependency Injection
	/// for web app/service. The interface helps to keeps the user of the interface and 
	/// the implementation loosely coupled. We can have different Game rule service for 
	/// different games.
	/// </summary>
	public interface IGameService
	{
		GameModel SetupMatch(string matchInput);
		IEnumerable<GameModel> SetupAllMatches(string[] allMatchInputs);

		GameWonModel PlayPoker(GameModel game);

		CardModel GetTheHighestCardOfTheRank(PlayerModel player, int rank);

		int DetermineRank(PlayerModel player);

		ConsolidatedWonHandsReportModel ExecuteAllGamesAndProcessReport();
	}
}
