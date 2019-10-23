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
            if (freq >= 1 && freq <= 4)
            {
                freq = freq * (5 - freq);
            }

            return (float)System.Math.Sqrt(freq);
        }

        public override float Idf(int docFreq, int numDocs)
        {
            double docFreqTemp = docFreq;

            if (docFreq >= 1 && docFreq <= 9)
            {
                docFreqTemp = (double)docFreq / (double)(10 - docFreq);
            }
            return (float)(System.Math.Log(numDocs / (double)(docFreqTemp + 1)) + 1.0);
        }
    }
}
