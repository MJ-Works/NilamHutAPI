using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NilamHutAPI.Data;
using NilamHutAPI.Models;
using NilamHutAPI.Repositories.interfaces;
using NilamHutAPI.ViewModels.FrontEnd;

namespace NilamHutAPI.Repositories
{
    public class BidRepository : Repository<Bid>, IBidRepository
    {
        private readonly  ApplicationDbContext _applicationDbContext;
        public BidRepository(ApplicationDbContext context) : base(context)
        {
            _applicationDbContext = context;
        }

        public async Task<Bid> BidForProductView(Guid id)
        {
            return await _applicationDbContext.Bid.Include(i => i.ApplicationUser)
                                                        .ThenInclude(i => i.User)
                                                      .Where(i => i.Id == id).FirstOrDefaultAsync();

        }
    }
}