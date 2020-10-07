using System.Collections.Generic;

namespace PromotionEngine.Services.Models
{
	public class ComboPromotion
	{
		public IEnumerable<string> Names { get; private set; }

		public decimal FixedPrice { get; private set; }

		public ComboPromotion(IEnumerable<string> names, decimal fixedPrice)
		{
			Names = names;
			FixedPrice = fixedPrice;
		}
	}
}
