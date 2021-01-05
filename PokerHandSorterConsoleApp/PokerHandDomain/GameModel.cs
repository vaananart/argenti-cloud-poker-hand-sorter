using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandDomainModels
{
	public class GameModel
	{
		public PlayerModel Player1 { get; set; }
		public PlayerModel Player2 { get; set; }

		public GameWonModel GameResult { get; set; }

	}
}
