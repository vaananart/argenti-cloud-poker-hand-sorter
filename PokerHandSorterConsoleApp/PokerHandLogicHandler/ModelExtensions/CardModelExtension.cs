using System;
using System.Collections.Generic;
using System.Text;

using PokerHandDomainModels;
using PokerHandDomainModels.Enums;

namespace PokerHandLogicHandlers.ModelExtensions
{
	public static class CardModelExtension
	{
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
