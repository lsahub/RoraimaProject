using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoraimaProject.Responce
{
    public class ServiceResponce
    {
        public static string GetDefaultError(Exception ex)
        {
            try
            {
                var envMode = Environment.GetEnvironmentVariable("ENVMODE");
                if (!string.IsNullOrEmpty(envMode) && envMode.ToLower() == "debug")
                    return ex.Message;
            }
            catch(Exception e)
            {
                return e.Message;
            }
            return "Something went wrong";
        }
        public string Error { get; set; }
        public string Code { get; set; }
        public object Payload { get; set; }
    }
}
