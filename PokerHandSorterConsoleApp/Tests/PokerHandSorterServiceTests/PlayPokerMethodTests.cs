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
	public class PlayPokerMethodTests
	{
		//NOTE: Code Coverage : These tests covers all the lines in the prod code.
		[Fact]
		public void Play1GameTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-DetermineRank-sample.txt");

			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer rankDeterminer = new RankDeterminer();
			IHighestValueinSubsetSearcher cardSeeker = new HighestValuePokeHandRankSeeker();
			IGameExecutor gameOperator = new PokerHandGameOperator(rankDeterminer, cardSeeker);
			var gameResult = gameOperator.PlayPoker(result.ToList()[0]);
			Assert.True(gameResult.Player1_Won);
			Assert.Equal(RankEnum.RoyalFlush, gameResult.Play1_Rank);
			Assert.False(gameResult.Player2_Won);
			Assert.Equal(RankEnum.StraightFlush, gameResult.Play2_Rank);
		}

		[Fact]
		public void Play1Game_With_Loop_Issue_Test()
		{
			var lines = TestSampleDataExtractor.Extract("Input-to-loop-issue.txt");
			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			IScoreDeterminer rankDeterminer = new RankDeterminer();
			IHighestValueinSubsetSearcher cardSeeker = new HighestValuePokeHandRankSeeker();
			IGameExecutor gameOperator = new PokerHandGameOperator(rankDeterminer, cardSeeker);
			var gameResult = gameOperator.PlayPoker(result.ToList()[0]);
			Assert.True(gameResult.Player1_Won);
			Assert.Equal(RankEnum.Pair, gameResult.Play1_Rank);
			Assert.False(gameResult.Player2_Won);
			Assert.Equal(RankEnum.Pair, gameResult.Play2_Rank);
		}
	}
}
