using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoraimaProject.Helper
{
    public class LogHelper<T>
    {
        /// <summary>
        /// Максимольный размер параметров контроллера в json для сохранения в лог файл
        /// </summary>
        public static int MaxParametrLength = 4000;

        public static string SaveToLog(Exception e, string jsonFields, string methodName, ILogger<T> logger)
        {
            if (jsonFields.Length > MaxParametrLength)
                jsonFields = $"Out of range LogHelper.MaxParametrLength: {MaxParametrLength}";
            if (logger != null)
                logger.LogError(e, $"{methodName}. Fields:{jsonFields}");
            return jsonFields;
        }

    }



}
