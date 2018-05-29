using System.Threading.Tasks;
using NilamHutAPI.ViewModels.PostRelated;
namespace NilamHutAPI.Hubs.Interfaces
{
    public interface ITypedBidHub
    {
        Task SendMessage(BidViewModel bidModel);
    }
}