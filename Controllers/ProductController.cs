using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NilamHutAPI.Data;
using NilamHutAPI.Helpers;
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
        private readonly IServiceUnit _serviceUnit;

        public ProductController(IServiceUnit serviceUnit)
        {
            _serviceUnit = serviceUnit;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bids = await _serviceUnit.Product.Get();
            if (bids == null) return BadRequest();
            return Json(bids);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var bids = await _serviceUnit.Product.Get(id);
            if (bids == null) return BadRequest();
            return Json(bids);
        }

        [HttpGet("GetWithData/{id}")]
        public async Task<IActionResult> GetWithData(Guid id)
        {
            var Product = await _serviceUnit.Product.GetWithRelatedData(id);
            if (Product == null) return BadRequest(Errors.AddErrorToModelState("Error Getting product From Database", "Unsuccessfull.", ModelState));
            return Json(Product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ProductViewModel productFromForm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _serviceUnit.Product.Post(productFromForm);
            Guid GuidOutput;
            bool isGuid = Guid.TryParse(result, out GuidOutput);
            if (!isGuid) return BadRequest(result);
            else return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var posts = await _serviceUnit.Product.Delete(id);
            if (posts == false) return BadRequest();
            return Ok();
        }
    }
}
