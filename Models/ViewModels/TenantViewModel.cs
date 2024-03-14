using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApartmentFinder.Models
{
    public class TenantViewModel
    {
        public Lease? lease { get; set; }
        public Listing? listing { get; set; }
        public Address? address { get; set; }
        public InternalUser? tenant { get; set; }
    }
}
