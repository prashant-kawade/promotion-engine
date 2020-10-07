using PromotionEngine.Services.Calculation.Interfaces;
using PromotionEngine.Services.Models;

namespace PromotionEngine.Services.Calculation.Implementation
{
	public class ComboPromotionService : IPromotion
	{
		public ComboPromotion ComboPromotion { get; private set; }

		public ComboPromotionService(ComboPromotion comboPromotion)
		{
			ComboPromotion = comboPromotion;
		}

		public Cart ApplyPromotion(Cart cart)
		{
			throw new System.NotImplementedException();
		}
	}
}
