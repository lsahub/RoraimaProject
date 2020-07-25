using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoraimaProject.Models;
using RoraimaProject.Responce;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RoraimaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        /// <summary>
        /// тестовый контроллер, чтобы проверять доступность апи и базы
        /// </summary>
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                var res = ResumeVisibilityModel.List().Select(x => new
                {
                    ResumeVisibilityId = x.ResumeVisibilityId,
                    Title = x.Title
                });
                return new JsonResult(res);
            }
            catch(Exception ex)
            {
                return new JsonResult(ex.Message + Environment.NewLine + DataAccess.ConnectionString);
            }
        }
    }
}
