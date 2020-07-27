using Nest;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RoraimaLibrary.Models
{
    public class ResumeExperienceModel
    {
        [Number]
        public int? ResumeExperienceId { get; set; }
        [Number]
        public int ResumeId { get; set; }
        [Date]
        public DateTime DateStart { get; set; }
        [Date]
        public DateTime? DateEnd { get; set; }
        [Boolean]
        public bool IsUntilNow { get; set; }
        [Text]
        public string PlaceOfWork { get; set; }
        [Text]
        public string Position { get; set; }
        [Text]
        public string Description { get; set; }

        public void Load(DataRow row)
        {
            ResumeExperienceId = (int)row["ResumeExperienceId"];
            ResumeId = (int)row["ResumeId"];
            DateStart = (DateTime)row["DateStart"];
            DateEnd = row["DateEnd"] as DateTime?;
            IsUntilNow = (bool)row["IsUntilNow"];
            Position = row["Position"] as string;
            Description = row["Description"] as string;
            PlaceOfWork = row["PlaceOfWork"] as string;
        }

        public static ResumeExperienceModel Load(int? resumeExperienceId)
        {
            ResumeExperienceModel res = null;
            var dt = DataAccess.GetDataTable("spuResumeExperienceLoad", new Hashtable()
            {
                { "ResumeExperienceId", resumeExperienceId }
            });

            if (dt.Rows.Count > 0)
            {
                res = new ResumeExperienceModel();
                res.Load(dt.Rows[0]);
            }
            return res;
        }

        public void Save(SqlTransaction transaction)
        {
            var dt = DataAccess.GetDataTable("spuResumeExperienceSave", new Hashtable()
            {
                { "ResumeExperienceId", ResumeExperienceId },
                { "ResumeId", ResumeId },
                { "DateStart", DateStart },
                { "DateEnd", DateEnd },
                { "IsUntilNow", IsUntilNow },
                { "PlaceOfWork", PlaceOfWork },
                { "Position", Position },
                { "Description", Description }
            }, transaction);
            if (dt.Rows.Count > 0)
                ResumeExperienceId = (int)dt.Rows[0]["ResumeExperienceId"];
        }

    }
}
