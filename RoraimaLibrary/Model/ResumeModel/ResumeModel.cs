using RoraimaLibrary.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace RoraimaLibrary.Models
{
    public class ResumeModel: SearchableModel, ISearchResult
    {
        /// <summary>
        /// Identity Increment primary key
        /// </summary>
        public int? ResumeId { get; set; }
        /// <summary>
        /// Resume Visibility
        /// </summary>
        public int ResumeVisibilityId { get; set; }
        /// <summary>
        /// Title resume, not null
        /// </summary>
        public string ResumeTitle { get; set; }
        /// <summary>
        /// Last name, not null
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// First name, not null
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Middle name, nullable
        /// </summary>
        public string MiddleName { get; set; }

        public List<ResumeExperienceModel> ResumeExperienceList { get; set; } = new List<ResumeExperienceModel>();

        public void Load(DataRow row, DataRow[] rowsResumeExperience) 
        {
            ResumeId = (int)row["ResumeId"];
            ResumeVisibilityId = (int)row["ResumeVisibilityId"];
            ResumeTitle = (string)row["ResumeTitle"];
            LastName = (string)row["LastName"];
            FirstName = (string)row["FirstName"];
            MiddleName = row["MiddleName"] as string;

            if (rowsResumeExperience != null)
            {
                foreach (DataRow resumeExperience in rowsResumeExperience)
                {
                    var resumeExperienceModel = new ResumeExperienceModel();
                    resumeExperienceModel.Load(resumeExperience);
                    ResumeExperienceList.Add(resumeExperienceModel);
                }
            }
        }

        public static ResumeModel Load(int? resumeId)
        {
            ResumeModel res = null;
            var ds = DataAccess.GetDataSet("spuResumeLoad", new Hashtable()
            {
                { "ResumeId", resumeId }
            });

            if (ds.Tables[0].Rows.Count > 0)
            {
                res = new ResumeModel();
                var row = ds.Tables[0].Rows[0];
                var rowsResumeExperience = ds.Tables[1].Select();
                res.Load(row, rowsResumeExperience);
            }

            return res;
        }

        private void SaveResume(SqlTransaction transaction) 
        {
            var dt = DataAccess.GetDataTable("spuResumeSave", new Hashtable()
            {
                { "ResumeId", ResumeId },
                { "ResumeVisibilityId", ResumeVisibilityId },
                { "ResumeTitle", ResumeTitle },
                { "LastName", LastName },
                { "FirstName", FirstName },
                { "MiddleName", MiddleName }
            }, transaction);

            ResumeId = (int)dt.Rows[0]["ResumeId"];
        }

        public void Save(SqlTransaction transaction)
        {
            SaveResume(transaction);
            if (ResumeExperienceList != null)
            {
                foreach (var resumeExperience in ResumeExperienceList)
                {
                    resumeExperience.ResumeId = ResumeId.Value;
                    resumeExperience.Save(transaction);
                }
            }
            SaveSearchIndex(transaction);
        }

        public override void SaveSearchIndex(SqlTransaction transaction)
        {
            (new SearchIndexModel()
            {
                ObjectId = ResumeId.Value,
                ObjectName = "ResumeModel",
                FieldName = "Желаемая должность",
                FieldValue = ResumeTitle
            })
            .Delete(transaction)
            .Save(transaction);

            (new SearchIndexModel()
            {
                ObjectId = ResumeId.Value,
                ObjectName = "ResumeModel",
                FieldName = "Фамилия",
                FieldValue = LastName
            })
            .Delete(transaction)
            .Save(transaction);

            (new SearchIndexModel()
            {
                ObjectId = ResumeId.Value,
                ObjectName = "ResumeModel",
                FieldName = "Имя",
                FieldValue = FirstName
            })
            .Delete(transaction)
            .Save(transaction);

            (new SearchIndexModel()
            {
                ObjectId = ResumeId.Value,
                ObjectName = "ResumeModel",
                FieldName = "Отчество",
                FieldValue = MiddleName
            })
            .Delete(transaction)
            .Save(transaction);

            var resumeExperience = "";
            foreach (var experience in ResumeExperienceList)
            {
                resumeExperience += experience.PlaceOfWork + Environment.NewLine;
                resumeExperience += experience.Position + Environment.NewLine;
                resumeExperience += experience.Description + Environment.NewLine;                
            }

            (new SearchIndexModel()
            {
                ObjectId = ResumeId.Value,
                ObjectName = "ResumeModel",
                FieldName = "Опыт работы",
                FieldValue = resumeExperience
            })
            .Delete(transaction)
            .Save(transaction);

        }

        public string GetShortTitle()
        {
            return ResumeTitle;
        }

        public string GetShortText()
        {
            if (ResumeExperienceList.Count == 0)
                return null;

            var resumeExperienceLast = ResumeExperienceList.Last();
            return resumeExperienceLast.Description;
        }
    }
}
