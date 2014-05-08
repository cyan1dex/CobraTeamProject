using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace Cobra.QTokenizer
{
    public class QParser : QSymbol 
    {

        public int bracketOffset = 0;
        QLexer lexer;
        //        String tempToken = "";
        private QTokenBuffer input;
        private object current;
        //private StreamWriter streamOut;

        private int getPos() { return input.getPos(); }
        private int tokenValue(int i) { return input.tokenValue(i).Type; }
        private QToken tokenAssignment(int i) { return input.tokenValue(i); }
        private void consume(int val) { input.consume(val); }
        private void consume() { input.consume(1); }
        private void discard(int c) { consume(c); }

        public Hashtable wordList = new Hashtable(); //Key, term
        public Dictionary<int, List<QIndex>> invertedIndex = new Dictionary<int, List<QIndex>>(); //Key, <DocId & Posting>

        public QParser(QLexer lexer)
        {
            input = new QTokenBuffer(lexer, 2); //Parse two tokens at a time
            //this.streamOut = null;
            this.lexer = lexer;
        }


        public QParser(QTokenBuffer t)
        {
            input = t;
            //streamOut = null;
        }

        public object Evaluate()
        {
            int i = 0; //acutal word position
            int z = 0; //word position taking in account dupes
            while (tokenValue(1) != TOKEN_EOF)
            {
                List<int> positionList;
                positionList = new List<int>();
                positionList.Add(i);

                wordList.Add(z, tokenAssignment(1).Text);
                //frequency.Add(z, positionList);
                z++;

                discard(1);
                i++;
            }

            return current;
        }

        void PurgeLine()
        {
            while (tokenValue(1) != TOKEN_ENDLINE)
                discard(1);
        }

    }
}