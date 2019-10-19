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
        QueryParser parser;
        IndexSearcher searcher;

        List<Item> collection;
        List<string> saveQuuery = new List<string>();
        const Lucene.Net.Util.Version VERSION = Lucene.Net.Util.Version.LUCENE_30;
        const string TEXT_FN = "Text";
        const string ID_FN_PASSAGEID = "Passage_ID";

        const string ID_FN_QUERYID = "Query_ID";

        public LuceneInteractive()
        {

        }

        public LuceneInteractive(string jsonFilePath, string indexPath)
        {
            luceneIndexDirectory = null;
            writer = null;
            analyzer = new Lucene.Net.Analysis.SimpleAnalyzer();
            parser = new QueryParser(VERSION, TEXT_FN, analyzer);


            CreateIndex(indexPath); //create index

            collection = Utils.getCollection(jsonFilePath); //retrieve all documents from Json file

            foreach (Item item in collection)
            {
                foreach (Passage passage in item.Passages)
                {
                    string indexText = passage.url + " " + passage.passage_text; //Baseline System requirement--"all the text and url is indexed as a single field"
                    IndexTextAndPassageID(indexText, passage.passage_ID.ToString(), item.query_id.ToString());
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
        }


        /// <summary>
        /// Indexes a given string into the index, and passage_ID into index
        /// </summary>
        /// <param name="text">The text to index</param>
        /// <param name="passage_ID">The passage_ID to index</param>
        public void IndexTextAndPassageID(string text, string passage_ID, string query_ID)
        {
            //Baseline system requirements: 3)The index does not save information related to field normalisation--ANALYZED_NO_NORMS.  4)The index does not save information related to term vectors--TermVector.NO
            Lucene.Net.Documents.Field text_field = new Field(TEXT_FN, text, Field.Store.YES, Field.Index.ANALYZED_NO_NORMS, Field.TermVector.NO);
            Lucene.Net.Documents.Field passage_ID_field = new Field(ID_FN_PASSAGEID, passage_ID, Field.Store.YES, Field.Index.ANALYZED_NO_NORMS, Field.TermVector.NO);
            Lucene.Net.Documents.Field query_ID_field = new Field(ID_FN_QUERYID, query_ID, Field.Store.YES, Field.Index.ANALYZED_NO_NORMS, Field.TermVector.NO);
            Lucene.Net.Documents.Document doc = new Document();
            doc.Add(text_field);
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

            Query query = parser.Parse(querytext);


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
            Query query = parser.Parse(querytext);

            return query;

        }



        /// <summary>
        /// Get a ranked list of results
        /// </summary>
        /// <param name="query">A set of results</param>
        public List<string> GetResults(string query)
        {

            CreateSearcher();
            TopDocs results = SearchText(query, 100);




            List<string> resultList = new List<string>();
            int resultNum = 0;
            foreach (ScoreDoc scoreDoc in results.ScoreDocs)
            {
                // if (resultNum >= 10) { break; }
                resultNum += 1;
                Lucene.Net.Documents.Document doc = searcher.Doc(scoreDoc.Doc);
                string myFieldValue = doc.Get(TEXT_FN).ToString();
                // resultsStr += "Rank " + rank + " text " + myFieldValue + "\n";
                resultList.Add(myFieldValue);
            }

            CleanUpSearcher();

            return resultList;
        }

        public void SaveResult(string query, string filePath)
        {

            CreateSearcher();
            StreamWriter sw = new StreamWriter(filePath, true, Encoding.Default);//实例化StreamWriter
            TopDocs results = SearchText(query, 10);
            //TopDocs results = SearchText(query, searcher.MaxDoc);
            saveQuuery.Add(query);
            int idx = saveQuuery.IndexOf(query) + 1;
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
