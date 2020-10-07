using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine.Services.Calculation.Implementation;
using PromotionEngine.Services.Calculation.Interfaces;
using PromotionEngine.Services.Models;
using System.Collections;
using System.Collections.Generic;

namespace PromotionEngine.Services.Tests
{
	[TestClass]
	public class PromotionEngineTests
	{
		private readonly IEnumerable<Product> _products;
		private readonly ICalculationService _calculationService;

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
		}

		[TestMethod]
		public void TestMethod1()
		{
		}
	}
}
