using System.Collections.Generic;
using System.Threading.Tasks;
using NilamHutAPI.Models;
using NilamHutAPI.ViewModels.FrontEnd;
namespace NilamHutAPI.Hubs.Interfaces
{
    public interface ITypedBidHub
    {
        Task SendMessage(Bid bidModel);
        Task SendMessageToProductView(BidFrontEnd bidModel);
    }
}