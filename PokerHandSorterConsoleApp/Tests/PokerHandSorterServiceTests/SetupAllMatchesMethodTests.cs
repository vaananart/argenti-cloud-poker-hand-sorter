using System.Collections.Generic;
using System.Linq;
using GameFramework.Services;
using GameServices.PokerHand.Support;
using PokerHandDomainModels;
using PokerHandSorterServiceTests.Utils;
using Xunit;

namespace PokerHandSorterServiceTests
{
	public class SetupAllMatchesMethodTests
	{
		//NOTE: Code Coverage : These tests covers all the lines in the prod code.
		[Fact]
		public void SetupAllMatchesTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-setupAllmatches-sample.txt");

			IGameEventOrganiser _eventOrganiser = new PokerHandEventOrganiser(new PokerHandGameOrganiser(), new List<GameModel>());
			var result = _eventOrganiser.SetupAllMatches(lines.ToArray());

			var player1Cards = from card in result.ToList()[0].Player1.CardsAtHand
							   select card.ToString();
			string resultString = string.Join(" ", player1Cards.ToList());
			Assert.Equal("9C 9D 8D 7C 3C", resultString);

			var player2Cards = from card in result.ToList()[1].Player2.CardsAtHand
							   select card.ToString();
			resultString = string.Join(" ", player2Cards.ToList());
			Assert.Equal("2S KD 7H 2C AC", resultString);

			var player2CardsFromLastGame = from card in result.ToList()[2].Player2.CardsAtHand
							   select card.ToString();
			resultString = string.Join(" ", player2CardsFromLastGame.ToList());
			Assert.Equal("KS QC 9C 5D 6H", resultString);
		}
	}
}
