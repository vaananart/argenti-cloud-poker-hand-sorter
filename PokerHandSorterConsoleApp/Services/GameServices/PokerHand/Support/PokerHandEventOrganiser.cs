using System.Collections.Generic;
using GameFramework.Services;
using PokerHandDomainModels;

namespace GameServices.PokerHand.Support
{

	public class PokerHandEventOrganiser : IGameEventOrganiser
	{
		private readonly IMatchMaker _matchMaker;
		private readonly IList<GameModel> _games = null;
		public PokerHandEventOrganiser(IMatchMaker matchMaker, IList<GameModel> games)
		{
			this._matchMaker = matchMaker;
			this._games = games;
		}

		public IEnumerable<GameModel> SetupAllMatches(string[] allMatchInputs)
		{
			foreach (string element in allMatchInputs)
			{
				var newGame = this._matchMaker.SetupMatch(element);
				this._games.Add(newGame);
			}

			return _games;
		}
	}
}
