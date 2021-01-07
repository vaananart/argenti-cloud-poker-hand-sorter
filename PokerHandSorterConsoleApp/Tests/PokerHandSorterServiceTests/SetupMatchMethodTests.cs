using System.Linq;
using GameFramework.Services;
using GameServices.PokerHand.Support;
using PokerHandSorterServiceTests.Utils;
using Xunit;

namespace PokerHandSorterServiceTests
{
	public class SetupMatchMethodTests
	{
		//NOTE: Code Coverage : These tests covers all the lines in the prod code.
		[Fact]
		public void SetupMatchTest()
		{
			var lines = TestSampleDataExtractor.Extract("simple-setupmatch-sample.txt");

			IMatchMaker gameMaker = new PokerHandGameOrganiser();
			var result = gameMaker.SetupMatch(lines[0]);

			var player1Cards = from card in result.Player1.CardsAtHand
							   select card.ToString();
			string resultString = string.Join(" ", player1Cards.ToList());
			Assert.Equal("9C 9D 8D 7C 3C", resultString);

			var player2Cards = from card in result.Player2.CardsAtHand
							   select card.ToString();
			resultString = string.Join(" ", player2Cards.ToList());
			Assert.Equal("2S KD TH 9H 8H", resultString);
		}
	}
}
