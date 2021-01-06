using System;

namespace PokerHandDomainModels
{
	/// <summary>
	/// Used in reporting the outcome of the game.
	/// </summary>
	public class GameWonModel
	{
		public bool Player1_Won { get; set; }
		public bool Player2_Won { get; set; }

		public int Play1_Rank { get; set; }
		public int Play2_Rank { get; set; }
	}
}
