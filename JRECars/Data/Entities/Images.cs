using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JRECars.Models
{
	public class Images
	{
		[Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ImageId { get; set; }
		public byte[] Image { get; set; }
		public virtual Car Car { get; set; }
	}
}
