using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Analysis; // for Analyser
using Lucene.Net.Documents; // for Document and Field
using Lucene.Net.Index; //for Index Writer
using Lucene.Net.Store; //for Directory
using Lucene.Net.Search; // for IndexSearcher
using Lucene.Net.QueryParsers;  // for QueryParser
using static System.Console;
using System.IO;

namespace EduQuiz_Question_Answering_System
{
    public class LuceneInteractive
    {
        Lucene.Net.Store.Directory luceneIndexDirectory;
        Lucene.Net.Index.IndexWriter writer;
        Lucene.Net.Analysis.Analyzer analyzer;
        MultiFieldQueryParser multiFieldQueryParser;
        IndexSearcher searcher;

        List<Item> collection;
        List<string> saveQuery = new List<string>();
        const Lucene.Net.Util.Version VERSION = Lucene.Net.Util.Version.LUCENE_30;
        const string TEXT_FN = "Text";
        const string TITLE_FN = "Title";
        const string QUERY_FN = "Query";
        const string ID_FN_PASSAGEID = "Passage_ID";

        const string ID_FN_QUERYID = "Query_ID";

        string[] FIELDS = { TEXT_FN, TITLE_FN, QUERY_FN };

        string searchQuery = "";

        TopDocs searchResultDocs = null;

        Similarity newSimilarity;

        public LuceneInteractive()
        {

        }

        public LuceneInteractive(string jsonFilePath, string indexPath)
        {
            luceneIndexDirectory = null;
            writer = null;
            analyzer = new Lucene.Net.Analysis.Snowball.SnowballAnalyzer(VERSION, "English", Utils.STOPWORDS);
            // parser = new QueryParser(VERSION, TEXT_FN, analyzer);
            // string[] fields = { TEXT_FN, TITLE_FN, QUERY_FN };
            multiFieldQueryParser = new MultiFieldQueryParser(VERSION, FIELDS, analyzer);

            newSimilarity = new NewSimilarity();


            CreateIndex(indexPath); //create index

            collection = Utils.getCollection(jsonFilePath); //retrieve all documents from Json file

            foreach (Item item in collection)
            {
                foreach (Passage passage in item.Passages)
                {

                    string url = passage.url;
                    if (url[url.Length - 1] == '/') // situation like https://www.slimvapepen.com/rebuildable-atomizer-rba/ , need to remove '/'
                    {
                        url = url.Remove(url.Length - 1);
                    }
                    int indexOfForwardSlash = url.LastIndexOf('/'); //https://en.wikipedia.org/wiki/Reserve_Bank_of_Australia
                    string title = url.Substring(indexOfForwardSlash + 1); //title 


                    IndexProcess(passage.passage_text, title, item.query, passage.passage_ID.ToString(), item.query_id.ToString());
                }
            }

            CleanUpIndexer();
        }

        /// <summary>
        /// Creates the index at a given path
        /// </summary>
        /// <param name="indexPath">The pathname to create the index</param>
        public void CreateIndex(string indexPath)
        {
            luceneIndexDirectory = Lucene.Net.Store.FSDirectory.Open(indexPath);
            IndexWriter.MaxFieldLength mfl = new IndexWriter.MaxFieldLength(IndexWriter.DEFAULT_MAX_FIELD_LENGTH);
            writer = new Lucene.Net.Index.IndexWriter(luceneIndexDirectory, analyzer, true, mfl);
            writer.SetSimilarity(newSimilarity);
        }


        /// <summary>
        /// Indexes 
        /// </summary>
        // / <param name="text">The text to index</param>
        // / <param name="passage_ID">The passage_ID to index</param>
        public void IndexProcess(string passage_text, string title, string query, string passage_ID, string query_ID)
        {
            // Separate fields for passage_text, title and query. Each field has its own boost. (passage_text.boost=3,title.boost=5,query.boost=8)
            Lucene.Net.Documents.Field text_field = new Field(TEXT_FN, passage_text, Field.Store.YES, Field.Index.ANALYZED_NO_NORMS, Field.TermVector.NO);
            Lucene.Net.Documents.Field title_field = new Field(TITLE_FN, title, Field.Store.YES, Field.Index.ANALYZED_NO_NORMS, Field.TermVector.NO);
            Lucene.Net.Documents.Field query_field = new Field(QUERY_FN, query, Field.Store.YES, Field.Index.ANALYZED_NO_NORMS, Field.TermVector.NO);
            Lucene.Net.Documents.Field passage_ID_field = new Field(ID_FN_PASSAGEID, passage_ID, Field.Store.YES, Field.Index.ANALYZED_NO_NORMS, Field.TermVector.NO);
            Lucene.Net.Documents.Field query_ID_field = new Field(ID_FN_QUERYID, query_ID, Field.Store.YES, Field.Index.ANALYZED_NO_NORMS, Field.TermVector.NO);

            //add boost
            text_field.Boost = 3;
            title_field.Boost = 5;
            query_field.Boost = 8;



            Lucene.Net.Documents.Document doc = new Document();
            doc.Add(text_field);
            doc.Add(title_field);
            doc.Add(query_field);
            doc.Add(passage_ID_field);
            doc.Add(query_ID_field);

            writer.AddDocument(doc);
        }


        /// <summary>
        /// Flushes the buffer and closes the index
        /// </summary>
        public void CleanUpIndexer()
        {
            writer.Optimize();
            writer.Flush(true, true, true);
            writer.Dispose();
        }

        /// <summary>
        /// Creates the searcher object
        /// </summary>
        public void CreateSearcher()
        {
            searcher = new IndexSearcher(luceneIndexDirectory);
            searcher.Similarity = newSimilarity;
        }


        /// <summary>
        /// Searches the index for the querytext
        /// </summary>
        /// <param name="querytext">The text to search the index</param>
        public TopDocs SearchText(string querytext, int searchNumer)
        {

            querytext = querytext.ToLower();

            /* 
                when creating Simulation results(BaselineResults)
                when parsing the query = "what is a fracture]",
                shows the error "Cannot parse 'what is a fracture]':Lexical error..."
            */
            querytext = QueryParser.Escape(querytext); //escape the double quote and other special characters

            // Query query = parser.Parse(querytext);
            // Query query = MultiFieldQueryParser.Parse(VERSION, querytext, FIELDS, analyzer);
            Query query=multiFieldQueryParser.Parse(querytext);


            TopDocs results = searcher.Search(query, searchNumer);

            return results;
        }


        /// <summary>
        /// get Lucene.Query based on query text
        /// </summary>
        /// <param name="querytext">The text to search the index</param>
        public Query GetQueryBasedOnQueryText(string querytext)
        {
            querytext = querytext.ToLower();
            Query query = multiFieldQueryParser.Parse(querytext);

            return query;

        }



        /// <summary>
        /// Get a ranked list of results
        /// </summary>
        /// <param name="query">A set of results</param>
        public List<string> GetResults(string query)
        {
            searchQuery = query;

            CreateSearcher();
            TopDocs results = SearchText(query, 100);

            searchResultDocs = results;




            List<string> resultList = new List<string>();
            int resultNum = 0;
            foreach (ScoreDoc scoreDoc in results.ScoreDocs)
            {
                // if (resultNum >= 10) { break; }
                resultNum += 1;
                Lucene.Net.Documents.Document doc = searcher.Doc(scoreDoc.Doc);
                string passage_text=doc.Get(TEXT_FN).ToString();
                string title=doc.Get(TITLE_FN).ToString();

                string myFieldValue = title+" "+passage_text;
                // resultsStr += "Rank " + rank + " text " + myFieldValue + "\n";
                resultList.Add(myFieldValue);
            }

            CleanUpSearcher();

            return resultList;
        }



        public void SaveResult(string filePath)
        {

            string query = searchQuery;

            CreateSearcher();
            StreamWriter sw = new StreamWriter(filePath, true, Encoding.Default);//实例化StreamWriter
            TopDocs results = searchResultDocs;
            // TopDocs results = SearchText(query, searcher.MaxDoc);
            saveQuery.Add(query);
            int idx = saveQuery.IndexOf(query) + 1;
            int length = Math.Abs(idx).ToString().Length;
            string queryId = "";
            if (length == 1)
            {
                queryId = "00" + idx.ToString();
            }
            if (length == 2)
            {
                queryId = "0" + idx.ToString();
            }
            if (length == 3)
            {
                queryId = idx.ToString();
            }


            int rank = 0;
            foreach (ScoreDoc scoreDoc in results.ScoreDocs)
            {
                rank += 1;

                Lucene.Net.Documents.Document doc = searcher.Doc(scoreDoc.Doc);
                string myFieldValue = doc.Get(TEXT_FN).ToString();
                string passage_ID = doc.Get(ID_FN_PASSAGEID).ToString();
                // string query_ID = doc.Get(ID_FN_QUERYID).ToString();
                // resultsStr += "Rank " + rank + " text " + myFieldValue + "\n";
                //string save = query + "\t" + "Q0" + "\t" + scoreDoc.Score + "\t" + "n9916113_our team";

                sw.WriteLine(queryId + "\t" + "Q0" + "\t" + passage_ID + "\t" + rank + "\t" + scoreDoc.Score + "\t" + "n9916113_n10290320_n10381112_Climbers");
                // sw.WriteLine(query_ID + "\t" + "Q0" + "\t" + passage_ID + "\t" + rank + "\t" + scoreDoc.Score + "\t" + "n9916113_n10290320_n10381112_Climbers"); //for simulation

                //resultList.Add(save);
            }
            sw.Close();
            CleanUpSearcher();
        }

        public void SaveResultForSimulation(string query, string filePath, string query_ID)
        {

            CreateSearcher();
            StreamWriter sw = new StreamWriter(filePath, true, Encoding.Default); //instantiate StreamWriter
            TopDocs results = SearchText(query, 10);

            int rank = 0;
            foreach (ScoreDoc scoreDoc in results.ScoreDocs)
            {
                rank += 1;

                Lucene.Net.Documents.Document doc = searcher.Doc(scoreDoc.Doc);
                string myFieldValue = doc.Get(TEXT_FN).ToString();
                string passage_ID = doc.Get(ID_FN_PASSAGEID).ToString();

                sw.WriteLine(query_ID + "\t" + "Q0" + "\t" + passage_ID + "\t" + rank + "\t" + scoreDoc.Score + "\t" + "n9916113_n10290320_n10381112_Climbers"); //for simulation

            }
            sw.Close();
            CleanUpSearcher();
        }

        /// <summary>
        /// Closes the index after searching
        /// </summary>
        public void CleanUpSearcher()
        {
            searcher.Dispose();
        }
    }
}
