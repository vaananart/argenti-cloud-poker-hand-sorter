using System.Collections.Generic;
using System.Linq;
using GameFramework.Services;
using GameServices.PokerHand.Support;
using PokerHandDomainModels;
using PokerHandSorterServiceTests.Utils;
using Xunit;

namespace PokerHandSorterServiceTests
{
	public class GetTheHighestCardofTheRankMethodTests
	{
		//NOTE: Code Coverage : These tests covers all the lines in the prod code.
		[Fact]
		public void GetTheHighestCardWithNoRankTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");

			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer determiner = new RankDeterminer();
			var rank = determiner.DetermineRank(result.ToList()[4].Player2);

			IHighestValueinSubsetSearcher searcher = new HighestValuePokeHandRankSeeker();
			var highestCard = searcher.GetTheHighestCardOfTheRank(result.ToList()[4].Player2, rank);

			Assert.Equal("KC", highestCard.ToString());
		}

		[Fact]
		public void GetTheHighestCardWithAPairTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");

			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer determiner = new RankDeterminer();
			var rank = determiner.DetermineRank(result.ToList()[4].Player1);

			IHighestValueinSubsetSearcher searcher = new HighestValuePokeHandRankSeeker();
			var highestCard = searcher.GetTheHighestCardOfTheRank(result.ToList()[4].Player1, rank);
			Assert.Equal("AH", highestCard.ToString());
		}

		[Fact]
		public void GetTheHighestCardWithDoublePairTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");

			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer determiner = new RankDeterminer();
			var rank = determiner.DetermineRank(result.ToList()[3].Player2);

			IHighestValueinSubsetSearcher searcher = new HighestValuePokeHandRankSeeker();
			var highestCard = searcher.GetTheHighestCardOfTheRank(result.ToList()[3].Player2, rank);
			Assert.Equal("KD", highestCard.ToString());
		}

		[Fact]
		public void GetTheHighestCardWithThreeOfAKindTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");

			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer determiner = new RankDeterminer();
			var rank = determiner.DetermineRank(result.ToList()[3].Player1);

			IHighestValueinSubsetSearcher searcher = new HighestValuePokeHandRankSeeker();
			var highestCard = searcher.GetTheHighestCardOfTheRank(result.ToList()[3].Player1, rank);
			Assert.Equal("6C", highestCard.ToString());
		}

		[Fact]
		public void GetTheHighestCardWithStraightTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");

			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer determiner = new RankDeterminer();
			var rank = determiner.DetermineRank(result.ToList()[2].Player2);

			IHighestValueinSubsetSearcher searcher = new HighestValuePokeHandRankSeeker();
			var highestCard = searcher.GetTheHighestCardOfTheRank(result.ToList()[2].Player2, rank);
			Assert.Equal("KS", highestCard.ToString());
		}

		[Fact]
		public void GetTheHighestCardWithFlushTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");

			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer determiner = new RankDeterminer();
			var rank = determiner.DetermineRank(result.ToList()[2].Player1);

			IHighestValueinSubsetSearcher searcher = new HighestValuePokeHandRankSeeker();
			var highestCard = searcher.GetTheHighestCardOfTheRank(result.ToList()[2].Player1, rank);
			Assert.Equal("AH", highestCard.ToString());
		}

		[Fact]
		public void GetTheHighestCardWithFullHouseTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");

			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer determiner = new RankDeterminer();
			var rank = determiner.DetermineRank(result.ToList()[1].Player2);

			IHighestValueinSubsetSearcher searcher = new HighestValuePokeHandRankSeeker();
			var highestCard = searcher.GetTheHighestCardOfTheRank(result.ToList()[1].Player2, rank);
			Assert.Equal("KD", highestCard.ToString());
		}


		[Fact]
		public void GetTheHighestCardWithFourOfAKindTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");

			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer determiner = new RankDeterminer();
			var rank = determiner.DetermineRank(result.ToList()[1].Player1);

			IHighestValueinSubsetSearcher searcher = new HighestValuePokeHandRankSeeker();
			var highestCard = searcher.GetTheHighestCardOfTheRank(result.ToList()[1].Player1, rank);
			Assert.Equal("6C", highestCard.ToString());
		}

		[Fact]
		public void GetTheHighestCardWithStraightFlushTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");

			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer determiner = new RankDeterminer();
			var rank = determiner.DetermineRank(result.ToList()[0].Player2);

			IHighestValueinSubsetSearcher searcher = new HighestValuePokeHandRankSeeker();
			var highestCard = searcher.GetTheHighestCardOfTheRank(result.ToList()[0].Player2, rank);

			Assert.Equal("TC", highestCard.ToString());
		}

		[Fact]
		public void GetTheHighestCardWithRoyalFlushTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");

			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer determiner = new RankDeterminer();
			var rank = determiner.DetermineRank(result.ToList()[0].Player1);

			IHighestValueinSubsetSearcher searcher = new HighestValuePokeHandRankSeeker();
			var highestCard = searcher.GetTheHighestCardOfTheRank(result.ToList()[0].Player1, rank);

			Assert.Equal("AH", highestCard.ToString());
		}
	}
}
