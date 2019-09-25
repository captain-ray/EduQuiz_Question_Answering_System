using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using static System.Console;


namespace EduQuiz_Question_Answering_System
{
    class Utils
    {

        // const string jsonFilePath = @"Z:\Desktop\QUT\IFN647\Project\collection.json";

        //parse .json file and then get the whole collection, which is composed of 'Item'
        public static List<Item> getCollection(string jsonFilePath)
        {

            // List<Item> collection = JsonConvert.DeserializeObject<List<Item>>(File.ReadAllText(jsonFilePath)); //using this one will cause getting out of memory, because it reads all the text at a time

            List<Item> collection = null;
            using (StreamReader file = File.OpenText(jsonFilePath)) //using StreamReader prevents it from getting out of memory
            {
                JsonSerializer serializer = new JsonSerializer();
                collection = (List<Item>)serializer.Deserialize(file, typeof(List<Item>)); //parse the string obtained from .json file to the list of 'Item' objects
            }

            return collection;
        }


        // //parse Json files and then get the 'passage_text' and 'url' from each passage
        // public static Dictionary<string, string> getAllDocuments()
        // {
        //     Dictionary<string, string> allDocuments = new Dictionary<string, string>();


        //     // List<Item> collection = JsonConvert.DeserializeObject<List<Item>>(File.ReadAllText(jsonFilePath)); //using this one will cause getting out of memory, because it reads all the text at a time

        //     using (StreamReader file = File.OpenText(jsonFilePath)) //using StreamReader prevents it from getting out of memory
        //     {
        //         JsonSerializer serializer = new JsonSerializer();
        //         List<Item> collection = (List<Item>)serializer.Deserialize(file, typeof(List<Item>)); //parse the string obtained from .json file to the list of 'Item' objects
        //     }


        //     WriteLine("hah");
        //     return allDocuments;
        // }
    }
}
