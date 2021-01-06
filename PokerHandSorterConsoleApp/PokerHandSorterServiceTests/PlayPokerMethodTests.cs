using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using PokerHanderSorterService;

using PokerHandSorterServiceTests.Utils;

using Xunit;

namespace PokerHandSorterServiceTests
{
	public class PlayPokerMethodTests
	{
		[Fact]
		public void Play1GameTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			var gameSvc = new GameService(lines.ToArray());
			var result = gameSvc.SetupAllMatches(lines.ToArray());
			var gameResult = gameSvc.PlayPoker(result.ToList()[0]);
			Assert.True(gameResult.Player1_Won);
			Assert.Equal(10, gameResult.Play1_Rank);
			Assert.False(gameResult.Player2_Won);
			Assert.Equal(9, gameResult.Play2_Rank);
		}

		[Fact]
		public void Play1Game_With_Loop_Issue_Test()
		{
			var lines = TestSampleDataExtractor.Extract("Input-to-loop-issue.txt");
			var gameSvc = new GameService(lines.ToArray());
			var result = gameSvc.SetupAllMatches(lines.ToArray());
			Debugger.Break();
			var gameResult = gameSvc.PlayPoker(result.ToList()[0]);
			Assert.True(gameResult.Player1_Won);
			Assert.Equal(2, gameResult.Play1_Rank);
			Assert.False(gameResult.Player2_Won);
			Assert.Equal(2, gameResult.Play2_Rank);
		}


	}
}
