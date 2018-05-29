using System.Collections.Generic;
using System.Threading.Tasks;
using NilamHutAPI.Models;
namespace NilamHutAPI.Hubs.Interfaces
{
    public interface ITypedBidHub
    {
        Task SendMessage(IEnumerable<Bid> bidModel);
    }
}