using System;
using System.Collections.Generic;
using System.Text;

using PokerHandDomainModels;

namespace AppFramework.Services
{
	public interface IGameService
	{
		GameModel SetupMatch(string matchInput);
		IEnumerable<GameModel> SetupAllMatches(string[] allMatchInputs);

		GameWonModel PlayPoker(GameModel game);

		CardModel GetTheHighestCardOfTheRank(PlayerModel player, int rank);

		int DetermineRank(PlayerModel player);


	}
}
