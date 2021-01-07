using System.Collections.Generic;
using System.Linq;
using GameFramework.Services;
using GameServices.PokerHand.Support;
using PokerHandDomainModels;

namespace GameService
{
	public class PokerHandService : IGameService
	{
		private readonly IList<GameModel> _games = null;
		private readonly string[] _cardFeeds;
		private readonly IScoreDeterminer _rankDeterminer;
		private readonly IMatchMaker _matchMaker;
		private readonly IGameEventOrganiser _gameEventOrganiser;
		private readonly IHighestValueinSubsetSearcher _highestValueFinder;
		private readonly IGameExecutor _gameExecutor;


		public PokerHandService(string[] cardFeed)
		{
			this._cardFeeds = cardFeed;
			this._games = new List<GameModel>();
			this._matchMaker = new PokerHandGameOrganiser();
			this._rankDeterminer = new RankDeterminer();
			this._gameEventOrganiser = new PokerHandEventOrganiser(this._matchMaker, this._games);
			this._games.Concat(this._gameEventOrganiser.SetupAllMatches(this._cardFeeds));
			this._highestValueFinder = new HighestValuePokeHandRankSeeker();
			this._gameExecutor = new PokerHandGameOperator(this._rankDeterminer, this._highestValueFinder);
		}

		public ConsolidatedWonHandsReportModel ExecuteAllGamesAndProcessReport()
		{
			foreach (GameModel game in this._games)
			{
				var gameResult = this._gameExecutor.PlayPoker(game);
				game.GameResult = gameResult;
			}

			return new ConsolidatedWonHandsReportModel
			{
				Games = this._games
			};
		}
	}
}
