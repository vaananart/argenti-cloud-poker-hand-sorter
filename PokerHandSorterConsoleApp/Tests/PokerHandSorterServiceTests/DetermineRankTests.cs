using System.Collections.Generic;
using System.Linq;
using GameFramework.Services;
using GameServices.PokerHand.Support;
using PokerHandDomainModels;
using PokerHandDomainModels.Enums;

using PokerHandSorterServiceTests.Utils;
using Xunit;

namespace PokerHandSorterServiceTests
{
	public class DetermineRankTests
	{
		//NOTE: Code Coverage : These tests covers all the lines in the prod code.
		[Fact]
		public void DeterminRankForRoyalFlushTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");

			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer determiner = new RankDeterminer();
			var rankResult = determiner.DetermineRank(result.ToList()[0].Player1);
			Assert.Equal(RankEnum.RoyalFlush, rankResult);
		}

		[Fact]
		public void DeterminRankForStraightFlushTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
		
			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer determiner = new RankDeterminer();
			var rankResult = determiner.DetermineRank(result.ToList()[0].Player2);
			Assert.Equal(RankEnum.StraightFlush, rankResult);
		}

		[Fact]
		public void DeterminRankForFourOfAKindTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
		
			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer determiner = new RankDeterminer();
			var rankResult = determiner.DetermineRank(result.ToList()[1].Player1);
			Assert.Equal(RankEnum.FourOfAKind, rankResult);
		}

		[Fact]
		public void DeterminRankForFullHouseTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			
			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer determiner = new RankDeterminer();
			var rankResult = determiner.DetermineRank(result.ToList()[1].Player2);
			Assert.Equal(RankEnum.FullHouse, rankResult);
		}

		[Fact]
		public void DeterminRankForFlushTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
		
			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer determiner = new RankDeterminer();
			var rankResult = determiner.DetermineRank(result.ToList()[2].Player1);
			Assert.Equal(RankEnum.Flush, rankResult);
		}

		[Fact]
		public void DeterminRankForStraightTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
			
			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer determiner = new RankDeterminer();
			var rankResult = determiner.DetermineRank(result.ToList()[2].Player2);
			Assert.Equal(RankEnum.Straight, rankResult);
		}

		[Fact]
		public void DeterminRankForThreeOfAKindTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
		
			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer determiner = new RankDeterminer();
			var rankResult = determiner.DetermineRank(result.ToList()[3].Player1);
			Assert.Equal(RankEnum.ThreeOfAKind, rankResult);
		}

		[Fact]
		public void DeterminRankForDoublePairTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");
	
			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer determiner = new RankDeterminer();
			var rankResult = determiner.DetermineRank(result.ToList()[3].Player2);
			Assert.Equal(RankEnum.DoublePair, rankResult);
		}

		[Fact]
		public void DeterminRankForAPairTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");

			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer determiner = new RankDeterminer();
			var rankResult = determiner.DetermineRank(result.ToList()[4].Player1);
			Assert.Equal(RankEnum.Pair, rankResult);
		}

		[Fact]
		public void DeterminRankForNoMatchTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");

			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer determiner = new RankDeterminer();
			var rankResult = determiner.DetermineRank(result.ToList()[4].Player2);
			Assert.Equal(RankEnum.None, rankResult);
		}
	}
}
