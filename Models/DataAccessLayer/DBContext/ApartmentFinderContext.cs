
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApartmentFinder.Models
{
    public class ApartmentFinderContext : IdentityDbContext
    {
        // ctor
        public ApartmentFinderContext(DbContextOptions<ApartmentFinderContext> options) : base(options)
        {
        }

        // one DbSet per model
        public DbSet<InternalUser> InternalUsers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Lease> Leases { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<ListingAmenity> ListingAmenities { get; set; }
        public DbSet<ListingUtility> ListingUtilities { get; set; }
        public DbSet<Utility> Utilities { get; set; }
        public DbSet<Zipcode> ZipCodes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ApartmentFinderConfiguration(modelBuilder);
        }
    }
}
