namespace PokerHandDomainModels.Enums
{
	/// <summary>
	/// This is used with the numerical valued cards.
	/// The special cards need to hold a certain value.
	/// This helps to decide in ordering and in processing 
	/// Straight and Straight Flush ranks.
	/// </summary>
	public enum SpecialCardEnum
	{
		T = 10,
		J = 11,
		Q = 12,
		K = 13,
		A = 14
	}
}
