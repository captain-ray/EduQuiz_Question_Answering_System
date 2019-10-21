using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;



namespace EduQuiz_Question_Answering_System
{
    class Utils
    {

        // stopwords for custom system
        public static string[] STOPWORDS = { "i", "me", "my", "myself", "we", "our", "ours", "ourselves", "you", "your", "yours", "yourself", "yourselves", "he", "him", "his", "himself", "she", "her", "hers", "herself", "it", "its", "itself", "they", "them", "their", "theirs", "themselves", "what", "which", "who", "whom", "this", "that", "these", "those", "am", "is", "are", "was", "were", "be", "been", "being", "have", "has", "had", "having", "do", "does", "did", "doing", "a", "an", "the", "and", "but", "if", "or", "because", "as", "until", "while", "of", "at", "by", "for", "with", "about", "against", "between", "into", "through", "during", "before", "after", "above", "below", "to", "from", "up", "down", "in", "out", "on", "off", "over", "under", "again", "further", "then", "once", "here", "there", "when", "where", "why", "how", "all", "any", "both", "each", "few", "more", "most", "other", "some", "such", "no", "nor", "not", "only", "own", "same", "so", "than", "too", "very", "s", "t", "can", "will", "just", "don", "should", "now" };

       

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

            int numTokens = tokens.Count();
            List<string> filteredTokens = new List<string>();
            for (int i = 0; i < numTokens; i++)
            {
                string token = tokens[i];
                if (!STOPWORDS.Contains(token) && (token.Length > 2)) filteredTokens.Add(token);
                // if (!STOPWORDS.Contains(token)) filteredTokens.Add(token);
            }
            return filteredTokens.ToArray<string>();
        }

    }
}
