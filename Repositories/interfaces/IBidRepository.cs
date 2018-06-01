using System;
using System.Threading.Tasks;
using NilamHutAPI.Models;
using NilamHutAPI.ViewModels.FrontEnd;

namespace NilamHutAPI.Repositories.interfaces
{
    public interface IBidRepository : IRepository<Bid>
    {
        Task<Bid> BidForProductView(Guid id);
    }
}