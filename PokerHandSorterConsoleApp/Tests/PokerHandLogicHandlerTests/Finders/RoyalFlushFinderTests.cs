using System.Collections.Generic;
using PokerHandDomainModels;
using PokerHandLogicHandlers.Finders;
using Xunit;

namespace PokerHandLogicHandlerTests.Finders
{
	public class RoyalFlushFinderTests
	{
		//NOTE: Code Coverage : this tests covers all the lines in the code.
		[Fact]
		public void Given_RoyalFlush_Doesnt_Exists_Test()
		{
			var sampleCards = new List<CardModel>
			{
				new CardModel("4H"),
				new CardModel("4C"),
				new CardModel("4S"),
				new CardModel("6C"),
				new CardModel("KD")
			};

			var result = RoyalFlushFinder.IsRoyalFlush(sampleCards);

			Assert.False(result);
		}

		[Fact]
		public void Given_RoyalFlush_Exists_Test()
		{
			var sampleCards = new List<CardModel>
			{
				new CardModel("TH"),
				new CardModel("JH"),
				new CardModel("QH"),
				new CardModel("KH"),
				new CardModel("AH")
			};

			var result = RoyalFlushFinder.IsRoyalFlush(sampleCards);

			Assert.True(result);
		}
	}
}
