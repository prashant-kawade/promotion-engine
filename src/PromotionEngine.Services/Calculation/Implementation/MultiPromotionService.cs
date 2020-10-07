using PromotionEngine.Services.Calculation.Interfaces;
using PromotionEngine.Services.Models;

namespace PromotionEngine.Services.Calculation.Implementation
{
	public class MultiPromotionService : IPromotion
	{
		public MultiPromotion MultiPromotion { get; private set; }


		public MultiPromotionService(MultiPromotion multiPromotion)
		{
			MultiPromotion = multiPromotion;
		}

		public Cart ApplyPromotion(Cart cart)
		{
			throw new System.NotImplementedException();
		}
	}
}
