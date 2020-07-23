using RoraimaProject.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RoraimaProject.Models
{
    public class SearchIndexModel
    {
        /// <summary>
        /// ИД модели
        /// </summary>
        public int ObjectId;
        /// <summary>
        /// Название модели
        /// </summary>
        public string ObjectName;
        /// <summary>
        /// Название поля
        /// </summary>
        public string FieldName;
        /// <summary>
        /// Значение поля модели по которуму будет идти поиск
        /// </summary>
        public string FieldValue;
        /// <summary>
        /// чтобы не дублировать значения индекса их нужно сначала удалять
        /// </summary>
        public SearchIndexModel Delete(SqlTransaction transaction) 
        {
            DataAccess.ExecuteNonQuery("spuSearchIndexDelete", new Hashtable()
            {
                { "ObjectId", ObjectId },
                { "ObjectName", ObjectName },
                { "FieldName", FieldName }
            }, transaction);
            return this;
        }
        /// <summary>
        /// Добавление новых значений в индекс, перед добавлением удалять все данные по имени поля
        /// Имя поля в объекте д.б. уникально.
        /// Для поля-списка удаляются все данные по именб и потом все добавляются
        /// </summary>
        public void Save(SqlTransaction transaction) 
        {
            DataAccess.GetDataTable("spuSearchIndexSave", new Hashtable()
            {
                { "ObjectId", ObjectId },
                { "ObjectName", ObjectName },
                { "FieldName", FieldName },
                { "FieldValue", FieldValue }
            }, transaction);
        }


        public static List<ISearchResult> Find(string text)
        {
            var res = new List<ISearchResult>();

            var dt = DataAccess.GetDataTable("spuSearchIndexFind", new Hashtable()
            {
                { "text", text }
            });

            foreach (DataRow row in dt.Rows)
            {
                var searchIndexModel = new SearchIndexModel();
                searchIndexModel.Load(row);
                var searchResult = GetSearchResult(searchIndexModel);
                if (searchResult != null)
                    res.Add(searchResult);
            }

            return res;
        }

        private void Load(DataRow row)
        {
            ObjectId = (int)row["ObjectId"];
            ObjectName = row["ObjectName"] as string;
            FieldName = row["FieldName"] as string;
            FieldValue = row["FieldValue"] as string;
        }

        private static ISearchResult GetSearchResult(SearchIndexModel searchIndexModel)
        {
            switch (searchIndexModel.ObjectName)
            {
                case "ResumeModel":
                    {
                        var resume = ResumeModel.Load(searchIndexModel.ObjectId);
                        if (!resume.ResumeId.HasValue)
                            return null;
                        return resume;
                    }
                default:
                    return null;
            }
        }

    }
}
