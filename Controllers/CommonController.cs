using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NilamHutAPI.Services;
using NilamHutAPI.Models;
using NilamHutAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using NilamHutAPI.Helpers;

namespace NilamHutAPI.Controllers
{

    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]")]
    public class CommonController : Controller
    {
        private readonly ICommonService _commonService;
        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [HttpGet("AllCity")]
        public async Task<IActionResult> AllCity()
        {
            var result = await _commonService.AllCity();
            return new OkObjectResult(result);
        }
        
        [HttpPost("AddCity")]
        public async Task<IActionResult> AddCity([FromBody] CityViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _commonService.AddCity(model);

            if (!result)
                return BadRequest(Errors.AddErrorToModelState("Message", "Something Went Wrong.", ModelState));

            return new OkObjectResult(new { Message = "City Added." });

        }


        [HttpGet("AllCountry")]
        public async Task<IActionResult> AllCountry()
        {
            var result = await _commonService.AllCountrty();
            return new OkObjectResult(result);
        }

        [HttpPost("AddCountry")]
        public async Task<IActionResult> AddCountry([FromBody] CountryViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _commonService.AddCountry(model);

            if (!result)
                return BadRequest(Errors.AddErrorToModelState("Message", "Something Went Wrong.", ModelState));

            return new OkObjectResult(new { Message = "Country Added." });
        }


        [HttpGet("AllTags")]
        public async Task<IActionResult> AllTags()
        {
            var result = await _commonService.AllTag();
            return new OkObjectResult(result);
        }

        [HttpGet("SingleTag/{id}")]
        public async Task<IActionResult> SingleTag(Guid id)
        {
            var result = await _commonService.getSingleTag(id);
            return new OkObjectResult(result);
        }


        [HttpPost("AddTag")]
        public async Task<IActionResult> AddTag([FromBody]TagViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _commonService.AddTag(model);

            if (!result)
                return BadRequest(Errors.AddErrorToModelState("Message", "Something Went Wrong.", ModelState));

            return new OkObjectResult(new { Message = "Tag Added." });

        }

        [HttpPut("EditTag/{id}")]
        public async Task<IActionResult> EditTag(Guid id, [FromBody] TagViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _commonService.EditTag(id, model);

            if (!result)
                return BadRequest(Errors.AddErrorToModelState("Message", "Something Went Wrong.", ModelState));

            return new OkObjectResult(new { Message = "Tag Updated." });
        }

        [HttpDelete("DeleteTag/{id}")]
        public async Task<IActionResult> DeleteTag(Guid id)
        {
            var result = await _commonService.DeleteTag(id);

            if (!result)
                return BadRequest(Errors.AddErrorToModelState("Message", "Something Went Wrong.", ModelState));

            return new OkObjectResult(new { Message = "Tag Deleted." });
        }


    }
}