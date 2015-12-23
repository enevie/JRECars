using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JRECars.Models;

namespace JRECars
{
	public partial class ShopingCartItem
	{
		#region Fields
		private Data.Context.JREMotorsDB db = new Data.Context.JREMotorsDB();
		public const string CartSessionKey = "CartId";
		int ShoppingCartId { get; set; }

		#endregion


		public static ShopingCartItem GetCart(HttpContextBase context)
		{
			var cart = new ShopingCartItem();
			cart.ShoppingCartId = cart.GetCartId(context);
			return cart;
		}

		public static ShopingCartItem GetCart(Controller controller)
		{
			return GetCart(controller.HttpContext);
		}

		public int GetCartId(HttpContextBase context)
		{
			if (context.Session[CartSessionKey] == null)
			{
				if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
				{
					context.Session[CartSessionKey] =
						context.User.Identity.Name;
				}
				else
				{
					// Generate a new random GUID using System.Guid class
					Guid tempCartId = Guid.NewGuid();
					// Send tempCartId back to client as a cookie
					context.Session[CartSessionKey] = tempCartId.ToString();
				}
			}
			return (int)context.Session[CartSessionKey];
		}


	}
}