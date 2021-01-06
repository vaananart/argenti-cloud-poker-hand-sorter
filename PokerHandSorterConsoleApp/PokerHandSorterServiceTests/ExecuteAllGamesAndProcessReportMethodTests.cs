using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using GameService;

using PokerHandSorterServiceTests.Utils;

using Xunit;

namespace PokerHandSorterServiceTests
{
	public class ExecuteAllGamesAndProcessReportMethodTests
	{
		//NOTE: Code Coverage : These tests covers all the lines in the prod code.
		[Fact]
		public void Execute_1_Game_Test()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			IList<string> sampleInput = new List<string>();
			sampleInput.Add(lines[0]);
			var gameSvc = new PokerHandService(sampleInput.ToArray());
			var consolidatedReport = gameSvc.ExecuteAllGamesAndProcessReport();

			Assert.Equal( 1, consolidatedReport.Player1WonTotal);
			Assert.Equal(0, consolidatedReport.PLayer2WonTotal);
		}

		[Fact]
		public void Execute_1_Game_with_a_loop_Test()
		{
			var lines = TestSampleDataExtractor.Extract("Input-to-loop-issue.txt");
			IList<string> sampleInput = new List<string>();
			sampleInput.Add(lines[0]);
			var gameSvc = new PokerHandService(sampleInput.ToArray());
			var consolidatedReport = gameSvc.ExecuteAllGamesAndProcessReport();

			Assert.Equal(1, consolidatedReport.Player1WonTotal);
			Assert.Equal(0, consolidatedReport.PLayer2WonTotal);
		}

	}
}
