using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RoraimaProject.Models;
using RoraimaProject.Responce;

namespace RoraimaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : BaseController
    {
        [HttpGet]
        [EnableCors("CorsPolicy")]
        public JsonResult Find([FromQuery(Name = "text")] string text)
        {

            var searchResultList = SearchIndexModel.Find(text);
            var res = new List<object>();
            foreach (var result in searchResultList)
            {
                if (result == null)
                    continue;
                var o = new
                {
                    title = result.GetShortTitle(),
                    text = result.GetShortText()
                };
                res.Add(o);
            }
            

            return new JsonResult(new ServiceResponce() { Code = "200", Error = null, Payload = res });
        }

    }
}
