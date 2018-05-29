using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NilamHutAPI.Repositories.interfaces;
using NilamHutAPI.Services.interfaces;
using NilamHutAPI.ViewModels.PostRelated;
using NilamHutAPI.Hubs;
using NilamHutAPI.Hubs.Interfaces;

namespace NilamHutAPI.Controllers
{
    [Route("api/[controller]")]
    public class BidController : Controller
    {
        private readonly IHubContext<NotifyBidHub,ITypedBidHub> _hubContext;
        private readonly IServiceUnit _serviceUnit;

        public BidController(IServiceUnit serviceUnit, IHubContext<NotifyBidHub, ITypedBidHub> hubContext)
        {
            _serviceUnit = serviceUnit;
            _hubContext = hubContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bids = await _serviceUnit.Bid.Get();
            if (bids == null) return BadRequest();
            return Json(bids);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var bids = await _serviceUnit.Bid.Get(id);
            if (bids == null) return BadRequest();
            return Json(bids);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BidViewModel bidFromView)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _serviceUnit.Bid.Post(bidFromView);
            Guid GuidOutput;
            bool isGuid = Guid.TryParse(result, out GuidOutput);
            if (!isGuid) return BadRequest(result);

            //send data to all hub
            else
            {
                 var bids = await _serviceUnit.Bid.Get(new Guid(result));
                 await _hubContext.Clients.All.SendMessage(bids);
                return Ok();
            } 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] BidViewModel bidFromView)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _serviceUnit.Bid.Put(id, bidFromView);
            Guid GuidOutput;
            bool isGuid = Guid.TryParse(result, out GuidOutput);
            if (!isGuid) return BadRequest(result);
            else return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var posts = await _serviceUnit.Bid.Delete(id);
            if (posts == false) return BadRequest();
            return Ok();
        }
    }
}
