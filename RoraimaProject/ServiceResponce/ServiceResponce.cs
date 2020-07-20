using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoraimaProject.Responce
{
    public class ServiceResponce
    {
        public string Error { get; set; } = "Something went wrong";
        public string Code { get; set; }
        public object Payload { get; set; }
    }
}
