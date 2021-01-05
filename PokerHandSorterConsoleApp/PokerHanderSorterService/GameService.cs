﻿using System.Collections.Generic;
using System.Linq;

using AppFramework.Services;

using PokerHandDomainModels;
using PokerHandDomainModels.Extensions;

using PokerHandLogicHandlers.Finders;

namespace PokerHanderSorterService
{
	public class GameService : IGameService
	{


		private readonly IList<GameModel> games = null;
		private readonly string[] _cardFeeds;


		public GameService(string[] cardFeed)
		{
			this._cardFeeds = cardFeed;
			this.games = new List<GameModel>();
		}

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

			for (int i = 1; i < ranks.Length; i++)
			{
				if (ranks[i] == true)
					return i;
			}

			return 0;
		}

		public CardModel GetTheHighestCardOfTheRank(PlayerModel player, int rank)
		{
			switch (rank)
			{
				case 10:
					return HighestValueFinder.HighestValue(player.CardsAtHand);
				case 9:
					return HighestValueFinder.HighestValue(player.CardsAtHand);
				case 8:
					return HighestValueFinder.HighestValue(FourOfAKindFinder.FindFourOfAKind(player.CardsAtHand).ToList());
				case 7:
					{
						var threeOfAKind = ThreeOfAKindFinder.FindThreeOfKind(player.CardsAtHand);
						var aPair = PairFinder.FindAPair(player.CardsAtHand);
						var valueOfThree = HighestValueFinder.HighestValue(threeOfAKind.ToList());
						var valueOfTwo = HighestValueFinder.HighestValue(aPair.ToList());
						return valueOfThree.Value < valueOfTwo.Value ? valueOfTwo : valueOfThree;
					}
				case 6:
					return HighestValueFinder.HighestValue(player.CardsAtHand);
				case 5:
					return HighestValueFinder.HighestValue(player.CardsAtHand);
				case 4:
					{
						var threeOfAKind = ThreeOfAKindFinder.FindThreeOfKind(player.CardsAtHand);
						return HighestValueFinder.HighestValue(threeOfAKind.ToList());
					}
				case 3:
					{
						var doublePairs = DoublePairFinder.FindTwoPair(player.CardsAtHand);
						return HighestValueFinder.HighestValue(doublePairs.ToList());
					}
				case 2:
						return PairFinder.FindAPair(player.CardsAtHand).FirstOrDefault();
				case 1:
					return HighestValueFinder.HighestValue(player.CardsAtHand);
				default:
					return HighestValueFinder.HighestValue(player.CardsAtHand);
			}
		}

		public GameWonModel PlayPoker(GameModel game)
		{
			int player1Rank = this.DetermineRank(game.Player1);
			int player2Rank = this.DetermineRank(game.Player2);

			GameWonModel gameResult = new GameWonModel();
			gameResult.Play1_Rank = player1Rank;
			gameResult.Play2_Rank = player2Rank;


			if (player1Rank > player2Rank)
				gameResult.Player1_Won = true;

			if (player1Rank < player2Rank)
				gameResult.Player2_Won = true;

			if (player1Rank == player2Rank)
			{
				//NOTE: when the rank is the same, if the highest value card of the rank
				CardModel player1HighestCard = null;
				CardModel player2HighestCard = null;
				var player1Cards = game.Player1;
				var player2Cards = game.Player2;
				do
				{
					player1HighestCard = this.GetTheHighestCardOfTheRank(player1Cards, player1Rank);
					player1HighestCard = player1Cards.CardsAtHand.Where(x => x.Value == player1HighestCard.Value && x.Suit == player1HighestCard.Suit).FirstOrDefault();
					player1Cards.CardsAtHand.Remove(player1HighestCard);


					player2HighestCard = this.GetTheHighestCardOfTheRank(game.Player2, player2Rank);
					player2HighestCard = player2Cards.CardsAtHand.Where(x => x.Value == player2HighestCard.Value && x.Suit == player2HighestCard.Suit).FirstOrDefault();
					player2Cards.CardsAtHand.Remove(player2HighestCard);

				} while (player1HighestCard.Value == player2HighestCard.Value);

				gameResult.Player1_Won = player1HighestCard.Value > player2HighestCard.Value ? true : false;

				gameResult.Player2_Won = player1HighestCard.Value < player2HighestCard.Value ? true : false;
			}

			return gameResult;

		}

		public IEnumerable<GameModel> SetupAllMatches(string[] allMatchInputs)
		{
			foreach (string element in allMatchInputs)
			{
				var newGame = this.SetupMatch(element);
				this.games.Add(newGame);
			}

			return games;
		}

		public GameModel SetupMatch(string matchInput)
		{
			var firstPlayerCards = matchInput.Split(" ").ToList().GetRange(0, 5).ToArray();
			var secondPlayerCards = matchInput.Split(" ").ToList().GetRange(5, 5).ToArray();

			var firstPlayer = new PlayerModel(string.Concat(firstPlayerCards));
			var secondPlayer = new PlayerModel(string.Concat(secondPlayerCards));

			var game = new GameModel();
			game.Player1 = firstPlayer;
			game.Player2 = secondPlayer;

			return game;
		}

	}
}
