using System;

using PokerHandDomainModels.Enums;

namespace PokerHandDomainModels
{
	/// <summary>
	/// Used in reporting the outcome of the game.
	/// </summary>
	public class GameWonModel
	{
		public bool Player1_Won { get; set; }
		public bool Player2_Won { get; set; }

		public RankEnum Play1_Rank { get; set; }
		public RankEnum Play2_Rank { get; set; }
	}
}
