using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandDomainModels
{
	/// <summary>
	/// The model that holds all the relavent dependencies together.
	/// It helps to streamline the processing as the state of the 
	/// game traverses from start to end.
	/// </summary>
	public class GameModel
	{
		public PlayerModel Player1 { get; set; }
		public PlayerModel Player2 { get; set; }

		public GameWonModel GameResult { get; set; }

	}
}
