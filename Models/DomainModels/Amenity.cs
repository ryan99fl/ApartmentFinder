using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentFinder.Models
{
	public class Amenity
	{
		[Required]
		[Key]
		public int AmenityID { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(25)")]
		public required string Name { get; set; }

		[Column(TypeName = "nvarchar(250)")]
		public string? Description { get; set; }
	}
}
