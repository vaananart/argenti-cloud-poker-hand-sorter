using System;
using PokerHandDomainModels;
using PokerHandDomainModels.Enums;

namespace PokerHandLogicHandlers.ModelExtensions
{
	public static class CardModelExtension
	{
		/// <summary>
		/// I found it a challenge to determine the next high value card.
		/// So the CardModel have the responsibility and the ability to tell me
		/// what the next high-value card after itself.
		/// </summary>
		/// <param name="card"></param>
		/// <returns></returns>
		public static CardModel NextCardInAscOrder(this CardModel card)
		{
			int convertedValue;
			if (int.TryParse(card.Value.ToString(), out convertedValue))
			{
				if (convertedValue == 9)
					return new CardModel("T" + card.Suit);
				else
					return new CardModel((++convertedValue).ToString() + card.Suit);
			}
			else
			{
				SpecialCardEnum speciaCard;
				Enum.TryParse(card.Value.ToString(), out speciaCard);
				int specialCardIntType = (int)speciaCard;
				specialCardIntType++;
				speciaCard = (SpecialCardEnum)specialCardIntType;
				return new CardModel(speciaCard.ToString() + card.Suit);

			}
		}
	}
}
