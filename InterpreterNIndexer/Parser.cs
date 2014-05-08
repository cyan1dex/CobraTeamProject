using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class WordPosition {
    public string cur;
    public int position;
    public WordPosition(string cur, int position)
    {
        this.cur = cur;
        this.position = position;
    }
}
namespace Cobra.InterpreterNIndexer {
    public class Parser : Symbol {
        public int bracketOffset = 0;
        public Lexer lexer;
        private TokenBuffer input;
        private object current;
        private StreamWriter streamOut;

        private int getPos() { return input.getPos(); }
        private int tokenValue(int i) { return input.tokenValue(i).Type; }
        private Token tokenAssignment(int i) { return input.tokenValue(i); }
        private void consume(int val) { input.consume(val); }
        private void consume() { input.consume(1); }
        private void discard(int c) { consume(c); }

        public int docId;
        public bool singleFile;
        public List<string> currentFile = new List<string>();
        public List<int> newDocPositions = new List<int>();

        public Hashtable wordList;
        public Dictionary<int, List<Index>> invertedIndex;
        public Dictionary<int, List<String>> oneGramIndex = new Dictionary<int, List<String>>();
        public Dictionary<int, List<String>> twoGramIndex = new Dictionary<int, List<String>>();

         public List<int> heaps = new List<int>();
         int heapsType = 0;

        //j variable is used to handle three grams when looped after two grams are processed
        public void createKGrams(String term, int size)
        {
            String gram;
            int strLength = term.Length;
            if (strLength < 2)
                return;
            int j;
            if (size == 3)
                j = 1;
            else
                j = 0;

            if (size == 1)
            {
                for (int i = 0; i < strLength; i++)
                {
                    if (i == 0) //add first k-gram
                        gram = term.Substring(0, 1);
                    else if (i == strLength - 1) //add last k-gram
                        gram = term.Substring(strLength - 1, 1);
                    else
                        gram = term.Substring(i, 1);

                    int gramHash = gram.GetHashCode();

                    if (!oneGramIndex.ContainsKey(gramHash))
                    {
                        List<String> oneGrams = new List<string>();
                        oneGrams.Add(term);
                        oneGramIndex.Add(gramHash, oneGrams);
                    }
                    else
                        oneGramIndex[gramHash].Add(term);
                }
            }
            else
            {
                for (int i = -1; i < strLength - j; i++)
                {
                    if (i == -1) //add first k-gram
                        gram = "$" + term.Substring(0, 1 + j);
                    else if (i == strLength - 1 - j) //add last k-gram
                        gram = term.Substring(strLength - 1 - j, 1 + j) + "$";
                    else
                        gram = term.Substring(i, 2 + j);

                    int gramHash = gram.GetHashCode();

                    if (size == 2)
                    {
                        if (!twoGramIndex.ContainsKey(gramHash))
                        {
                            List<String> twoGrams = new List<string>();
                            twoGrams.Add(term);
                            twoGramIndex.Add(gramHash, twoGrams);
                        }
                        else
                            twoGramIndex[gramHash].Add(term);
                    }
                }
            }
        }


        public Parser(Lexer lexer, Dictionary<int, List<Index>> invertedIndex, Hashtable wordList, int docId, bool singleFile)
        {
            input = new TokenBuffer(lexer, 2); //Parse two tokens at a time
            this.streamOut = null;
            this.lexer = lexer;
            this.wordList = wordList;
            this.invertedIndex = invertedIndex;
            this.docId = docId;
            this.singleFile = singleFile;
        }

        public TokenBuffer getTokenBuffer
        {
            get { return input; }
            set { input = value; }
        }

        public void reset()
        {
            invertedIndex.Clear();
            wordList.Clear();
            currentFile.Clear();
            newDocPositions.Clear();
            docId = 0;
        }

        public Parser(TokenBuffer t)
        {
            input = t;
            streamOut = null;
        }

        public void Evaluate()
        {
            Cobra.PorterStemming.PorterStemming stemmer = new Cobra.PorterStemming.PorterStemming();

            int i = 0; //acutal word position
            int j = 0;
            newDocPositions.Add(0);
            while (tokenValue(1) != TOKEN_EOF)
            {
                currentFile.Add(tokenAssignment(1).Text);

                if (singleFile && (tokenAssignment(1).Type == TOKEN_ENDLINE && tokenAssignment(2).Type == TOKEN_ENDLINE))
                {
                    docId++;
                    newDocPositions.Add(i);
                    discard(1); //discard first line break;
                }
                else if (!tokenAssignment(1).Text.Equals("s") && tokenAssignment(1).Type == TOKEN_IDENTIFIER) //TODO: porter stemmer doesnt handle s properly
                {

                    stemmer.PorterStemmingProcessing(tokenAssignment(1).Text);
                    String stemWord = stemmer.ProcessingString;
                    int hashVal = stemWord.GetHashCode(); //Get the hashVal of the current Word

                    if (wordList.ContainsKey(hashVal)) //If word is in HashTable add it to InvertedIndex
                    {
                        heaps.Add(heapsType);
                        Index val2 = new Index(docId, j, stemWord, i); //Create a new Index value with docId = 0, posting position = i
                        invertedIndex[hashVal].Add(val2); //Add that value to the same entry Key as in the HashTable
                    }
                    else //If else than that term is not in the Hashtable yet, so create new hash index in hashTable and dictionary
                    {
                        heapsType++;
                        List<Index> index = new List<Index>();
                        Index val2 = new Index(docId, j, stemWord, i);
                        index.Add(val2);
                        wordList.Add(hashVal, stemWord);
                        invertedIndex.Add(hashVal, index);
                        createKGrams(tokenAssignment(1).Text, 1); //add one gram
                        createKGrams(tokenAssignment(1).Text, 2); //add two gram
                    }
                    j++;
                }
                discard(1);
                i++;
            }
        }
    }
}

