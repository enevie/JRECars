using System.ComponentModel.DataAnnotations;
using System;

namespace JRECars.Models
{
	public class Car
	{
		public int CarId { get; set; }
		[Required]
		public string Model { get; set; }
		public int ManufacturerId { get; set; }

		[Required(ErrorMessage = "Price is required")]
		[Range(100, 100000.00,
			ErrorMessage = "Price must be between 100 and 100000")]
		public decimal Price { get; set; }

		public byte[] CarImage { get; set; }

		public string Kilometers { get; set; }

		public string YearOfManufacture { get; set; }

		public int HorsePower { get; set; }

	}
}