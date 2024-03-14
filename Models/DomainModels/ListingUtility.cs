using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentFinder.Models
{
	public class ListingUtility
	{
		[Required]
		[Key]
		public int ServiceID { get; set; }

		[Required]
		[ForeignKey(nameof(Utility.UtilityID))]
		public int UtilityID { get; set; }

		[Required]
		[ForeignKey(nameof(Listing.ListingID))]
		public int ListingID { get; set; }

		[Precision(10, 2)]
		[Range(0, (double)decimal.MaxValue)]
		[Display(Name = "Utilities Estimate")]
		public decimal UtilitiesEstimate { get; set; }
	}
}
