using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace JRECars.Models
{
	public class CarViewModel
	{
		public int CarId { get; set; }
		public string Model { get; set; }
		public decimal Price { get; set; }
		public string ManufacturerName { get; set; }
		public int HorsePower { get; set; }
        [Display(Name = "Year of Manufacture")]
        public string YearOfManufacture { get; set; }
		public string Kilometers { get; set; }
		public string Manufacturer { get; set; }
        public IEnumerable<byte[]> Images { get; set; }
	}
}