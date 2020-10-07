using PromotionEngine.Services.Calculation.Interfaces;
using PromotionEngine.Services.Models;
using System.Collections.Generic;

namespace PromotionEngine.Services.Calculation.Implementation
{
	public class CalculationService : ICalculationService
	{
		public decimal GetTotal(IEnumerable<Item> items, IEnumerable<IPromotion> promotions)
		{
			throw new System.NotImplementedException();
		}
	}
}
