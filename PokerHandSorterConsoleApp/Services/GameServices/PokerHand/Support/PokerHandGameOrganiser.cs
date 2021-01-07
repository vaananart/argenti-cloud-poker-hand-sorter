using System.Linq;
using GameFramework.Services;
using PokerHandDomainModels;

namespace GameServices.PokerHand.Support
{
	public class PokerHandGameOrganiser : IMatchMaker
	{
		public GameModel SetupMatch(string matchInput)
		{
			var firstPlayerCards = matchInput.Split(" ").ToList().GetRange(0, 5).ToArray();
			var secondPlayerCards = matchInput.Split(" ").ToList().GetRange(5, 5).ToArray();

			var firstPlayer = new PlayerModel(string.Join(" ", firstPlayerCards));
			var secondPlayer = new PlayerModel(string.Join(" ", secondPlayerCards));

			var game = new GameModel();
			game.Player1 = firstPlayer;
			game.Player2 = secondPlayer;

			return game;
		}
	}
}
