﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using PokerHanderSorterService;

using PokerHandSorterServiceTests.Utils;

using Xunit;

namespace PokerHandSorterServiceTests
{
	public class GetTheHighestCardofTheRankMethodTests
	{
		[Fact]
		public void GetTheHighestCardWithNoRankTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			var gameSvc = new GameService(lines.ToArray());
			Debugger.Break();
			var result = gameSvc.SetupAllMatches(lines.ToArray());

			var rank = gameSvc.DetermineRank(result.ToList()[4].Player2);

			var highestCard = gameSvc.GetTheHighestCardOfTheRank(result.ToList()[4].Player2, rank);

			Debugger.Break();
			Assert.Equal("KC", highestCard.ToString());
		}

		[Fact]
		public void GetTheHighestCardWithAPairTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			var gameSvc = new GameService(lines.ToArray());
			Debugger.Break();
			var result = gameSvc.SetupAllMatches(lines.ToArray());

			var rank = gameSvc.DetermineRank(result.ToList()[4].Player1);

			var highestCard = gameSvc.GetTheHighestCardOfTheRank(result.ToList()[4].Player1, rank);

			Debugger.Break();
			Assert.Equal("AH", highestCard.ToString());
		}

		[Fact]
		public void GetTheHighestCardWithDoublePairTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			var gameSvc = new GameService(lines.ToArray());
			Debugger.Break();
			var result = gameSvc.SetupAllMatches(lines.ToArray());

			var rank = gameSvc.DetermineRank(result.ToList()[3].Player2);

			var highestCard = gameSvc.GetTheHighestCardOfTheRank(result.ToList()[3].Player2, rank);

			Debugger.Break();
			Assert.Equal("KD", highestCard.ToString());
		}

		[Fact]
		public void GetTheHighestCardWithThreeOfAKindTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			var gameSvc = new GameService(lines.ToArray());
			Debugger.Break();
			var result = gameSvc.SetupAllMatches(lines.ToArray());

			var rank = gameSvc.DetermineRank(result.ToList()[3].Player1);

			var highestCard = gameSvc.GetTheHighestCardOfTheRank(result.ToList()[3].Player1, rank);

			Debugger.Break();
			Assert.Equal("6C", highestCard.ToString());
		}

		[Fact]
		public void GetTheHighestCardWithStraightTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			var gameSvc = new GameService(lines.ToArray());
			Debugger.Break();
			var result = gameSvc.SetupAllMatches(lines.ToArray());

			var rank = gameSvc.DetermineRank(result.ToList()[2].Player2);

			var highestCard = gameSvc.GetTheHighestCardOfTheRank(result.ToList()[2].Player2, rank);

			Debugger.Break();
			Assert.Equal("KS", highestCard.ToString());
		}

		[Fact]
		public void GetTheHighestCardWithFlushTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			var gameSvc = new GameService(lines.ToArray());
			Debugger.Break();
			var result = gameSvc.SetupAllMatches(lines.ToArray());

			var rank = gameSvc.DetermineRank(result.ToList()[2].Player1);

			var highestCard = gameSvc.GetTheHighestCardOfTheRank(result.ToList()[2].Player1, rank);

			Debugger.Break();
			Assert.Equal("AH", highestCard.ToString());
		}

		[Fact]
		public void GetTheHighestCardWithFullHouseTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			var gameSvc = new GameService(lines.ToArray());
			Debugger.Break();
			var result = gameSvc.SetupAllMatches(lines.ToArray());

			var rank = gameSvc.DetermineRank(result.ToList()[1].Player2);

			var highestCard = gameSvc.GetTheHighestCardOfTheRank(result.ToList()[1].Player2, rank);

			Debugger.Break();
			Assert.Equal("KD", highestCard.ToString());
		}


		[Fact]
		public void GetTheHighestCardWithFourOfAKindTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			var gameSvc = new GameService(lines.ToArray());
			Debugger.Break();
			var result = gameSvc.SetupAllMatches(lines.ToArray());

			var rank = gameSvc.DetermineRank(result.ToList()[1].Player1);

			var highestCard = gameSvc.GetTheHighestCardOfTheRank(result.ToList()[1].Player1, rank);

			Debugger.Break();
			Assert.Equal("6C", highestCard.ToString());
		}

		[Fact]
		public void GetTheHighestCardWithStraightFlushTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			var gameSvc = new GameService(lines.ToArray());
			Debugger.Break();
			var result = gameSvc.SetupAllMatches(lines.ToArray());

			var rank = gameSvc.DetermineRank(result.ToList()[0].Player2);

			var highestCard = gameSvc.GetTheHighestCardOfTheRank(result.ToList()[0].Player2, rank);

			Debugger.Break();
			Assert.Equal("TC", highestCard.ToString());
		}

		[Fact]
		public void GetTheHighestCardWithRoyalFlushTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			var gameSvc = new GameService(lines.ToArray());
			Debugger.Break();
			var result = gameSvc.SetupAllMatches(lines.ToArray());

			var rank = gameSvc.DetermineRank(result.ToList()[0].Player1);

			var highestCard = gameSvc.GetTheHighestCardOfTheRank(result.ToList()[0].Player1, rank);

			Debugger.Break();
			Assert.Equal("AH", highestCard.ToString());
		}
	}
}
