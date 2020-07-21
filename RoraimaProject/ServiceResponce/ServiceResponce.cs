using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoraimaProject.Responce
{
    public class ServiceResponce
    {
        public static string GetDefaultError()
        {
            return "Something went wrong";
        }
        public string Error { get; set; }
        public string Code { get; set; }
        public object Payload { get; set; }
    }
}
