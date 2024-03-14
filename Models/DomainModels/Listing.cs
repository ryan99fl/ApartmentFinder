using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentFinder.Models
{
    public class Listing
	{
		[Required]
		[Key]
		public int ListingID { get; set; }

		[Required]
		[ForeignKey(nameof(InternalUser.InternalUserID))]
		public int OwnerID { get; set; }

		[Required]
		[ForeignKey(nameof(Address.AddressID))]
		public int AddressID { get; set; }

		[Column(TypeName = "nvarchar(25)")]
		public string? Unit { get; set; }

		[Required]
		[Range(0, int.MaxValue)]
		public int Bedrooms { get; set; }

		[Required]
		[Range(0, int.MaxValue)]
		public int Bathrooms { get; set; }

		[Range(0, float.MaxValue)]
		[Display(Name = "Square Feet")]
		public float SquareFoot { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Date Available")]
		public DateTime DateAvailable { get; set; }

		[Range(0, int.MaxValue)]
		[Display(Name = "Months' Lease")]
		public int Months { get; set; }

		[Required]
		[Precision(10,2)]
		[Range(0, (double)decimal.MaxValue)]
		[Display(Name = "Monthly Rent")]
		public decimal MonthlyRate { get; set; }
	}
}
