using PromotionEngine.Services.Calculation.Interfaces;
using PromotionEngine.Services.Models;
using System.Collections.Generic;
using System.Linq;

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
            var items = cart.Items.Where(x => ComboPromotion.Names.Any(c => c == x.Product.Name)).ToList();

            var numberOfCombos = ComboPromotion.Names.Select(x => items.Count(i => i.Product.Name == x)).Min();

            if(numberOfCombos == 0)
			{
                return cart;
			}

            var total = ComboPromotion.FixedPrice * numberOfCombos;

            var calculatedItems = new List<Item>();

            foreach (var name in ComboPromotion.Names)
            {
                calculatedItems.AddRange(items.Where(x => x.Product.Name == name).Take(numberOfCombos));
            }

            var uncalculatedItems = items.Except(calculatedItems);

            total += uncalculatedItems.Any() ? uncalculatedItems.Sum(x => x.Product.Price) : default;

            return new Cart(cart.Items.Except(items).ToList(), cart.Total + total);
        }
	}
}
