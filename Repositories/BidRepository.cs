using NilamHutAPI.Data;
using NilamHutAPI.Models;
using NilamHutAPI.Repositories.interfaces;

namespace NilamHutAPI.Repositories
{
    public class BidRepository : Repository<Bid>, IBidRepository
    {
        public BidRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}