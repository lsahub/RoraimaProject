using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoraimaProject.Controllers;
using RoraimaProject.Models;
using RoraimaProject.Responce;
using System.Net.Http;


namespace RoraimaProjectTests
{
    [TestClass]
    public class EmployeeUnitTest
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ResumeControllerPostTest()
        {
            var controller = new ResumeController(null);
            var json = controller.SaveResume(new ResumeModel()
            {
                ResumeId = null,
                ResumeTitle = "ResumeTitle",
                ResumeVisibilityId = 1,
                LastName = "LastName",
                FirstName = "FirstName",
                MiddleName = "MiddleName",
            });
            var serviceResponce = (ServiceResponce)(json.Value);

            Assert.AreEqual(serviceResponce.Code, "200");
            Assert.AreEqual(serviceResponce.Payload is int, true);
            Assert.AreEqual((serviceResponce.Payload as int?) > 0, true);

            var resumeId = (serviceResponce.Payload as int?);
            var resumeModel = ResumeModel.Load(resumeId);
            Assert.AreEqual(resumeModel.ResumeId > 0, true);

        }
    }  
}  