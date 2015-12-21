using System.Drawing;

namespace JRECars.Models
{
	public class CarViewModel
	{
		public int CarId { get; set; }
		public string Model { get; set; }
		public decimal Price { get; set; }
		public string ManufacturerName { get; set; }
		public int HorsePower { get; set; }
		public string YearOfManufacture { get; set; }
		public string Kilometers { get; set; }
		public byte[] CarImage { get; set; }
		public Manufacturer Manufacturer { get; set; }
	}
}