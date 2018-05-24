using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NilamHutAPI.Data;
using NilamHutAPI.Models;
using NilamHutAPI.Repositories.interfaces;
using NilamHutAPI.Services.interfaces;
using NilamHutAPI.ViewModels.PostRelated;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NilamHutAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IUnitOfWork _repository;
        private readonly ApplicationDbContext _context;

        public ProductController(IProductService productService, IUnitOfWork repository, ApplicationDbContext context)
        {
            _productService = productService;
            _repository = repository;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bids = await _productService.Get();
            if (bids == null) return BadRequest();
            return Json(bids);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var bids = await _productService.Get(id);
            if (bids == null) return BadRequest();
            return Json(bids);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ProductViewModel productFromForm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _productService.Post(productFromForm);
            Guid GuidOutput;
            bool isGuid = Guid.TryParse(result, out GuidOutput);
            if (!isGuid) return BadRequest(result);
            else return Ok();
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(Guid id, [FromBody] ProductViewModel productFromForm)
        //{
        //    if (!ModelState.IsValid) return BadRequest();

        //    var result = await _productService.Put(id, productFromForm);
        //    Guid GuidOutput;
        //    bool isGuid = Guid.TryParse(result, out GuidOutput);
        //    if (!isGuid) return BadRequest(result);
        //    else return Ok();
        //}

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var posts = await _productService.Delete(id);
            if (posts == false) return BadRequest();
            return Ok();
        }
    }
}
