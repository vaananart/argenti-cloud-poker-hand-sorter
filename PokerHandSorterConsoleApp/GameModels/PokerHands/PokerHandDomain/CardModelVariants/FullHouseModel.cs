using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandDomainModels.CardModelVariants
{
	/// <summary>
	/// This holds the definition of Full House rank.
	/// </summary>
	public class FullHouseModel
	{
		public IEnumerable<CardModel> ThreeOfAKind { get; set; }
		public IEnumerable<CardModel> APair { get; set; }
	}
}
