using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RoraimaProject.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace RoraimaProject.Controllers
{
    public class BaseController : ControllerBase
    {
        public bool SaveToLog<T>(T model, Exception e, ILogger<ResumeController> logger)
        {
            try
            {
                var fields = new Dictionary<string, object>();
                if (model != null)
                {
                    fields = model.GetType()
                         .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                              .ToDictionary(prop => prop.Name, prop => prop.GetValue(model, null));
                }
                string jsonFields = JsonConvert.SerializeObject(fields);

                jsonFields = LogHelper<ResumeController>.SaveToLog(e, jsonFields, "SaveResumeError", logger);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
