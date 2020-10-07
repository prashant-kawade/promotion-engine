using System.Collections.Generic;

namespace PromotionEngine.Services.Models
{
	public class Cart
	{
		public IEnumerable<Item> Items { get; private set; }

		public decimal Total { get; private set; }

		public Cart(IEnumerable<Item> items, decimal total)
		{
			Items = items;
			Total = total;
		}
	}
}
