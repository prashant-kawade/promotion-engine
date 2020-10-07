using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Services.Calculation.Implementation;
using PromotionEngine.Services.Calculation.Interfaces;
using PromotionEngine.Services.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine.Services.Tests
{
	[TestClass]
	public class PromotionEngineTests
	{
		private readonly List<Product> _products;
		private readonly ICalculationService _calculationService;
		private readonly IEnumerable<IPromotion> _promotions;

		public PromotionEngineTests()
		{
			var p1 = new Product("A", 50);
			var p2 = new Product("B", 30);
			var p3 = new Product("C", 20);
			var p4 = new Product("D", 15);

			_products = new List<Product>
			{
				p1,p2,p3,p4
			};

			_calculationService = new CalculationService();

			_promotions = new List<IPromotion>
			{
				new MultiPromotionService(new MultiPromotion("A", 3, 130)),
				new MultiPromotionService(new MultiPromotion("B", 2, 45)),
				new ComboPromotionService(new ComboPromotion(new List<string>{"C","D"}, 30))
			};
		}

		[TestMethod]
		public void Calculate_Total_With_No_Promotion()
		{
			//Arrange
			var items = new List<Item>()
			{
				new Item(_products[2], 1)
			};

			//Act
			var total = _calculationService.GetTotal(items, _promotions);

			//Assert
			Assert.AreEqual(20, total);
		}

		[TestMethod]
		public void Calculate_Total_With_No_Promotion_Applicable()
		{
			//Arrange
			var items = new List<Item>() 
			{
				new Item(_products[0], 1),
				new Item(_products[1], 1),
				new Item(_products[2], 1)
			};

			//Act
			var total = _calculationService.GetTotal(items, _promotions);

			//Assert
			Assert.AreEqual(100, total);
		}

		[TestMethod]
		public void Calculate_Total_With_Multi_Promotion()
		{
			//Arrange
			var items = new List<Item>()
			{
				new Item(_products[0], 5),
				new Item(_products[1], 5),
				new Item(_products[2], 1)
			};

			//Act
			var total = _calculationService.GetTotal(items, _promotions);

			//Assert
			Assert.AreEqual(370, total);
		}

		[TestMethod]
		public void Calculate_Total_With_Multi_And_Combo_Promotion()
		{
			//Arrange
			var items = new List<Item>()
			{
				new Item(_products[0], 3),
				new Item(_products[1], 5),
				new Item(_products[2], 1),
				new Item(_products[3], 1)
			};

			//Act
			var total = _calculationService.GetTotal(items, _promotions);

			//Assert
			Assert.AreEqual(280, total);
		}
	}
}
