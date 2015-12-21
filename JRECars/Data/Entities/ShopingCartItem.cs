using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRECars.Models
{
	public class ShopingCartItem
	{
		public int Id { get; set; }
		public int Quantity { get; set; }
		public System.DateTime DateCreated { get; set; }
		public int CarId { get; set; }
		public virtual Car Car { get; set; }

	}
}

