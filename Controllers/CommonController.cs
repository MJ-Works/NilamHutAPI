using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NilamHutAPI.Services;
using NilamHutAPI.Models;
using Microsoft.AspNetCore.Authorization;
using NilamHutAPI.Helpers;
using NilamHutAPI.ViewModels.Shared;
using NilamHutAPI.ViewModels.FrontEnd;

namespace NilamHutAPI.Controllers
{

    //[Authorize(Policy = "ApiUser")]
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
                return BadRequest(Errors.AddErrorToModelState("Message", "city is linked with product or user or Something Went Wrong.", ModelState));

            return Ok();

        }

        [HttpDelete("DeleteCity/{id}")]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
             if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _commonService.DeleteCity(id);

            if (!result)
                return BadRequest(Errors.AddErrorToModelState("Message", "City is link with product or user or Something Went Wrong.", ModelState));

            return Ok();
        }


        [HttpGet("AllCategory")]
        public async Task<IActionResult> AllCategory()
        {
            var result = await _commonService.AllCategory();
            return new OkObjectResult(result);
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory([FromBody] CategoryViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _commonService.AddCategory(model);

            if (!result)
                return BadRequest(Errors.AddErrorToModelState("Message", "Something Went Wrong.", ModelState));

            return new OkObjectResult(new { Message = "Category Added." });
        }

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
             if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _commonService.DeleteCategory(id);

            if (!result)
                return BadRequest(Errors.AddErrorToModelState("Message", "Category is linked with product or Something Went Wrong.", ModelState));

            return Ok();
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
                return BadRequest(Errors.AddErrorToModelState("Message", "Tag is linked to product or something Went Wrong.", ModelState));

            return new OkObjectResult(new { Message = "Tag Deleted." });
        }

        [HttpPost("GetSearchProducts")]

        public async Task<IActionResult> GetSearchProducts([FromBody] SearchViewModel model)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _commonService.AllSearchProduct(model);
            return new OkObjectResult(result);
        }

        [HttpGet("GetSoldHistory/{id}")]

        public async Task<IActionResult> GetSoldHistory(string id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _commonService.getSoldHistory(id);
            return new OkObjectResult(result);
        }

        [HttpGet("GetWinHistory/{id}")]

        public async Task<IActionResult> GetWinHistory(string id)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _commonService.getWinHistory(id);
            return new OkObjectResult(result);
        }

        [HttpPost("AddReport")]
        public async Task<IActionResult> AddReport([FromBody]ReportViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _commonService.AddReport(model);

            if (!result)
                return BadRequest(Errors.AddErrorToModelState("Message", "Something Went Wrong.", ModelState));

            return new OkObjectResult(new { Message = "Report Added." });

        }

        [HttpGet("AllReport")]
        public async Task<IActionResult> AllReport()
        {
            var result = await _commonService.AllReport();
            return new OkObjectResult(result);
        }

    }
}