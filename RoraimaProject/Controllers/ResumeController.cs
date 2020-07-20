using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RoraimaProject.Models;
using RoraimaProject.Responce;

namespace RoraimaProject.Controllers
{
    /// <summary>
    /// Helper 
    /// </summary>
    public class ResumeController : ControllerBase
    {
        ILogger<ResumeController> Logger = null;
        public ResumeController(ILogger<ResumeController> _logger)
        {
            Logger = _logger;
        }

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

                return new JsonResult(new ServiceResponce() { Code = "200", Error = null, Payload = resume.ResumeId });
            }
            catch (Exception e)
            {
                var fields = new Dictionary<string, object>();
                if (resume != null)
                {
                    fields = resume.GetType()
                         .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                              .ToDictionary(prop => prop.Name, prop => prop.GetValue(resume, null));
                }
                if (Logger != null)
                    Logger.LogError(e, "SaveResume", fields);
                return new JsonResult(new ServiceResponce() { Code = "E11191861A26" });
            }
        }
    }
}
