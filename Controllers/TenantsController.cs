using ApartmentFinder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApartmentFinder.Controllers
{
    public class TenantsController : Controller
    {
        private readonly ApartmentFinderContext _context;
        public TenantsController(ApartmentFinderContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            using (var context = _context)
            {
                List<Lease> leases = context.Leases.ToList();
                List<Listing> listings = context.Listings.ToList();
                List<Address> addresses = context.Addresses.ToList();
                List<InternalUser> tenants = context.InternalUsers.ToList();

                var tenantStatuses = from le in leases
                                     join li in listings on le.ListingID equals li.ListingID into LeasedListings
                                     from leli in LeasedListings.ToList()
                                     join ad in addresses on leli.AddressID equals ad.AddressID into LeasedAddress
                                     from lead in LeasedAddress.ToList()
                                     join tenant in tenants on le.TenantID equals tenant.InternalUserID into LeasedTenants
                                     from letenant in LeasedTenants.ToList()
                                     select new TenantViewModel
                                     {
                                         lease = le,
                                         listing = leli,
                                         address = lead,
                                         tenant = letenant
                                     };
                return View(tenantStatuses);
            }
        }
    }
}
