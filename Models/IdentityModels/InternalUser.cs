using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApartmentFinder.Models
{
    public class InternalUser : IdentityUser
    {
        public int InternalUserID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "First Name")]
        public required string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Last Name")]
        public required string LastName { get; set; }

        // public string AspNetRef { get; set; } = string.Empty;
    }
}
