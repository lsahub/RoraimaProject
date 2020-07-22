using System;
using System.Collections;
using System.Collections.Generic;
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

    }
}
