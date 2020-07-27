using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RoraimaLibrary.Models;
using RoraimaProject.Responce;
using System;
using System.Linq;

namespace RoraimaProject.Controllers
{
    [Route("api/[controller]/list")]
    [ApiController]
    public class ResumeVisibilityController : BaseController
    {
        [HttpGet]
        [EnableCors("CorsPolicy")]
        public JsonResult Get()
        {
            try
            {
                var res = ResumeVisibilityModel.List().Select(x => new {
                    ResumeVisibilityId = x.ResumeVisibilityId,
                    Title = x.Title
                });
                return new JsonResult(new ServiceResponce() { Code = "200", Error = null, Payload = res });
            }
            catch (Exception e)
            {
                return new JsonResult(new ServiceResponce()
                {
                    Code = "BFC5BA828AA7",
                    Error = ServiceResponce.GetDefaultError(e),
                    Payload = null
                });
            } 
        }
         
    }
}
