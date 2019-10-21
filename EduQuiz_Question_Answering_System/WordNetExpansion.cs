using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Syn.WordNet; //Syn.WordNet

namespace EduQuiz_Question_Answering_System
{

    class WordNetExpansion
    {
        // stopwords for custom system
        public static string[] STOPWORDS = { "i", "me", "my", "myself", "we", "our", "ours", "ourselves", "you", "your", "yours", "yourself", "yourselves", "he", "him", "his", "himself", "she", "her", "hers", "herself", "it", "its", "itself", "they", "them", "their", "theirs", "themselves", "what", "which", "who", "whom", "this", "that", "these", "those", "am", "is", "are", "was", "were", "be", "been", "being", "have", "has", "had", "having", "do", "does", "did", "doing", "a", "an", "the", "and", "but", "if", "or", "because", "as", "until", "while", "of", "at", "by", "for", "with", "about", "against", "between", "into", "through", "during", "before", "after", "above", "below", "to", "from", "up", "down", "in", "out", "on", "off", "over", "under", "again", "further", "then", "once", "here", "there", "when", "where", "why", "how", "all", "any", "both", "each", "few", "more", "most", "other", "some", "such", "no", "nor", "not", "only", "own", "same", "so", "than", "too", "very", "s", "t", "can", "will", "just", "don", "should", "now" };

        char[] splitters = new char[] { ' ', '\t', '\'', '"', '-', '(', ')', ',', '’', '\n', ':', ';', '?', '.', '!' };

        WordNetEngine wordNet;

        public WordNetExpansion()
        {
            LoadWordNetDatabase();

        }

        // load WordNet Database
        public void LoadWordNetDatabase()
        {
            var directory = Directory.GetCurrentDirectory() + "\\wordnet"; // assume we have copied the WordNet files in the bin/Debug/wordnet folder
            wordNet = new WordNetEngine();

            wordNet.LoadFromDirectory(directory);
        }


        public string GetExpandedQuery_Weighted(string query)
        {
            string[] tokens = TokeniseString(query);
            string[] tokensNoStops = StopWordFilter(tokens);

            string expandedQuery_Weighted = "";


            foreach (string token in tokensNoStops)
            {
                string expandedToken_Weighted = GetExpandedToken_Weighted(token);
                expandedQuery_Weighted = expandedQuery_Weighted + expandedToken_Weighted + " ";
            }

            expandedQuery_Weighted = expandedQuery_Weighted.TrimEnd(' ');

            return expandedQuery_Weighted;


        }

        //get a expanded also weighted token, for example, "book" ---> "book^5 ledger script"
        public string GetExpandedToken_Weighted(string token)
        {
            List<string> thesaurus = new List<string>();
            // string expandedToken_Weighted = token + "^5"; // if adding boost to word, will not get any results
            string expandedToken_Weighted = token + "";

            thesaurus = GetThesaurus(token);

            foreach (string word in thesaurus)
            {
                if (word != token)
                {
                    expandedToken_Weighted = expandedToken_Weighted + " " + word;
                }
            }

            return expandedToken_Weighted;

        }


        //get a list of thesaurus of a token
        public List<string> GetThesaurus(string token)
        {
            List<string> thesaurus = new List<string>();
            thesaurus.Add(token); //original token

            var synSetList = wordNet.GetSynSets(token);
            foreach (var synSet in synSetList)
            {
                foreach (string word in synSet.Words)
                {
                    if (!thesaurus.Contains(word))
                    {
                        thesaurus.Add(word);
                    }
                }
            }

            return thesaurus;
        }

        /// <summary>
        /// Convert the  given text into tokens and then splits it into tokens according to whitespace and punctuation. 
        /// </summary>
        /// <param name="text">Some text</param>
        /// <returns>Lower case tokens</returns>
        public string[] TokeniseString(string text)
        {
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
