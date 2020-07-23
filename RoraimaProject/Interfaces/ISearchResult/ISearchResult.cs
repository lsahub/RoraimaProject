using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoraimaProject.Interfaces
{
    /// <summary>
    /// Класс реализующий данный интерфейс - может выдаваться в результатах поиска,
    /// если его данные в индексе. 
    /// см abstract class SearchableModel
    /// </summary>
    public interface ISearchResult
    {
        /// <summary>
        /// заголовок для вывода результата поиска
        /// </summary>
        public string GetShortTitle();
        /// <summary>
        /// Текст результата поиска
        /// </summary>
        public string GetShortText();
    }
}
