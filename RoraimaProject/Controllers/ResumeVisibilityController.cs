using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RoraimaProject.Models;
using RoraimaProject.Responce;
using System.Linq;

namespace RoraimaProject.Controllers
{
    [Route("api/[controller]/list")]
    [ApiController]
    public class ResumeVisibilityController : ControllerBase
    {
        [HttpGet]
        [EnableCors("CorsPolicy")]
        public JsonResult Get()
        {
            var res = ResumeVisibilityModel.List().Select(x=> new {
                ResumeVisibilityId = x.ResumeVisibilityId,
                Title = x.Title
            });
            return new JsonResult(new ServiceResponce() { Code = "200", Error = null, Payload = res });
        }
         
    }
}
