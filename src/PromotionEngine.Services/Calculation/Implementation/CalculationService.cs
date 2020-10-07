using PromotionEngine.Services.Calculation.Interfaces;
using PromotionEngine.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Services.Calculation.Implementation
{
	public class CalculationService : ICalculationService
	{
		public decimal GetTotal(IEnumerable<Item> items, IEnumerable<IPromotion> promotions)
		{
			var finalCart = new Cart(items.ToList(), 0);

			foreach(var promotion in promotions)
			{
				finalCart = promotion.ApplyPromotion(finalCart);
			}

			var remaining = finalCart.Items.Any() ? finalCart.Items.Sum(x => x.Product.Price) : 0;

			return finalCart.Total + remaining;
		}
	}
}
