using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NilamHutAPI.Services.interfaces;
using NilamHutAPI.ViewModels.PostRelated;

namespace NilamHutAPI.Controllers
{
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        private readonly IServiceUnit _serviceUnit;

        public PostController(IServiceUnit serviceUnit)
        {
            _serviceUnit = serviceUnit;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _serviceUnit.Post.Get();
            if (posts == null) return BadRequest();
            return Json(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var posts = await _serviceUnit.Post.Get(id);
            if (posts == null) return BadRequest();
            return Json(posts);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostViewModel postFromView)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _serviceUnit.Post.Post(postFromView);
            Guid GuidOutput;
            bool isGuid = Guid.TryParse(result, out GuidOutput);
            if (!isGuid) return BadRequest(result);
            else return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] PostViewModel postFromView)
        {
            if (!ModelState.IsValid) return BadRequest();

            var result = await _serviceUnit.Post.Put(id,postFromView);
            Guid GuidOutput;
            bool isGuid = Guid.TryParse(result, out GuidOutput);
            if (!isGuid) return BadRequest(result);
            else return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var posts = await _serviceUnit.Post.Delete(id);
            if (posts == false) return BadRequest();
            return Ok();
        }
    }
}
