using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NilamHutAPI.Repositories.interfaces;
using NilamHutAPI.Services.interfaces;
using NilamHutAPI.ViewModels.PostRelated;

namespace NilamHutAPI.Controllers
{
    [Route("api/[controller]")]
    public class BidController : Controller
    {
        private readonly IBidService _bidService;
        private readonly IUnitOfWork _repository;

        public BidController(IBidService bidService, IUnitOfWork repository)
        {
            _bidService = bidService;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bids = await _bidService.Get();
            if (bids == null) return BadRequest();
            return Json(bids);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var bids = await _bidService.Get(id);
            if (bids == null) return BadRequest();
            return Json(bids);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BidViewModel bidFromView)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _bidService.Post(bidFromView);
            Guid GuidOutput;
            bool isGuid = Guid.TryParse(result, out GuidOutput);
            if (!isGuid) return BadRequest(result);
            else return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] BidViewModel bidFromView)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _bidService.Put(id, bidFromView);
            Guid GuidOutput;
            bool isGuid = Guid.TryParse(result, out GuidOutput);
            if (!isGuid) return BadRequest(result);
            else return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var posts = await _bidService.Delete(id);
            if (posts == false) return BadRequest();
            return Ok();
        }
    }
}
