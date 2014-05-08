using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cobra.QTokenizer;
using Cobra.InterpreterNIndexer;
using Cobra.Tree;
using Cobra.BooleanQuery;
using Cobra.CustomErrors;
using System.Collections;

namespace Cobra
{
    public class IndexData
    {
        public static QParser qparser { get; set;}
        public static Parser parser {get; set;}

        public static Dictionary<int, List<Index>> termDictionary { get; set; } //Key, <DocId & Posting>
        public static Hashtable hstTable { get; set; }
        public static BSTask bqTree { get; set; }

        public static Hashtable wordList = new Hashtable(); //Key, term
        public static Dictionary<int, List<Index>> invertedIndex = new Dictionary<int, List<Index>>(); //Key, <DocId & Posting>
        public static Dictionary<int, List<String>> oneGramIndex = new Dictionary<int, List<String>>();
        public static Dictionary<int, List<String>> twoGramIndex = new Dictionary<int, List<String>>();

        public static int docID { get; set; }

		public static List<string> FileListInfo = new List<string>();
        public static List<List<String>> DocStrings = new List<List<string>>();

		public static Boolean InitIndexData()
		{
			try
			{
				qparser = null;
				parser = null;
				termDictionary = null;
				hstTable = null;
				bqTree = null;				
				wordList = null;
				invertedIndex = null;
                DocStrings = null;
                oneGramIndex = null;
                twoGramIndex = null;
				docID = 0;

				return true;
			}
			catch
			{
				return false;
			}	
		}
    }
}
