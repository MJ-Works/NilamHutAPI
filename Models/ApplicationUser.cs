using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace NilamHutAPI.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public List<Bid> Bids;
        public List<Product> Products { get; set; }
        public List<SoldHistory> SoldHistories { get; set; }
        public User User { get; set; }
    }
}
