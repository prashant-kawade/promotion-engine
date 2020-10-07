namespace PromotionEngine.Services.Models
{
	public class MultiPromotion
	{
		public string Name { get; private set; }

		public int Quantity { get; private set; }

		public decimal FixedPrice { get; private set; }

		public MultiPromotion(string name, int quantity, decimal fixedPrce)
		{
			Name = name;
			Quantity = quantity;
			FixedPrice = fixedPrce;
		}
	}
}
