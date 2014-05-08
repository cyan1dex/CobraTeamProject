using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cobra.PorterStemming;

namespace Cobra.QTokenizer
{
    public class QToken 
    {
        private string m_text;
        private int m_type;
        private static PorterStemming.PorterStemming ps = new PorterStemming.PorterStemming();

        public QToken(int type, string text, bool porterstem)
        {
            string psText = text;

            if (porterstem)
            {
                ps.PorterStemmingProcessing(text);
                psText = ps.ProcessingString;
            }

            this.m_type = type;
            this.m_text = psText;
        }

        public string Text
        {
            get { return (m_text); }
            set { m_text = value; }
        }
        public int Type
        {
            get { return (m_type); }
            set { m_type = value; }
        }
    }
}
