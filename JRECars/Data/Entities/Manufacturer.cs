using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JRECars.Models
{
	public class Manufacturer
	{
		public int ManufacturerId { get; set; }
		[Required(ErrorMessage = "Manufacturer name is required")]
		[StringLength(160)]
		public string Name { get; set; }
		public virtual IEnumerable<Car> Cars { get; set; }
	}
}