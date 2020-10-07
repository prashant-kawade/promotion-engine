﻿namespace PromotionEngine.Services.Models
{
	public class Item
	{
		public Product Product { get; private set; }

		public int Quantity { get; private set; }

		public Item(Product product, int quantity)
		{
			Product = product;
			Quantity = quantity;
		}
	}
}
