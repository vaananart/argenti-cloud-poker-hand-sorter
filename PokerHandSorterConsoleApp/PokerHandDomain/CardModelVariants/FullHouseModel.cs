using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHandDomainModels.CardModelVariants
{
	public class FullHouseModel
	{
		public IEnumerable<CardModel> ThreeOfAKind { get; set; }
		public IEnumerable<CardModel> APair { get; set; }
	}
}
