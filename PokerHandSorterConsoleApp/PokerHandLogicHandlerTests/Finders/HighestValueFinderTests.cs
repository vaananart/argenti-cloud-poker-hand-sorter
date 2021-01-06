using System.Collections.Generic;
using PokerHandDomainModels;
using PokerHandLogicHandlers.Finders;
using Xunit;

namespace PokerHandLogicHandlerTests.Finders
{
	public class HighestValueFinderTests
	{
		//NOTE: Code Coverage : these tests covers all the lines in the code.
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
		public void HighestCardWithAceTest()
		{
			var sampleCards = new List<CardModel>
			{
				new CardModel("4H"),
				new CardModel("KC"),
				new CardModel("6S"),
				new CardModel("7S"),
				new CardModel("AD")
			};

			var result = HighestValueFinder.HighestValue(sampleCards);

			Assert.Equal('A', result.Value);
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
