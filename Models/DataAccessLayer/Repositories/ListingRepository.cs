using ApartmentFinder.Models;

namespace ApartmentFinder.Models
{
    public class ListingRepository : Repository<Listing>
	{
		public ListingRepository(ApartmentFinderContext context) : base(context)
		{

		}
	}
}
