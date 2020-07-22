using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RoraimaProject.Models
{
    public abstract class SearchableModel
    {
        /// <summary>
        /// Сохранения полей в индекс.
        /// После сохранения модели нужно вызывать SaveSearchIndex
        /// </summary>
        public abstract void SaveSearchIndex(SqlTransaction transaction);
    }
}
