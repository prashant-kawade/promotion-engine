using PromotionEngine.Services.Calculation.Interfaces;
using PromotionEngine.Services.Models;
using System;
using System.Linq;

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
			var itemWithPromotion = cart.Items.Where(item => item.Product.Name == MultiPromotion.Name).ToList();

			if (itemWithPromotion.Count == 0)
			{ 
				return cart; 
			}

			var totalItems = itemWithPromotion.Sum(item => item.Quantity);

			if(totalItems < MultiPromotion.Quantity)
			{
				return cart;
			}

			var groupForApplingPromotion = (int)Math.Floor((decimal) totalItems / MultiPromotion.Quantity);
			var total = groupForApplingPromotion * MultiPromotion.FixedPrice;

			var remaining = totalItems - (groupForApplingPromotion * MultiPromotion.Quantity);

			total = total + remaining * itemWithPromotion.FirstOrDefault().Product.Price;

			return new Cart(cart.Items.Except(itemWithPromotion).ToList(), cart.Total + total);
		}
	}
}
