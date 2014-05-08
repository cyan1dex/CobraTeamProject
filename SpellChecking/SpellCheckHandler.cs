using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;


namespace Cobra.SpellCheck
{
    public class SpellCheckHandler
    {


        private string m_SourceString;
        private string[] TwoGrams;
        private Dictionary<string, int> SpellScore = new Dictionary<string, int>();



        public SpellCheckHandler(string SourceString, ref Dictionary<int, List<string>> TwoGramCollection)
        {
            m_SourceString = SourceString;
            TwoGrams = ConvertTo2Grams();
            ScoreCalculationProcess(ref TwoGramCollection);           
        }

        public List<SpellItem> GenerateSuggestions()
        {
            List<SpellItem> SpellItems = new List<SpellItem>();
            EditDistance ed = new EditDistance();
            int EditDistance=0;

            var s = (from t in SpellScore
                             orderby t.Value ascending
                             select t).Take(20).ToDictionary(pair=>pair.Key, pair=>pair.Value);

            foreach (KeyValuePair<string, int> item in s)
            {
                EditDistance = ed.CalculateEditDistance(m_SourceString, item.Key);
                SpellItems.Add(new SpellItem(item.Key,EditDistance,item.Value));
            }

            return SpellItems;
        }

        private void ScoreCalculationProcess(ref Dictionary<int, List<string>> TwoGramCollection)
        {
            List<string> TwoGramStringList;
            foreach (string s in TwoGrams)
            {
                if (TwoGramCollection.ContainsKey(s.GetHashCode()))
                {
                    TwoGramStringList = TwoGramCollection[s.GetHashCode()];
                    foreach (string t in TwoGramStringList)
                    {
                        if (SpellScore.ContainsKey(t))
                        {
                            SpellScore[t] = SpellScore[t] - 2;
                        }
                        else
                        {
                            SpellScore.Add(t, ComputeInitScore(t));
                        }
                    }
                }
              
            }
        }


        private int ComputeInitScore(string t)
        {  
            return ((m_SourceString.Length+1) + (t.Length+1)) - 2 ;
        }

        /// <summary>
        /// This Function will conver the source string to to a two gram string array
        /// </summary>
        /// <returns></returns>
        private string[] ConvertTo2Grams()
        {
            string[] TwoGram = new string[m_SourceString.Length+1];
            for (int i = 0; i < m_SourceString.Length; i++)
            {
                if (i == 0)
                    TwoGram[i] = "$" + m_SourceString[i];
                else
                    TwoGram[i] = m_SourceString[i-1].ToString() +  m_SourceString[i].ToString();
            }
            TwoGram[m_SourceString.Length] = m_SourceString[m_SourceString.Length-1] + "$";

            return TwoGram;
        }
    }
}
