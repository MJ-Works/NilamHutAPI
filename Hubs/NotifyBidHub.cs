using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using NilamHutAPI.ViewModels.PostRelated;
using NilamHutAPI.Hubs.Interfaces;
namespace NilamHutAPI.Hubs
{
    public class NotifyBidHub : Hub<ITypedBidHub>
    {

    }
}