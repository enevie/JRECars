using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRECars.Models
{
	public class CreateCarViewModel
	{
		public Car Car { get; set; }
		public IList<Manufacturer> Manufacturer { get; set; }
	}
}