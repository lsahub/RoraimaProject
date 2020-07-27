using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoraimaProject.Controllers;
using RoraimaLibrary.Models;
using RoraimaProject.Responce;
using Serilog;
using System;
using System.Collections.Generic;


namespace RoraimaProjectTests
{
    [TestClass]
    public class ElasticSearchTest
    {
 
        [TestMethod]
        public void ResumeControllerPostTest()
        {
            var res = SearchableModel.FindResume("MiddleName", 1);
            Assert.AreEqual(res.Count > 0, true);
        } 
    }
}  