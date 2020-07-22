using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RoraimaProject.Helper;
using RoraimaProject.Models;
using RoraimaProject.Responce; 

namespace RoraimaProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : BaseController
    {
        ILogger<ResumeController> Logger = null;
        public ResumeController(ILogger<ResumeController> _logger)
        {
            Logger = _logger;
        }

        [HttpPost]
        [EnableCors("CorsPolicy")]
        [Produces("application/json")]
        public JsonResult SaveResume(ResumeModel resume)
        {
            try
            {
                using (var conn = DataAccess.CreateConnection())
                using (var transaction = DataAccess.CreateTransaction(conn))
                {
                    resume.Save(transaction);
                    transaction.Commit();
                }

                return new JsonResult(new ServiceResponce() { Code = "200", Error = null, Payload = resume });
            }
            catch (Exception e)
            {
                var saved = SaveToLog<ResumeModel>(resume, e, Logger);
                return new JsonResult(new ServiceResponce()
                {
                    Code = "E11191861A26",
                    Error = ServiceResponce.GetDefaultError(),
                    Payload = saved
                });
            }
        }


    }
}
