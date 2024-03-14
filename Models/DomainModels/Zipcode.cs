using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentFinder.Models
{
	public class Zipcode
	{
		[Required]
		[Key]
		[Column(TypeName = "nvarchar(10)")]
		[Display(Name = "ZIP Code (+4)")]
		public required string ZipCode { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string City { get; set; } = string.Empty;

		[Column(TypeName = "nvarchar(50)")]
		public string State { get; set; } = string.Empty;
	}
}
