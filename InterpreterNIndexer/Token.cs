using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobra.InterpreterNIndexer 
{
    public class Token 
    {
        private string text;
        private int type;

        public Token(int type, string text)
        {
            this.type = type;
            this.text = text;
        }
        public string Text
        {
            get { return (text); }
            set { text = value; }
        }
        public int Type
        {
            get { return (type); }
            set { type = value; }
        }
    }
}
