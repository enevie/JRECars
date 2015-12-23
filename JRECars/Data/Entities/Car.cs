using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace JRECars.Models
{
	public class Car
	{
		public int CarId { get; set; }
		[Required]
		public string Model { get; set; }
		public int ManufacturerId { get; set; }

		[Required(ErrorMessage = "Price is required")]
		[Range(100, 1000000.00,
			ErrorMessage = "Price must be between 100 and 100000")]
		public decimal Price { get; set; }

		public string Kilometers { get; set; }

		[Display(Name = "Year of Manufacture")]
		public string YearOfManufacture { get; set; }

		[Display(Name="Horse Power")]
		public int HorsePower { get; set; }

		public virtual ICollection<Images> Images { get; set; } 
	}
}