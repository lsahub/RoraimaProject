using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoraimaProject.Controllers;
using RoraimaProject.Models;
using RoraimaProject.Responce;
using Serilog;
using System;
using System.Collections.Generic;


namespace RoraimaProjectTests
{
    [TestClass]
    public class EmployeeUnitTest
    {
        #region ResumeControllerPostTest
        private static string PathToTestLog = @"C:\Logs\Log.txt";
        [TestMethod]
        public void ResumeControllerPostTest()
        {
            ILogger<ResumeController> resumeLogger = GetResumeLogger();
            resumeLogger.LogInformation("ResumeControllerPostTest Start");

            ResumeModel resumeToSave;
            ServiceResponce serviceResponce;
            SaveResume(resumeLogger, out resumeToSave, out serviceResponce);
            ServiceResponceTest(serviceResponce);

            var resumeId = (serviceResponce.Payload as ResumeModel).ResumeId;
            var resumeFromDb = ResumeModel.Load(resumeId);

            ResumeFromDbTest(resumeToSave, resumeFromDb);
            ResumeExperience0Test(resumeToSave, resumeFromDb);
            ResumeExperience1Test(resumeToSave, resumeFromDb);

            resumeLogger.LogInformation("ResumeControllerPostTest End");
        }

        private static void ServiceResponceTest(ServiceResponce serviceResponce)
        {
            Assert.AreEqual(serviceResponce.Code, "200");
            Assert.AreEqual(serviceResponce.Payload is ResumeModel, true);
            Assert.AreEqual(((serviceResponce.Payload as ResumeModel).ResumeId as int?) > 0, true);
        }

        private static void SaveResume(ILogger<ResumeController> resumeLogger, out ResumeModel resumeToSave, out ServiceResponce serviceResponce)
        {
            var controller = new ResumeController(resumeLogger);
            resumeToSave = GetResume();
            var json = controller.SaveResume(resumeToSave);
            serviceResponce = (ServiceResponce)(json.Value);
        }

        private static void ResumeFromDbTest(ResumeModel resumeToSave, ResumeModel resumeFromDb)
        {
            Assert.AreEqual(resumeFromDb.ResumeId > 0, true);
            Assert.AreEqual(resumeFromDb.ResumeExperienceList.Count == 2, true);

            Assert.AreEqual(resumeFromDb.ResumeId == resumeToSave.ResumeId, true);
            Assert.AreEqual(resumeFromDb.LastName == resumeToSave.LastName, true);
            Assert.AreEqual(resumeFromDb.FirstName == resumeToSave.FirstName, true);
            Assert.AreEqual(resumeFromDb.MiddleName == resumeToSave.MiddleName, true);
            Assert.AreEqual(resumeFromDb.ResumeTitle == resumeToSave.ResumeTitle, true);
            Assert.AreEqual(resumeFromDb.ResumeVisibilityId == resumeToSave.ResumeVisibilityId, true);
        }

        private static void ResumeExperience0Test(ResumeModel resumeToSave, ResumeModel resumeFromDb)
        {
            Assert.AreEqual(resumeFromDb.ResumeExperienceList[0].ResumeId == resumeToSave.ResumeId, true);
            Assert.AreEqual(resumeFromDb.ResumeExperienceList[0].ResumeExperienceId == resumeToSave.ResumeExperienceList[0].ResumeExperienceId, true);
            Assert.AreEqual(resumeFromDb.ResumeExperienceList[0].ResumeId == resumeToSave.ResumeExperienceList[0].ResumeId, true);
            Assert.AreEqual(resumeFromDb.ResumeExperienceList[0].DateStart == resumeToSave.ResumeExperienceList[0].DateStart, true);
            Assert.AreEqual(resumeFromDb.ResumeExperienceList[0].DateEnd == resumeToSave.ResumeExperienceList[0].DateEnd, true);
            Assert.AreEqual(resumeFromDb.ResumeExperienceList[0].Description == resumeToSave.ResumeExperienceList[0].Description, true);
            Assert.AreEqual(resumeFromDb.ResumeExperienceList[0].IsUntilNow == resumeToSave.ResumeExperienceList[0].IsUntilNow, true);
            Assert.AreEqual(resumeFromDb.ResumeExperienceList[0].Position == resumeToSave.ResumeExperienceList[0].Position, true);
            Assert.AreEqual(resumeFromDb.ResumeExperienceList[0].PlaceOfWork == resumeToSave.ResumeExperienceList[0].PlaceOfWork, true);
        }

        private static void ResumeExperience1Test(ResumeModel resumeToSave, ResumeModel resumeFromDb)
        {
            Assert.AreEqual(resumeFromDb.ResumeExperienceList[1].ResumeId == resumeToSave.ResumeId, true);
            Assert.AreEqual(resumeFromDb.ResumeExperienceList[1].ResumeExperienceId == resumeToSave.ResumeExperienceList[1].ResumeExperienceId, true);
            Assert.AreEqual(resumeFromDb.ResumeExperienceList[1].ResumeId == resumeToSave.ResumeExperienceList[1].ResumeId, true);
            Assert.AreEqual(resumeFromDb.ResumeExperienceList[1].DateStart == resumeToSave.ResumeExperienceList[1].DateStart, true);
            Assert.AreEqual(resumeFromDb.ResumeExperienceList[1].DateEnd == resumeToSave.ResumeExperienceList[1].DateEnd, true);
            Assert.AreEqual(resumeFromDb.ResumeExperienceList[1].Description == resumeToSave.ResumeExperienceList[1].Description, true);
            Assert.AreEqual(resumeFromDb.ResumeExperienceList[1].IsUntilNow == resumeToSave.ResumeExperienceList[1].IsUntilNow, true);
            Assert.AreEqual(resumeFromDb.ResumeExperienceList[1].Position == resumeToSave.ResumeExperienceList[1].Position, true);
            Assert.AreEqual(resumeFromDb.ResumeExperienceList[1].PlaceOfWork == resumeToSave.ResumeExperienceList[1].PlaceOfWork, true);
        }

        private static ResumeModel GetResume()
        {
            var date = DateTime.Now;
            date = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Kind);

            return new ResumeModel()
            {
                ResumeId = null,
                ResumeTitle = "ResumeTitle",
                ResumeVisibilityId = 1,
                LastName = "LastName",
                FirstName = "FirstName",
                MiddleName = "MiddleName",
                ResumeExperienceList = new List<ResumeExperienceModel>()
                {
                    new ResumeExperienceModel()
                    {
                        DateStart = date.AddYears(-3),
                        DateEnd = date.AddYears(-2),
                        Position = "React JS developer",
                        Description = "Description",
                        PlaceOfWork = "PlaceOfWork"
                    },
                    new ResumeExperienceModel()
                    {
                        DateStart = date.AddYears(-2),
                        IsUntilNow = true,
                        Position = "FullStack developer",
                        Description = "Description",
                        PlaceOfWork = "PlaceOfWork"
                    },
                }
            };
        }

        private static ILogger<ResumeController> GetResumeLogger()
        {
            var loggerFactory = GetLoggerFactor();
            var resumeLogger = loggerFactory.CreateLogger<ResumeController>();
            return resumeLogger;
        }

        private static ILoggerFactory GetLoggerFactor()
        {
            var serilog = new LoggerConfiguration()
                        .MinimumLevel.Verbose()
                        .WriteTo
                        .RollingFile(PathToTestLog)
                        .CreateLogger();

            var loggerFactory = new LoggerFactory()
                .AddSerilog(serilog);
            return loggerFactory;
        }

        #endregion
    }
}  