using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RoraimaLibrary.Models;
using RoraimaProject.Responce;
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
            var searchResult = SearchableModel.FindResume(text, page);
            var res = new List<object>();

            return new JsonResult(new ServiceResponce() { Code = "200", Error = null, Payload = searchResult });
        }

    }
}
