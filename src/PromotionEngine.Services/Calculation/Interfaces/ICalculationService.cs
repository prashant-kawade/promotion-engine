using PromotionEngine.Services.Models;
using System.Collections.Generic;

namespace PromotionEngine.Services.Calculation.Interfaces
{
	public interface ICalculationService
	{
		decimal GetTotal(IEnumerable<Item> items, IEnumerable<IPromotion> promotions);
	}
}
