using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApartmentFinder.Models
{
    public class ApartmentFinderConfiguration
    {
        public ApartmentFinderConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new ZipConfig());
            modelBuilder.ApplyConfiguration(new AddressConfig());
            modelBuilder.ApplyConfiguration(new UtilitiesConfig());
            modelBuilder.ApplyConfiguration(new AmenityConfig());
            modelBuilder.ApplyConfiguration(new ListingConfig());
            modelBuilder.ApplyConfiguration(new ListingUtilityConfig());
            modelBuilder.ApplyConfiguration(new ListingAmenityConfig());
            modelBuilder.ApplyConfiguration(new LeaseConfig());
        }

        protected internal class UserConfig : IEntityTypeConfiguration<InternalUser>
        {
            public void Configure(EntityTypeBuilder<InternalUser> entityTypeBuilder)
            {
                entityTypeBuilder.HasData(
                    new InternalUser { InternalUserID = 1, FirstName = "RyanAdmin", LastName = "Southwell" },
                    new InternalUser { InternalUserID = 2, FirstName = "RyanUser", LastName = "Southwell" },
                    new InternalUser { InternalUserID = 3, FirstName = "Michael", LastName = "Johnson" },
                    new InternalUser { InternalUserID = 4, FirstName = "Emily", LastName = "Williams" },
                    new InternalUser { InternalUserID = 5, FirstName = "David", LastName = "Brown" },
                    new InternalUser { InternalUserID = 6, FirstName = "Sarah", LastName = "Jones" },
                    new InternalUser { InternalUserID = 7, FirstName = "Daniel", LastName = "Garcia" },
                    new InternalUser { InternalUserID = 8, FirstName = "Jennifer", LastName = "Martinez" },
                    new InternalUser { InternalUserID = 9, FirstName = "Christopher", LastName = "Hernandez" },
                    new InternalUser { InternalUserID = 10, FirstName = "Lisa", LastName = "Lopez" },
                    new InternalUser { InternalUserID = 11, FirstName = "Matthew", LastName = "Gonzalez" },
                    new InternalUser { InternalUserID = 12, FirstName = "Jessica", LastName = "Wilson" },
                    new InternalUser { InternalUserID = 13, FirstName = "James", LastName = "Anderson" },
                    new InternalUser { InternalUserID = 14, FirstName = "Ashley", LastName = "Thomas" },
                    new InternalUser { InternalUserID = 15, FirstName = "Robert", LastName = "Taylor" },
                    new InternalUser { InternalUserID = 16, FirstName = "Amanda", LastName = "Moore" },
                    new InternalUser { InternalUserID = 17, FirstName = "Ryan", LastName = "Jackson" },
                    new InternalUser { InternalUserID = 18, FirstName = "Michelle", LastName = "White" },
                    new InternalUser { InternalUserID = 19, FirstName = "William", LastName = "Harris" },
                    new InternalUser { InternalUserID = 20, FirstName = "Stephanie", LastName = "Martin" },
                    new InternalUser { InternalUserID = 21, FirstName = "John", LastName = "Doe" },
                    new InternalUser { InternalUserID = 22, FirstName = "Jane", LastName = "Smith" }

                );
            }
        }

        protected internal class ZipConfig : IEntityTypeConfiguration<Zipcode>
        {
            public void Configure(EntityTypeBuilder<Zipcode> entityTypeBuilder)
            {
                entityTypeBuilder.HasData(
                    new Zipcode { ZipCode = "32501", City = "Pensacola", State = "FL" },
                    new Zipcode { ZipCode = "32505", City = "Pensacola", State = "FL" },
                    new Zipcode { ZipCode = "32509", City = "Pensacola", State = "FL" },
                    new Zipcode { ZipCode = "32514", City = "Pensacola", State = "FL" },
                    new Zipcode { ZipCode = "32526", City = "Pensacola", State = "FL" },
                    new Zipcode { ZipCode = "32561", City = "Gulf Breeze", State = "FL" },
                    new Zipcode { ZipCode = "32566", City = "Navarre", State = "FL" },
                    new Zipcode { ZipCode = "32571", City = "Milton", State = "FL" },
                    new Zipcode { ZipCode = "32591", City = "Milton", State = "FL" },
                    new Zipcode { ZipCode = "33954", City = "Port Charlotte", State = "FL" }
                );
            }
        }

        protected internal class AddressConfig : IEntityTypeConfiguration<Address>
        {
            public void Configure(EntityTypeBuilder<Address> entityTypeBuilder)
            {
                entityTypeBuilder.HasData(
                    // Escambia County, FL ZIP codes
                    new Address { AddressID = 1, Street1 = "123 Main St", ZipCode = "32501" },
                    new Address { AddressID = 2, Street1 = "456 Elm St", ZipCode = "32501" },
                    new Address { AddressID = 3, Street1 = "222 Maple Ave", ZipCode = "32505" },
                    new Address { AddressID = 4, Street1 = "333 Cedar St", ZipCode = "32505" },
                    new Address { AddressID = 5, Street1 = "777 Walnut St", ZipCode = "32509" },
                    new Address { AddressID = 6, Street1 = "888 Chestnut St", ZipCode = "32509" },
                    new Address { AddressID = 7, Street1 = "999 Willow St", Street2 = "Suite 100", ZipCode = "32514" },
                    new Address { AddressID = 8, Street1 = "222 Elmwood Dr", ZipCode = "32514" },
                    new Address { AddressID = 9, Street1 = "333 Oakwood Dr", ZipCode = "32514" },
                    new Address { AddressID = 10, Street1 = "444 Pinecrest Ln", ZipCode = "32526" },
                    new Address { AddressID = 11, Street1 = "555 Cedarwood Ln", ZipCode = "32526" },
                    new Address { AddressID = 12, Street1 = "123 Beach Blvd", ZipCode = "32561" },
                    new Address { AddressID = 13, Street1 = "456 Seaside Dr", ZipCode = "32561" },
                    new Address { AddressID = 14, Street1 = "222 Shoreline Dr", ZipCode = "32566" },
                    new Address { AddressID = 15, Street1 = "333 Coastal Way", ZipCode = "32566" },
                    new Address { AddressID = 16, Street1 = "444 Harbor View Dr", ZipCode = "32571" },
                    new Address { AddressID = 17, Street1 = "555 Bayfront Ave", ZipCode = "32571" },
                    new Address { AddressID = 18, Street1 = "999 Sailboat Cir", Street2 = "2nd Floor", ZipCode = "32591" },
                    new Address { AddressID = 19, Street1 = "111 Anchor Dr", Street2 = "Building B", ZipCode = "32591" }
                );
            }
        }

        protected internal class UtilitiesConfig : IEntityTypeConfiguration<Utility>
        {
            public void Configure(EntityTypeBuilder<Utility> entityTypeBuilder)
            {
                entityTypeBuilder.HasData(
                    new Utility { UtilityID = 1, UtilityType = UtilityType.Gas, Name = "Gas Company A", Website = new Uri("http://www.gascompanyA.com"), EstMonRate = 50.00m },
                    new Utility { UtilityID = 2, UtilityType = UtilityType.Electric, Name = "Electric Company B", Website = new Uri("http://www.electriccompanyB.com"), EstMonRate = 70.00m },
                    new Utility { UtilityID = 3, UtilityType = UtilityType.Cable, Name = "Cable Company C", Website = new Uri("http://www.cablecompanyC.com"), EstMonRate = 80.00m },
                    new Utility { UtilityID = 4, UtilityType = UtilityType.Water, Name = "Water Company D", Website = new Uri("http://www.watercompanyD.com"), EstMonRate = 40.00m },
                    new Utility { UtilityID = 5, UtilityType = UtilityType.Garbage, Name = "Garbage Company E", Website = new Uri("http://www.garbagecompanyE.com"), EstMonRate = 30.00m },
                    new Utility { UtilityID = 6, UtilityType = UtilityType.Telecom, Name = "Telecom Company F", Website = new Uri("http://www.telecomcompanyF.com"), EstMonRate = 60.00m },
                    new Utility { UtilityID = 7, UtilityType = UtilityType.Gas, Name = "Gas Company G", Website = new Uri("http://www.gascompanyG.com"), EstMonRate = 55.00m },
                    new Utility { UtilityID = 8, UtilityType = UtilityType.Electric, Name = "Electric Company H", Website = new Uri("http://www.electriccompanyH.com"), EstMonRate = 75.00m },
                    new Utility { UtilityID = 9, UtilityType = UtilityType.Cable, Name = "Cable Company I", Website = new Uri("http://www.cablecompanyI.com"), EstMonRate = 85.00m },
                    new Utility { UtilityID = 10, UtilityType = UtilityType.Water, Name = "Water Company J", Website = new Uri("http://www.watercompanyJ.com"), EstMonRate = 45.00m }
                );
            }
        }

        protected internal class AmenityConfig : IEntityTypeConfiguration<Amenity>
        {
            public void Configure(EntityTypeBuilder<Amenity> entityTypeBuilder)
            {
                entityTypeBuilder.HasData(
                    new Amenity { AmenityID = 1, Name = "Swimming Pool", Description = "Outdoor pool available for residents." },
                    new Amenity { AmenityID = 2, Name = "Fitness Center", Description = "Fully-equipped fitness center with cardio and strength training equipment." },
                    new Amenity { AmenityID = 3, Name = "Dog Park", Description = "On-site dog park for residents with pets." },
                    new Amenity { AmenityID = 4, Name = "Tennis Court", Description = "Well-maintained tennis court available for resident use." },
                    new Amenity { AmenityID = 5, Name = "Clubhouse", Description = "Spacious clubhouse with social areas and events for residents." },
                    new Amenity { AmenityID = 6, Name = "Business Center", Description = "On-site business center with computers, printers, and meeting rooms." },
                    new Amenity { AmenityID = 7, Name = "Playground", Description = "Outdoor playground area for children." },
                    new Amenity { AmenityID = 8, Name = "Pet Spa", Description = "On-site pet grooming station with bathing facilities." },
                    new Amenity { AmenityID = 9, Name = "Yoga Studio", Description = "Dedicated yoga studio for residents to practice yoga and meditation." },
                    new Amenity { AmenityID = 10, Name = "Grilling Area", Description = "Outdoor grilling and picnic area for resident use." },
                    new Amenity { AmenityID = 11, Name = "Game Room", Description = "Game room with billiards, foosball, and other entertainment options." },
                    new Amenity { AmenityID = 12, Name = "Bike Storage", Description = "Secure bike storage area for residents." },
                    new Amenity { AmenityID = 13, Name = "Movie Theater", Description = "On-site movie theater with regular movie screenings." },
                    new Amenity { AmenityID = 14, Name = "Sauna", Description = "Relaxing sauna available for resident use." },
                    new Amenity { AmenityID = 15, Name = "Car Wash Station", Description = "Convenient car wash station for residents." },
                    new Amenity { AmenityID = 16, Name = "Roof Deck", Description = "Scenic roof deck with panoramic views of the city." },
                    new Amenity { AmenityID = 17, Name = "Valet Trash Service", Description = "Daily valet trash service for residents' convenience." },
                    new Amenity { AmenityID = 18, Name = "Gated Entry", Description = "Secure gated entry with controlled access for residents." },
                    new Amenity { AmenityID = 19, Name = "Package Lockers", Description = "Package lockers for secure delivery and retrieval of packages." },
                    new Amenity { AmenityID = 20, Name = "24-Hour Maintenance", Description = "24-hour emergency maintenance service for residents." }
                );
            }
        }

        protected internal class ListingConfig : IEntityTypeConfiguration<Listing>
        {
            public void Configure(EntityTypeBuilder<Listing> entityTypeBuilder)
            {
                var random = new Random();
                var seedData = new List<Listing>();

                for (int i = 1; i <= 40; i++)
                {
                    var listing = new Listing
                    {
                        ListingID = i,
                        OwnerID = random.Next(1, 23), // Random OwnerID between 1 and 22
                        AddressID = random.Next(1, 20), // Random AddressID between 1 and 19
                        Unit = "Unit " + i,
                        Bedrooms = random.Next(1, 6), // Random number of bedrooms between 1 and 5
                        Bathrooms = random.Next(1, 4), // Random number of bathrooms between 1 and 3
                        SquareFoot = random.Next(800, 3001), // Random square footage between 800 and 3000
                        DateAvailable = DateTime.Now.AddDays(random.Next(1, 31)), // Random date within the next 30 days
                        Months = random.Next(1, 13), // Random number of months for lease between 1 and 12
                        MonthlyRate = random.Next(500, 3001) // Random monthly rent between 500 and 3000
                    };

                    seedData.Add(listing);
                }

                entityTypeBuilder.HasData(seedData);
            }

        }

        protected internal class ListingUtilityConfig : IEntityTypeConfiguration<ListingUtility>
        {
            public void Configure(EntityTypeBuilder<ListingUtility> entityTypeBuilder)
            {
                var random = new Random();
                var seedData = new List<ListingUtility>();

                for (int i = 1; i <= 15; i++)
                {
                    var listingUtility = new ListingUtility
                    {
                        ServiceID = i,
                        UtilityID = random.Next(1, 10), // Random UtilityID between 1 and 10
                        ListingID = random.Next(1, 40), // Random ListingID between 1 and 40
                        UtilitiesEstimate = (decimal)random.NextDouble() * 500 // Random UtilitiesEstimate between 0 and 500
                    };

                    seedData.Add(listingUtility);
                }

                entityTypeBuilder.HasData(seedData);
            }
        }

        protected internal class ListingAmenityConfig : IEntityTypeConfiguration<ListingAmenity>
        {
            public void Configure(EntityTypeBuilder<ListingAmenity> entityTypeBuilder)
            {
                var seedData = new List<ListingAmenity>();

                for (int i = 1; i <= 15; i++)
                {
                    var listingAmenity = new ListingAmenity
                    {
                        ListingID = 20 + i,
                        AmenityID = 20 - i,
                        Notes = ("Iteration " + i + " of seed data")
                    };

                    seedData.Add(listingAmenity);
                }

                entityTypeBuilder.HasData(seedData);
            }
        }
        protected internal class LeaseConfig : IEntityTypeConfiguration<Lease>
        {
            public void Configure(EntityTypeBuilder<Lease> entityTypeBuilder)
            {
                var random = new Random();
                var seedData = new List<Lease>();

                for (int i = 3; i <= 22; i++)
                {
                    Lease lease = new Lease();
                    lease.ListingID = i;
                    lease.TenantID = 23 - i;

                    switch (random.Next(1, 4))
                    {
                        case 1:
                            lease.Status = LeaseStatus.InContract;
                            break;
                        case 2:
                            lease.Status = LeaseStatus.Complete;
                            break;
                        case 3:
                            lease.Status = LeaseStatus.PaymentError;
                            break;
                        case 4:
                            lease.Status = LeaseStatus.InTerm;
                            break;
                    }

                    seedData.Add(lease);
                }

                entityTypeBuilder.HasData(seedData);
            }
        }
    }
}
