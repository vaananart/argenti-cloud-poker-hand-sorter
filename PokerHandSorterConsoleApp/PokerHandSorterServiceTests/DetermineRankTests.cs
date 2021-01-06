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
	public class DetermineRankTests
	{
		//NOTE: These tests covers all the lines in the prod code
		[Fact]
		public void DeterminRankForRoyalFlushTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			var gameSvc = new GameService(lines.ToArray());
			var result = gameSvc.SetupAllMatches(lines.ToArray());

			var rankResult = gameSvc.DetermineRank(result.ToList()[0].Player1);
			Assert.Equal(10, rankResult);
		}

		[Fact]
		public void DeterminRankForStraightFlushTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			var gameSvc = new GameService(lines.ToArray());
			var result = gameSvc.SetupAllMatches(lines.ToArray());

			var rankResult = gameSvc.DetermineRank(result.ToList()[0].Player2);
			Assert.Equal(9, rankResult);
		}

		[Fact]
		public void DeterminRankForFourOfAKindTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			var gameSvc = new GameService(lines.ToArray());
			var result = gameSvc.SetupAllMatches(lines.ToArray());

			var rankResult = gameSvc.DetermineRank(result.ToList()[1].Player1);
			Assert.Equal(8, rankResult);
		}

		[Fact]
		public void DeterminRankForFullHouseTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			var gameSvc = new GameService(lines.ToArray());
			var result = gameSvc.SetupAllMatches(lines.ToArray());

			Debugger.Break();
			var rankResult = gameSvc.DetermineRank(result.ToList()[1].Player2);
			Assert.Equal(7, rankResult);
		}

		[Fact]
		public void DeterminRankForFlushTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			var gameSvc = new GameService(lines.ToArray());
			var result = gameSvc.SetupAllMatches(lines.ToArray());

			Debugger.Break();
			var rankResult = gameSvc.DetermineRank(result.ToList()[2].Player1);
			Assert.Equal(6, rankResult);
		}

		[Fact]
		public void DeterminRankForStraightTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			var gameSvc = new GameService(lines.ToArray());
			var result = gameSvc.SetupAllMatches(lines.ToArray());

			Debugger.Break();
			var rankResult = gameSvc.DetermineRank(result.ToList()[2].Player2);
			Assert.Equal(5, rankResult);
		}

		[Fact]
		public void DeterminRankForThreeOfAKindTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			var gameSvc = new GameService(lines.ToArray());
			var result = gameSvc.SetupAllMatches(lines.ToArray());

			Debugger.Break();
			var rankResult = gameSvc.DetermineRank(result.ToList()[3].Player1);
			Assert.Equal(4, rankResult);
		}

		[Fact]
		public void DeterminRankForDoublePairTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			var gameSvc = new GameService(lines.ToArray());
			var result = gameSvc.SetupAllMatches(lines.ToArray());

			Debugger.Break();
			var rankResult = gameSvc.DetermineRank(result.ToList()[3].Player2);
			Assert.Equal(3, rankResult);
		}

		[Fact]
		public void DeterminRankForAPairTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			var gameSvc = new GameService(lines.ToArray());
			var result = gameSvc.SetupAllMatches(lines.ToArray());

			Debugger.Break();
			var rankResult = gameSvc.DetermineRank(result.ToList()[4].Player1);
			Assert.Equal(2, rankResult);
		}

		[Fact]
		public void DeterminRankForNoMatchTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			var gameSvc = new GameService(lines.ToArray());
			var result = gameSvc.SetupAllMatches(lines.ToArray());

			Debugger.Break();
			var rankResult = gameSvc.DetermineRank(result.ToList()[4].Player2);
			Assert.Equal(0, rankResult);
		}
	}
}
