using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentFinder.Models
{
	[PrimaryKey(nameof(ListingID), nameof(AmenityID))]
	public class ListingAmenity
	{
		[Required]
		[ForeignKey(nameof(Listing.ListingID))]
		public int ListingID { get; set; }

		[Required]
		[ForeignKey(nameof(Amenity.AmenityID))]
		public int AmenityID { get; set; }

		[Column(TypeName = "nvarchar(250)")]
		public string? Notes { get; set; } = null!;
	}
}
