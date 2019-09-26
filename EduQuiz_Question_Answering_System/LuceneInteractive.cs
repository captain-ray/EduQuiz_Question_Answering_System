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

        const Lucene.Net.Util.Version VERSION = Lucene.Net.Util.Version.LUCENE_30;
        const string TEXT_FN = "Text"; //what is this for?

        public LuceneInteractive(){

        }

        public LuceneInteractive(string jsonFilePath, string indexPath)
        {
            luceneIndexDirectory = null;
            writer = null;
            analyzer = new Lucene.Net.Analysis.SimpleAnalyzer();
            parser = new QueryParser(VERSION, TEXT_FN, analyzer);

            
            CreateIndex(indexPath); //create index

            collection=Utils.getCollection(jsonFilePath); //retrieve all documents from Json file

            foreach(Item item in collection){
                foreach(Passage passage in item.Passages){
                    string indexText=passage.url+" "+passage.passage_text; //Baseline System requirement--"all the text and url is indexed as a single field"
                    IndexText(indexText);
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
        /// Indexes a given string into the index
        /// </summary>
        /// <param name="text">The text to index</param>
        public void IndexText(string text)
        {
            //Baseline system requirements: 3)The index does not save information related to field normalisation--ANALYZED_NO_NORMS.  4)The index does not save information related to term vectors--TermVector.NO
            Lucene.Net.Documents.Field field = new Field(TEXT_FN, text, Field.Store.YES, Field.Index.ANALYZED_NO_NORMS, Field.TermVector.NO);
            Lucene.Net.Documents.Document doc = new Document();
            doc.Add(field);
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
        public TopDocs SearchText(string querytext)
        {

            System.Console.WriteLine("Searching for " + querytext);
            querytext = querytext.ToLower();
            Query query = parser.Parse(querytext);

            TopDocs results = searcher.Search(query, 100);

            return results;
        }


        /// <summary>
        /// Displays a ranked list of results to the screen
        /// </summary>
        /// <param name="results">A set of results</param>
        public string GetResults(string query)
        {

            CreateSearcher();
            TopDocs results=SearchText(query);


            string resultsStr="";
            int rank = 0;
            foreach (ScoreDoc scoreDoc in results.ScoreDocs)
            {
                rank++;
                Lucene.Net.Documents.Document doc = searcher.Doc(scoreDoc.Doc);
                string myFieldValue = doc.Get(TEXT_FN).ToString();
                resultsStr+="Rank " + rank + " text " + myFieldValue+"\n";
            }

            CleanUpSearcher();

            return resultsStr;

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
