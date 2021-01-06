using System;
using System.Collections.Generic;
using System.Linq;

using GameService;

namespace PokerHandConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			IList<string> inputs = new List<string>();
			string line = string.Empty;
			bool noNewLines = false;
			
			do
			{
				line = Console.ReadLine();
				if (!string.IsNullOrEmpty(line))
					inputs.Add(line);
				else
					noNewLines = true;

			} while ( noNewLines != true );


			var gameService = new PokerHandService(inputs.ToArray());
			var gamesReport = gameService.ExecuteAllGamesAndProcessReport();

			Console.WriteLine("Player 1: " + gamesReport.Player1WonTotal);
			Console.WriteLine("Player 2: " + gamesReport.PLayer2WonTotal);

		}
	}
}
