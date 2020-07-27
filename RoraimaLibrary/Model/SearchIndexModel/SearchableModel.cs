using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RoraimaLibrary.Models
{
    public abstract class SearchableModel
    {
        private static Uri[] Uris = new[] { new Uri("http://localhost:9200") };
        private static SniffingConnectionPool ConnectionPool;
        private static ConnectionSettings Settings;
        public static ElasticClient Client;
        private static int PageSize = 10;

        static SearchableModel()
        {
            ConnectionPool = new SniffingConnectionPool(Uris);
            Settings = new ConnectionSettings(ConnectionPool)
                .DefaultIndex("resume");

            Client = new ElasticClient(Settings);
        }

        /// <summary>
        /// Сохранения полей в индекс.
        /// После сохранения модели нужно вызывать SaveSearchIndex
        /// </summary>
        public abstract void SaveSearchIndex(SqlTransaction transaction);

        public static IReadOnlyCollection<ResumeModel> FindResume(string query, int page)
        {
            var start = (page - 1) * 10;
            var end = (page) * 10;

            Client.Search<ResumeModel>(s => s.Query(q => q.QueryString(d => d.Query(query))));

            var searchResponse = Client.Search<ResumeModel>(x => x
                .From(start)
                .Size(PageSize)                
                .Query(q => q
                    .MultiMatch(m => m
                        .Fields(fs => fs)
                        .Operator(Operator.And)
                        .Query(query)
                    ) 
                )
            );

            //foreach (var fieldValues in searchResponse.Fields)
            //{
            //    var resumeId = fieldValues.ValueOf<ResumeModel, int?>(p => p.ResumeId);
            //}

            return searchResponse.Documents; 
        }

    }
}
