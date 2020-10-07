using PromotionEngine.Services.Models;

namespace PromotionEngine.Services.Calculation.Interfaces
{
	public interface IPromotion
	{
		Cart ApplyPromotion(Cart cart);
	}
}
