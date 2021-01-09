using System;
using System.Linq;
using GameFramework.Services;
using PokerHandDomainModels;
using PokerHandDomainModels.Enums;

namespace GameServices.PokerHand.Support
{
	public class PokerHandGameOperator : IGameExecutor
	{
		private readonly IScoreDeterminer _rankDeterminer;
		private readonly IHighestValueinSubsetSearcher _highestValueFinder;

		public PokerHandGameOperator(
			IScoreDeterminer rankDeterminer 
			, IHighestValueinSubsetSearcher cardSeeker
			)
		{
			this._rankDeterminer = rankDeterminer;
			this._highestValueFinder = cardSeeker;
		}

		public GameWonModel PlayPoker(GameModel game)
		{
			int player1Rank = this._rankDeterminer.DetermineRank(game.Player1);
			int player2Rank = this._rankDeterminer.DetermineRank(game.Player2);

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
					player1HighestCard = this._highestValueFinder.GetTheHighestCardOfTheRank(player1Cards, player1Rank);
					player1HighestCard = player1Cards.CardsAtHand.Where(x => x.Value == player1HighestCard.Value && x.Suit == player1HighestCard.Suit).FirstOrDefault();
					player1Cards.CardsAtHand.Remove(player1HighestCard);


					player2HighestCard = this._highestValueFinder.GetTheHighestCardOfTheRank(game.Player2, player2Rank);
					player2HighestCard = player2Cards.CardsAtHand.Where(x => x.Value == player2HighestCard.Value && x.Suit == player2HighestCard.Suit).FirstOrDefault();
					player2Cards.CardsAtHand.Remove(player2HighestCard);

					player1Rank = 0;
					player2Rank = 0;
				} while (player1HighestCard.Value == player2HighestCard.Value);

				int finalPlayer1CardValue = int.MinValue;
				int finalPlayer2CardValue = int.MinValue;

				if (!int.TryParse(player1HighestCard.Value.ToString(), out finalPlayer1CardValue))
				{
					SpecialCardEnum specialCard;
					Enum.TryParse(player1HighestCard.Value.ToString(), out specialCard);
					finalPlayer1CardValue = (int)specialCard;
				}
				else
				{
					int.TryParse(player1HighestCard.Value.ToString(), out finalPlayer1CardValue);
				}

				if (!int.TryParse(player2HighestCard.Value.ToString(), out finalPlayer2CardValue))
				{
					SpecialCardEnum specialCard;
					Enum.TryParse(player2HighestCard.Value.ToString(), out specialCard);
					finalPlayer2CardValue = (int)specialCard;
				}
				else
				{
					int.TryParse(player2HighestCard.Value.ToString(), out finalPlayer2CardValue);
				}

				gameResult.Player1_Won = finalPlayer1CardValue > finalPlayer2CardValue ? true : false;
				gameResult.Player2_Won = finalPlayer1CardValue < finalPlayer2CardValue ? true : false;
			}

			return gameResult;

		}
	}
}
