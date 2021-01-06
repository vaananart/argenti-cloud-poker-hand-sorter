using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHandDomainModels
{
	public class ConsolidatedWonHandsReportModel
	{
		public IList<GameModel> Games { get; set; }
		public int Player1WonTotal {
			get{
				return this.Games.Where(x => x.GameResult.Player1_Won == true).Count();
			} 
		}

		public int PLayer2WonTotal {
			get {
				return this.Games.Where(x => x.GameResult.Player2_Won == true).Count();
			}
		}
	}
}
