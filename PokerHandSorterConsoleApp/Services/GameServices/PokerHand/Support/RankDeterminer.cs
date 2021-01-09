using System;
using GameFramework.Services;
using PokerHandDomainModels;
using PokerHandDomainModels.Extensions;

namespace GameServices.PokerHand.Support
{
	public class RankDeterminer : IScoreDeterminer
	{
		public int DetermineRank(PlayerModel player)
		{
			bool[] ranks = new bool[11];

			if (player.HasRoyalFlush())
				ranks[10] = true;

			else if (player.HasStraightFlush())
				ranks[9] = true;

			else if (player.HasFourOfAKind())
				ranks[8] = true;

			else if (player.HasFullHouse())
				ranks[7] = true;

			else if (player.HasAFlush())
				ranks[6] = true;

			else if (player.HasStraight())
				ranks[5] = true;

			else if (player.HasThreeOfAKind())
				ranks[4] = true;

			else if (player.HasDoublePair())
				ranks[3] = true;

			else if (player.HasAPair())
				ranks[2] = true;

			if (Array.TrueForAll(ranks, x => x == false))
				return 0;

			for (int i = 1; i < ranks.Length; i++)
			{
				if (ranks[i] == true)
					return i;
			}

			return 0;
		}
	}
}
