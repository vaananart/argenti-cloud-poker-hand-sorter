﻿using System.Collections.Generic;
using System.Linq;

using PokerHandDomainModels;
using PokerHandDomainModels.CardModelVariants;

namespace PokerHandLogicHandlers.Finders
{
	public static class FullHouseFinder
	{
		/// <summary>
		/// The Finder to identify Full House rank in the card collection.
		/// </summary>
		/// <param name="sampleCards"></param>
		/// <returns></returns>
		public static FullHouseModel FindFullHouse(IList<CardModel> sampleCards)
		{
			var threeOfAKing = ThreeOfAKindFinder.FindThreeOfKind(sampleCards);
			var aPair = PairFinder.FindAPair(sampleCards);


			if ( threeOfAKing == null)
				return null;

			if (aPair == null)
				return null;

			return new FullHouseModel { 
				ThreeOfAKind = threeOfAKing,
				APair = aPair
			};
		}
	}
}
