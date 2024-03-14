using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentFinder.Models
{
	public enum UtilityType
	{
		Gas,
		Electric,
		Cable,
		Water,
		Garbage,
		Telecom
	}
	public class Utility
	{
		[Required]
		[Key]
		public int UtilityID { get; set; }

		[Required]
		[Display(Name = "Utility Type")]
		public required UtilityType UtilityType { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(50)")]
		public required string Name { get; set; }

		[Column(TypeName = "nvarchar(250)")]
		public Uri? Website { get; set; }

		[Precision(5, 2)]
		[Range(0, (double)decimal.MaxValue)]
		[Display(Name = "Estimated Monthly Rate")]
		public decimal EstMonRate { get; set; }
	}
}
