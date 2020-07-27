using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RoraimaLibrary.Models;
using RoraimaProject.Responce;
using System;
using System.Collections.Generic;

namespace RoraimaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : BaseController
    {
        [HttpGet]
        [EnableCors("CorsPolicy")]
        public JsonResult Find(
            [FromQuery(Name = "text")] string text,
            [FromQuery(Name = "page")] int page
        )
        {
            try
            {
                var searchResult = SearchableModel.FindResume(text, page, out long totalCount);
                var res = new List<object>();
                return new JsonResult(new ServiceResponce() { Code = "200", Error = null, 
                    Payload = new 
                    {
                        totalCount = totalCount,
                        searchResult = searchResult
                    }
                });
            }
            catch (Exception e)
            {
                return new JsonResult(new ServiceResponce()
                {
                    Code = "4A48A9B75632",
                    Error = ServiceResponce.GetDefaultError(e),
                    Payload = null
                });
            } 
        }

    }
}
