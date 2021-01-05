using System;

using PokerHandSorterServiceTests.Utils;

using Xunit;

namespace PokerHandSorterServiceTests
{
	public class SorterServiceTests
	{
		[Fact]
		public void Test1()
		{
			var lines = TestSampleDataExtractor.Extract("poker-hands.txt");
		}


	}
}
