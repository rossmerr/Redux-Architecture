using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using NHibernate;
using NHibernate.Search;
using NHibernate.Search.Backend;
using NHibernate.Search.Impl;

namespace ReduxArch.Data.Castle.ActiveRecord
{
    public class IndexHelper
    {
        /// <summary>
        /// Creates an index for all entities of a specified type
        /// </summary>
        /// <param name="rootIndexDirectory">The root directory where indexes will be stored under.</param>
        public static void CreateIndex<T>(string rootIndexDirectory)
        {
            Type type = typeof(T);

            var info = new DirectoryInfo(Path.Combine(rootIndexDirectory, type.Name));

            // Recursively delete the index and files in there
            if (info.Exists) info.Delete(true);

            // Now recreate the index
            FSDirectory dir = FSDirectory.GetDirectory(Path.Combine(rootIndexDirectory, type.Name), true);
            //Ioc.UrlProvider.MapPath(Path.Combine(rootIndexDirectory, type.Name)), true);

            try
            {
                var writer = new IndexWriter(dir, new StandardAnalyzer(), true);
                writer.Close();
            }
            finally
            {
                if (dir != null) dir.Close();
            }

            ISession session = ActiveRecordMediator.GetSessionFactoryHolder().CreateSession(type);
            IFullTextSession fullTextSession = NHibernate.Search.Search.CreateFullTextSession(session);
            foreach (T instance in ActiveRecordBase<T>.FindAll())
            {
                fullTextSession.Index(instance);
            }
        }

        public static IQuery SearchSimple<T>(string searchString)
        {
            ISession session = ActiveRecordMediator.GetSessionFactoryHolder().CreateSession(typeof(T));

            // Create a Full Text session
            IFullTextSession fullTextSession = NHibernate.Search.Search.CreateFullTextSession(session);

            // Build our Lucene query
            Query luceneQuery = ParseLuceneQuery(searchString);

            // Transform the Lucene query to an NHibernate query,
            // and limit the result set types to MyEntity
            IQuery query = fullTextSession.CreateFullTextQuery(luceneQuery);
            // List our results
            return query;
        }


        public static Lucene.Net.Search.Query ParseLuceneQuery(string searchTerms)
        {
            StringBuilder queryString = new StringBuilder();

            // Split the search string into keywords
            string[] words = searchTerms.Split(" ".ToCharArray());

            foreach (string keyword in words)
            {
                if (!String.IsNullOrEmpty(keyword))
                {
                    queryString.AppendFormat(" Title:{0}", keyword);
                }
            }

            QueryParser parser = new QueryParser(queryString.ToString(), new StandardAnalyzer());

            return parser.Parse(queryString.ToString());
        }
    }
}
