using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentFinder.Models
{
    public enum LeaseStatus
	{
		[Display(Name = "In Contract")]
		InContract,

		[Display(Name = "In Term")]
		InTerm,

		Complete,

		[Display(Name = "Payment Error")]
		PaymentError
	}

	[PrimaryKey(nameof(ListingID), nameof(TenantID))]
	public class Lease
	{
		[Required]
		[ForeignKey(nameof(Listing.ListingID))]
		public int ListingID { get; set; }

		[Required]
		[ForeignKey(nameof(InternalUser.InternalUserID))]
		public int TenantID { get; set; }

		[Required]
		public LeaseStatus Status { get; set; }
	}
}
