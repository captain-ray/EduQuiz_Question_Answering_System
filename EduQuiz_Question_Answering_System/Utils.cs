using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

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


        public static string Pre_Process_Query(string query)
        {
            string[] tokens = TokeniseString(query);
            string[] tokensNoStops = StopWordFilter(tokens);

            string pre_processed_query = String.Join(" ", tokensNoStops); // combine tokensNoStops with spaces in between

            return pre_processed_query;

        }

        /// <summary>
        /// Convert the  given text into tokens and then splits it into tokens according to whitespace and punctuation. 
        /// </summary>
        /// <param name="text">Some text</param>
        /// <returns>Lower case tokens</returns>
        public static string[] TokeniseString(string text)
        {
            char[] splitters = new char[] { ' ', '\t', '\'', '"', '-', '(', ')', ',', '’', '\n', ':', ';', '?', '.', '!' };
            return text.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Removes stopwords from an array of tokens
        /// </summary>
        /// <param name="tokens">An array of tokens</param>
        /// <returns>The array of tokens without any stopwords</returns>
        public static string[] StopWordFilter(string[] tokens)
        {
            string[] stopWords = { "a", "an", "and", "are", "as", "at", "be", "but", "by", "for", "if", "in", "into", "is", "it", "no", "not", "of", "on", "or", "such", "that", "the", "their", "then", "there", "these", "they", "this", "to", "was", "will", "with" };

            int numTokens = tokens.Count();
            List<string> filteredTokens = new List<string>();
            for (int i = 0; i < numTokens; i++)
            {
                string token = tokens[i];
                // if (!stopWords.Contains(token) && (token.Length > 2)) filteredTokens.Add(token);
                if (!stopWords.Contains(token)) filteredTokens.Add(token);
            }
            return filteredTokens.ToArray<string>();
        }

    }
}
