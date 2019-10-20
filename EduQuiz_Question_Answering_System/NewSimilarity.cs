using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lucene.Net.Search;
using FieldInvertState = Lucene.Net.Index.FieldInvertState;

namespace EduQuiz_Question_Answering_System
{
    class NewSimilarity : DefaultSimilarity
    {
        public override float Tf(float freq)
        {
            // return (float) System.Math.Sqrt(freq);

            if (freq > 0 && freq < 5)
            {
                freq = freq * (5 - freq);
            }

            return (float)System.Math.Sqrt(freq);
        }

        public override float Idf(int docFreq, int numDocs)
        {
            // return (float) (System.Math.Log(numDocs / (double) (docFreq + 1)) + 1.0);

            double docFreqTemp = docFreq;

            if (docFreq > 0 && docFreq < 5)
            {
                docFreqTemp = (double)docFreq / (double)(5 - docFreq);
            }

            return (float)(System.Math.Log(numDocs / (double)(docFreqTemp + 1)) + 1.0);
        }
    }
}
