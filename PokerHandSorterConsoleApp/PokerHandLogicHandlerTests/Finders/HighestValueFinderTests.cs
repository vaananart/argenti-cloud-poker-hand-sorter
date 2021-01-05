using System.Collections.Generic;
using PokerHandDomainModels;
using PokerHandLogicHandlers.Finders;
using Xunit;

namespace PokerHandLogicHandlerTests.Finders
{
	public class HighestValueFinderTests
	{
		[Fact]
		public void HighestCardTest()
		{
			var sampleCards = new List<CardModel>
			{
				new CardModel("4H"),
				new CardModel("4C"),
				new CardModel("6S"),
				new CardModel("7S"),
				new CardModel("KD")
			};

			var result = HighestValueFinder.HighestValue(sampleCards);

			Assert.Equal('K', result.Value);
		}

		[Fact]
		public void NextHighestCardTest()
		{
			var sampleCards = new List<CardModel>
			{
				new CardModel("4H"),
				new CardModel("4C"),
				new CardModel("6S"),
				new CardModel("7S"),
				new CardModel("KD")
			};

			var result = HighestValueFinder.FindTheNextHighCardFromTheGiven(sampleCards, new CardModel("KD"));

			Assert.Equal('7', result.Value);
		}
	}
}
