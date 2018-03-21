using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NilamHutAPI.Services;
using NilamHutAPI.Models;
using NilamHutAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace NilamHutAPI.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]/[action]")]
    public class CommonController : Controller
    {
        private readonly ICommonService _commonService;
        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCountry([FromBody] CountryViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _commonService.AddCountry(model);

            if (result == true)
                return new OkObjectResult("Country Added");

            return BadRequest("Fail TO Add");
        }

        [HttpPost]
        public async Task<IActionResult> AddCity([FromBody] CityViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _commonService.AddCity(model);

            if (result == true)
                return new OkObjectResult("City Added");

            return BadRequest("Fail TO Add");
        }


        [HttpGet]
        public async Task<IActionResult> AllCity()
        {
            var result = await _commonService.AllCity();
            return new OkObjectResult(result);
        }


        [HttpGet]
        public async Task<IActionResult> AllCountry()
        {
            var result = await _commonService.AllCountrty();
            return new OkObjectResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> AllTags()
        {
            var result = await _commonService.AllTag();
            return new OkObjectResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> SingleTag(Guid id)
        {
            var result = await _commonService.getSingleTag(id);
            return new OkObjectResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditTag(Guid id, [FromBody] TagViewModel model)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _commonService.EditTag(id,model);

            if (result == true)
                return new OkObjectResult("Success");

            return BadRequest("Fail TO Update");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTag(Guid id)
        {
            var result = await _commonService.DeleteTag(id);

            if (result == true)
                return new OkObjectResult("Successs");

            return BadRequest("Fail TO Delete");
        }

        [HttpPost] 
        public async Task<IActionResult> AddTag([FromBody]TagViewModel model)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _commonService.AddTag(model);

            if (result == true)
                return new OkObjectResult("Successs");

            return BadRequest("Fail TO Add");

        }
    }
}