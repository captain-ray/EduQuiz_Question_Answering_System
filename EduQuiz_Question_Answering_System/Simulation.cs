using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EduQuiz_Question_Answering_System
{

    class Simulation
    {

        //important! modify the following paths to your local path
        const string jsonFilePath = @"Z:\Desktop\QUT\IFN647\Project\collection.json";
        const string indexPath = @"C:\Users\CaptainXun\Desktop\QUT\IndexFolder";
        const string resultPath = @"C:\Users\CaptainXun\Desktop\QUT\Evaluation\Baseline_Results.txt";
        const string qrels_RetrieveListOfPassages_path = @"C:\Users\CaptainXun\Desktop\QUT\Evaluation\qrels_RetrieveListOfPassages.txt";
        const string qrels_RetrieveSelectedPassages_path = @"C:\Users\CaptainXun\Desktop\QUT\Evaluation\qrels_RetrieveSelectedPassages.txt";

        const int ITEM_NUM = 1000; // set a maximum number of items, because the whole collection has 82325 items, which is huge.
        public LuceneInteractive myLuceneApp;

        List<Item> collection;

        public Simulation()
        {
            GetResults(); //get results, iterate every query in the collection

            CreateQrels_RetrieveListOfPassages(); //create qrels files for the metrics of retrieving the list of passages linked to the query

            CreateQrels_RetrieveSelectedPassage(); //create qrels files for the metrics of retrieving the selected passage(s)
        }


        //get results, iterate every query in the collection
        public void GetResults()
        {
            myLuceneApp = new LuceneInteractive(jsonFilePath, indexPath);

            collection = Utils.getCollection(jsonFilePath); //retrieve all documents from Json file

            int itemNum = 0;

            foreach (Item item in collection)
            {
                itemNum++;
                if (itemNum > ITEM_NUM)
                {
                    break;
                }

                string query = item.query;
                myLuceneApp.SaveResultForSimulation(query, resultPath, item.query_id.ToString());
            }
        }

        //create qrels files for the metrics of retrieving the list of passages linked to the query
        public void CreateQrels_RetrieveListOfPassages()
        {
            StreamWriter sw = new StreamWriter(qrels_RetrieveListOfPassages_path, true, Encoding.Default);

            int itemNum = 0;

            foreach (Item item in collection)
            {
                itemNum++;
                if (itemNum > ITEM_NUM)
                {
                    break;
                }

                string query_id = item.query_id.ToString();
                foreach (Passage passage in item.Passages)
                {
                    sw.WriteLine(query_id + " " + "0" + " " + passage.passage_ID + " " + 1 + " ");
                }
            }
            sw.Close();
        }

        //create qrels files for the metrics of retrieving the selected passage(s)
        public void CreateQrels_RetrieveSelectedPassage()
        {
            StreamWriter sw = new StreamWriter(qrels_RetrieveSelectedPassages_path, true, Encoding.Default);

            int itemNum = 0;

            foreach (Item item in collection)
            {
                string query_id = item.query_id.ToString();
                foreach (Passage passage in item.Passages)
                {

                    itemNum++;
                    if (itemNum > ITEM_NUM)
                    {
                        break;
                    }
                    
                    if (passage.is_selected == 1)
                    {
                        sw.WriteLine(query_id + " " + "0" + " " + passage.passage_ID + " " + 1 + " ");
                    }
                }
            }
            sw.Close();
        }

    }
}
