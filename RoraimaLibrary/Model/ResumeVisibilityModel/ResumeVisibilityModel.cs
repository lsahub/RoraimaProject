using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RoraimaLibrary.Models
{
    public class ResumeVisibilityModel
    {
        public int? ResumeVisibilityId;
        public string Title;

        public void Load(DataRow row)
        {
            ResumeVisibilityId = row["ResumeVisibilityId"] as int?;
            Title = row["Title"] as string;
        }

        public static List<ResumeVisibilityModel> List()
        {
            var res = new List<ResumeVisibilityModel>();
            var dt = DataAccess.GetDataTable("spuResumeVisibilityList", null);
            foreach (DataRow row in dt.Rows)
            {
                var resumeVisibilityModel = new ResumeVisibilityModel();
                resumeVisibilityModel.Load(row);
                res.Add(resumeVisibilityModel);
            }
            return res;
        }

    }
}
