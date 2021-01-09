using System.Collections.Generic;
using PokerHandDomainModels;

namespace GameFramework.Services
{
	public interface IGameEventOrganiser
	{
		IEnumerable<GameModel> SetupAllMatches(string[] allMatchInputs);
	}
}
