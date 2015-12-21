using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRECars.ViewModels
{
	public class CartViewModel
	{
		public List<ShopingCartItem> Items { get; set; }
		public decimal Total { get; set; }
	}
}