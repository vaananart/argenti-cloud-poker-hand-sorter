using System.Collections.Generic;
using System.Linq;
using PokerHandDomainModels;
using PokerHandLogicHandlers.Finders;
using Xunit;

namespace PokerHandLogicHandlerTests.Finders
{
	public class FullHouseFinderTests
	{
		//NOTE: Code Coverage : these tests covers all the lines in the code. 
		[Fact]
		public void Given_FullHouse_Doesnt_Exists_Since_Pair_Doesnt_Exists_Test()
		{
			var sampleCards = new List<CardModel>
			{
				new CardModel("4H"),
				new CardModel("4C"),
				new CardModel("4S"),
				new CardModel("6C"),
				new CardModel("KD")
			};

			var result = FullHouseFinder.FindFullHouse(sampleCards);

			Assert.Null(result);
		}

		[Fact]
		public void Given_FullHouse_Doesnt_Exists_Since_ThreeOfAKind_Doesnt_Exists_Test()
		{
			var sampleCards = new List<CardModel>
			{
				new CardModel("4H"),
				new CardModel("5C"),
				new CardModel("4S"),
				new CardModel("6C"),
				new CardModel("6D")
			};

			var result = FullHouseFinder.FindFullHouse(sampleCards);

			Assert.Null(result);
		}

		[Fact]
		public void Given_FullHouse_Exists_Test()
		{
			var sampleCards = new List<CardModel>
			{
				new CardModel("4H"),
				new CardModel("4C"),
				new CardModel("4S"),
				new CardModel("6C"),
				new CardModel("6D")
			};

			var result = FullHouseFinder.FindFullHouse(sampleCards);

			Assert.Equal(3, result.ThreeOfAKind.Count());
			Assert.Equal(2, result.APair.Count());
		}
	}
}
