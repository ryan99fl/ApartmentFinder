using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentFinder.Models
{
	public class Address
	{
		[Required]
		[Key]
		public int AddressID { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(50)")]
		[Display(Name = "Street Address Line 1")]
		public required string Street1 { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		[Display(Name = "Street Address Line 2")]
		public string? Street2 { get; set; }

		[Required]
		[ForeignKey(nameof(Zipcode.ZipCode))]
		[Column(TypeName = "nvarchar(10)")]
		[Display(Name = "Zip Code (+4)")]
		public string ZipCode { get; set; } = string.Empty;
	}
}
