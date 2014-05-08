using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Cobra.Tree;
using Cobra.QTokenizer;
using Cobra.InterpreterNIndexer;
using Cobra.CustomErrors;
//using Cobra.PorterStemming;

namespace Cobra.BooleanQuery
{
    public class SyntaxAnalyzer
    {
        private string m_BooleanQString;

        public SyntaxAnalyzer(string BooleanQString)
        {
            this.m_BooleanQString = BooleanQString;
        }

        public bool ValidateEnclosureMatching()
        {
            var count = m_BooleanQString.Count(c => c == '"');
            if (count % 2 != 0)
                return false;

            count = m_BooleanQString.Count(c => c == '(');
            var count2 = m_BooleanQString.Count(c => c == ')');
            if (count != count2)
                return false;

            return true;
        }

        public bool ValidateDNFClause(BSTask CommandTree)
        {
            bool negated = false;

            foreach (BSTask literalNode in CommandTree.Children)
            {
                if (literalNode.Children.Count == 0)
                {
                    negated = true;
                    break;
                }
                else
                {
                    foreach (BSTask literal in literalNode.Children)
                    {
                        negated = literal.Negated;
                        if (!negated)
                            break;
                    }
                    if (negated)
                        break;
                }
            }
            return !negated;
        }
    }

    public class QueryPrepper
    {
        private static Hashtable m_Wordlist;
        private static ArrayList m_negatedLiteralsList = new ArrayList();
        private static string m_cmdTreeString;
        //private static Task m_rootNode;

        public QueryPrepper(Hashtable Wordlist)
        {
            m_Wordlist = Wordlist;
            m_cmdTreeString = "";
        }

        public BSTask BooleanSearchTree()
        {
            PorterStemming.PorterStemming ps = new PorterStemming.PorterStemming();
            List<BSTask> operators = new List<BSTask>();
            List<BSTask> operands = new List<BSTask>();
            BSTask Operator;

            // initialize tree with root and first command node
            BSTask BooleanCommand = new BSTask("Search Tree");
            BSTask DNFNodeCommand = new BSTask(FunctionalSymbol.FTOKEN_OR);
            operators.Add(BooleanCommand.Children.Add(DNFNodeCommand));

            int loopCount = m_Wordlist.Count;
            int i = 0; int commandcounter = 0;
            //bool previousOR = false;

            Operator = operators[commandcounter];
            for (i = 0; i < loopCount; i++)
            {
                if (m_Wordlist[i].ToString() == FunctionalSymbol.FTOKEN_PLUS)
                {
                    if (m_negatedLiteralsList.Count > 0)
                    {
                        for (int j = 0; j < m_negatedLiteralsList.Count; j++)
                            Operator.Children.Add(new BSTask(m_negatedLiteralsList[j].ToString(), true));
                        m_negatedLiteralsList.Clear();
                    }
                    commandcounter++;
                    operators.Add(BooleanCommand.Children.Add(new BSTask(FunctionalSymbol.FTOKEN_OR)));
                    Operator = operators[commandcounter];
                    //previousOR = true;
                }
                else if (ContainWildcard(m_Wordlist[i].ToString()))
                {
                    BSTask WildNodeCommand = new BSTask(FunctionalSymbol.FTOKEN_WILDCARD_STRING, false, true);
                    ArrayList Kgrams = ConvertToKgramIndexers(m_Wordlist[i].ToString());

                    Operator.Children.Add(WildNodeCommand);
                    foreach (string Kgram in Kgrams)
                    {
                        WildNodeCommand.Children.Add(new BSTask(Kgram, false, true));
                    }
                }
                else if (m_Wordlist[i].ToString() == FunctionalSymbol.FTOKEN_MINUS)
                {
                    m_negatedLiteralsList.Add(m_Wordlist[++i]);
 //                   Operator.Children.Add(new BSTask(m_Wordlist[++i].ToString(), negation));
                }
                else if (m_Wordlist[i].ToString() == FunctionalSymbol.FTOKEN_QUOTE)
                {
                    BSTask ExactNodeCommand = new BSTask(FunctionalSymbol.FTOKEN_EXACT);
                    Operator.Children.Add(ExactNodeCommand);

                    if (m_Wordlist[++i].ToString() == FunctionalSymbol.FTOKEN_QUOTE)
                        throw new EmptyEnclosureException();

                    do
                    {
                        ExactNodeCommand.Children.Add(new BSTask(m_Wordlist[i].ToString()));
                        i++;
                    }
                    while ((m_Wordlist[i].ToString() != FunctionalSymbol.FTOKEN_QUOTE));
                }
                else
                {
                    Operator.Children.Add(new BSTask(m_Wordlist[i].ToString()));
                }
            }

            if (m_negatedLiteralsList.Count > 0)
            {
                for (int j = 0; j < m_negatedLiteralsList.Count; j++)
                    Operator.Children.Add(new BSTask(m_negatedLiteralsList[j].ToString(), true));
                m_negatedLiteralsList.Clear();
            }
            BooleanCommand.Complete = true;
            return BooleanCommand;
        }

        public string BooleanSearchTreeToString(BSTask Task, int Level)
        {
            string indent = string.Empty.PadLeft(Level * 3);
            m_cmdTreeString += indent + Task.Name + (Task.Negated ? "   (negated)" : "") + "\r\n";

            Level++;
            foreach (BSTask ChildTask in Task.Children)
            {
                BooleanSearchTreeToString(ChildTask, Level);
            }
            return m_cmdTreeString;
        }

        private ArrayList ConvertToKgramIndexers(string wildcardString)
        {
            int index = -1; int startposition = 0;
            string substring = "";
            ArrayList kgramindexers = new ArrayList();
            bool firstTime = true;

            do
            {
                index = wildcardString.IndexOf('*');

                if (index == -1)
                {
                    kgramindexers.Add(wildcardString + "$");
                }
                else
                {
                    if (index == 0)
                        firstTime = false;
                    else if (index > 0)
                    {
                        if (firstTime)
                        {
                            substring = "$" + wildcardString.Substring(startposition, index);
                            firstTime = false;
                        }
                        else
                            substring = wildcardString.Substring(startposition, index);
                        kgramindexers.Add(substring);
                    }
                 
                    if (index == wildcardString.Length-1)
                        index = -1;
                    else
                    {
                        startposition = index + 1;
                        wildcardString = wildcardString.Substring(startposition, wildcardString.Length - index - 1);
                    }
                }
                startposition = 0;
            }
            while (index != -1);
            return kgramindexers;
        }

        private bool ContainWildcard(string searchString)
        {
            if (searchString.IndexOf('*') != -1)
                return true;
            else
                return false;
        }
    }

    public class SearchExecutor
    {
        private Hashtable m_hstTable;
        private Dictionary<int, List<Index>> m_termDictionary;
        private List<Index> m_Result;
        private bool m_includeWildcardSearch;
        private IEnumerable<String> m_kgramsSearchList;
        
        private Dictionary<int, List<String>> m_oneGramIndex;
        private Dictionary<int, List<String>> m_twoGramIndex;

        //public SearchExecutor(Hashtable hstTable, Dictionary<int, List<Index>> termDictionary,
        //                      Dictionary<int, List<Index>> oneGramIndex, Dictionary<int, List<Index>> twoGramIndex)
        public SearchExecutor(Hashtable hstTable, Dictionary<int, List<Index>> termDictionary, 
                              Dictionary<int, List<String>> oneGramIndex, Dictionary<int, List<String>> twoGramIndex)
        {
            m_hstTable = hstTable;
            m_termDictionary = termDictionary;
            m_oneGramIndex = oneGramIndex;
            m_twoGramIndex = twoGramIndex;
            m_includeWildcardSearch = false;
        }

        public void OptimizeQuery()
        { }

        // returns results for each operand search
        private void TermQuery(BSTask command)
        {
            TermQuery(command.Name, command.Negated);
        }

        private void TermQuery(string commandname, bool negated)
        {
            //int hashVal = command.Name.GetHashCode(); //Get the hashVal of the current Word
            int hashVal = commandname.GetHashCode();
            bool success = false;
            if (m_hstTable.ContainsKey(hashVal)) //If word is in HashTable add it to InvertedIndex
            {
                // if (command.Negated)
                if (negated)
                {
                    List<Index> negatedOccurrences = new List<Index>();
                    foreach (KeyValuePair<int, List<Index>> term in m_termDictionary)
                    {
                        if (hashVal == term.Key)
                        {
                            int count = term.Value.Count;
                            for (int i = 0; i < count; i++)
                                negatedOccurrences.Add(term.Value[i]);
                            break;
                        }
                    }
                    m_Result = negatedOccurrences;
                }
                else
                    success = m_termDictionary.TryGetValue(hashVal, out m_Result);
            }
            else
                m_Result = null;
        }

        private List<Index> ExactQuery(BSTask searchBranch)
        {
            ArrayList Postings = new ArrayList();
            IEnumerable<BSTask> Operands;
            List<Index> combinedList=null;

            //BSTask ExactQueryParent = (BSTask)COMMAND.Children[0];
            Operands = GetLiterals(searchBranch, true);

            foreach (BSTask Operand in Operands)
            {
                TermQuery(Operand);
                if (this.Results == null)
                    return null;
                else
                    Postings.Add(Results);
            }

            int count = Postings.Count;
            if (count == 1)
                return this.Results;
            else
            {
                int j = 0;
                for (int i = 1; i < count; i++)
                {
                    if (i == 1)
                    {
                        combinedList = ExactPhraseSubSet((List<Index>)Postings[j], (List<Index>)Postings[++j], i);
                        if (combinedList == null)
                            break;
                    }
                    else
                        combinedList = ExactPhraseSubSet(combinedList, (List<Index>)Postings[++j], i);
                }
            }
            return combinedList;
        }

        private IEnumerable<String> KgramQuery(BSTask searchBranch, out ArrayList KgramSearchStrings)
        {
            bool first = true;

            string[] combinedKgrams = null; string[] tempKgram;
            IEnumerable<String> FcombinedKgrams = null;
            IEnumerable<String> finalKgrams=null;
            IEnumerable<BSTask> Operands;
            KgramSearchStrings = new ArrayList();

            Operands = GetLiterals(searchBranch, true);

            foreach (BSTask Operand in Operands)
            {
                KgramIndexer kgramindexer = new KgramIndexer(Operand.Name, m_oneGramIndex, m_twoGramIndex);
                KgramSearchStrings.Add(Operand.Name);
                foreach (Kgram kgram in kgramindexer.KgramIndexerList)
                {
                    tempKgram = kgram.Postings.ToArray();
                    if (first)
                    {
                        first = false;
                        combinedKgrams = tempKgram;
                        finalKgrams = combinedKgrams;
                    }
                    else
                    {
                        FcombinedKgrams = combinedKgrams.Intersect(tempKgram);
                        finalKgrams = FcombinedKgrams;
                    }
                }
            }
            return finalKgrams;
        }

        private IEnumerable<String> MatchKGramSequence(IEnumerable<String> matchedList, ArrayList kgramSearchLiterals)
        {
            List<String> finalList = new List<string>();
            int prvposition = 0, position = 0, length = 0;
            int index=0;
            string cleanedLiteral = "";
            bool InSequence=true;

            foreach (string matchedTerm in matchedList)
            {
                foreach (string literal in kgramSearchLiterals)
                {
                    length = matchedTerm.Length;
                    index = literal.IndexOf("$");
                    if (index < 0)
                        cleanedLiteral = literal;
                    else
                        cleanedLiteral = literal.Remove(index, 1);
                    position = matchedTerm.IndexOf(cleanedLiteral, prvposition);
                    if (index >= 0)
                    {
                        if ((index == 0) && (position != 0))
                        {
                            InSequence = false;
                            break;
                        }
                        else if (index > 0)
                        {
                            if (position != (length - cleanedLiteral.Length))
                            {
                                position = matchedTerm.LastIndexOf(cleanedLiteral);
                                if ((position != (length - cleanedLiteral.Length)) || (position == -1))
                                {
                                    InSequence = false;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (position < prvposition)
                        {
                            InSequence = false;
                            break;
                        }
                    }
                    prvposition = position + 1;
                }
                if (InSequence)
                    finalList.Add(matchedTerm);
                prvposition = 0;
                InSequence = true;
            }
            return finalList;
        }

        private IEnumerable<Index> WildcardQuery(BSTask searchBranch)
        {
            ArrayList Postings = new ArrayList();
            ArrayList KgramSearchLiterals;
            IEnumerable<Index> combinedList = null;
            bool first = true;
            String stemmedSearchWord;

            Cobra.PorterStemming.PorterStemming stemmer = new Cobra.PorterStemming.PorterStemming();

            m_includeWildcardSearch = true;
            m_kgramsSearchList = KgramQuery(searchBranch, out KgramSearchLiterals);

            // validate correct kgram sequence against array of returned terms
            m_kgramsSearchList = MatchKGramSequence(m_kgramsSearchList, KgramSearchLiterals);

            foreach (String kgramSearchString in m_kgramsSearchList)
            {
                stemmer.PorterStemmingProcessing(kgramSearchString);
                stemmedSearchWord = stemmer.ProcessingString;
                TermQuery(stemmedSearchWord, false);
                if (this.Results == null)
                    return null;
                else
                {
                    if (first)
                    {
                        first = false;
                        combinedList = this.Results;
                    }
                    else
                        combinedList = UnionQuery(combinedList, this.Results);
                }
            }
            return combinedList;
        }

        //searches for postings occurring in sequence for exact phrase query match
        private List<Index> ExactPhraseSubSet(List<Index> ListOne, List<Index> ListTwo, int SequenceIncrementor)
        {
            List<Index> combinedList = new List<Index>();
            int count = ListOne.Count;  int Doc1ID = 0;
            int count2 = ListTwo.Count; int Doc2ID = 0;
            int loopControl = 0;

            for (int i=0; i < count; i++) 
            {
                Doc1ID = ListOne[i].docId;
                for (int j = loopControl; j < count2; j++)
                {
                    Doc2ID = ListTwo[j].docId;
                    if (Doc1ID == Doc2ID)
                    {

                        if ((ListOne[i].posting + SequenceIncrementor) == ListTwo[j].posting)
                        {
                            combinedList.Add((Index)ListOne[i]);
                            // prevents unnecessary inner looping
                            loopControl = j + 1;
                            break;
                        }
                        else if (ListOne[i].posting < ListTwo[j].posting)
                            break;
                    }
                    else
                        if (Doc1ID < Doc2ID)
                            break;
                }
            }
            return combinedList;
        }

        private IEnumerable<Index> IntersectQuery(IEnumerable<Index> CurrentPostingsSubset, IEnumerable<Index> SecondaryPosting)
        {
            List<Index> IntersectSet = new List<Index>();
            List<Index> currentPostings; currentPostings = (List<Index>)CurrentPostingsSubset;
            List<Index> secondaryPostings; secondaryPostings = (List<Index>)SecondaryPosting;
            int count = currentPostings.Count; bool left = false; bool right = false;
            int count2 = secondaryPostings.Count;
            int i = 0; int sav_docid = 0;

            for (int j = 0; j < count2 && i < count; j++)
            {
                if (currentPostings[i].docId == secondaryPostings[j].docId)
                {
                    if (currentPostings[i].posting > secondaryPostings[j].posting)
                    {
                        sav_docid = secondaryPostings[j].docId;
                        IntersectSet.Add(secondaryPostings[j]);
                        right = true;
                        left = false;
                        if (i == count)
                            IntersectSet.Add(currentPostings[i++]);
                    }
                    else
                    {
                        j--;
                        sav_docid = currentPostings[i].docId;
                        IntersectSet.Add(currentPostings[i++]);
                        right = false;
                        left = true;
                        if (j == count2)
                            IntersectSet.Add(secondaryPostings[j]);
                    }
                }
                else if ((secondaryPostings[j].docId == sav_docid) && (left))
                    IntersectSet.Add(secondaryPostings[j]);
                else if ((currentPostings[i].docId == sav_docid) && (right))
                {
                    IntersectSet.Add(currentPostings[i++]);
                    j--;
                }
                else
                    if (currentPostings[i].docId < secondaryPostings[j].docId)
                    { i++; j--; }
            }
            return IntersectSet;
        }    

        private IEnumerable<Index> UnionQuery(IEnumerable<Index> CurrentPostingsSubset, IEnumerable<Index> SecondaryPosting)
        {
            List<Index> UnionSet = new List<Index>();
            List<Index> currentPostings; currentPostings = (List<Index>)CurrentPostingsSubset;
            List<Index> secondaryPostings; secondaryPostings = (List<Index>)SecondaryPosting;
            int count = currentPostings.Count;
            int count2 = secondaryPostings.Count;
            int i = 0;

            for (int j = 0; j < count2 || i < count; j++)
            {
                if ((i == count) && (j < count2))
                    UnionSet.Add(secondaryPostings[j]);
                else if ((i < count) && (j == count2))
                {
                    j--;
                    UnionSet.Add(currentPostings[i++]);
                }
                else if (currentPostings[i].docId < secondaryPostings[j].docId)
                {
                    j--;
                    UnionSet.Add(currentPostings[i++]);
                }
                else if (currentPostings[i].docId == secondaryPostings[j].docId)
                {
                    if (currentPostings[i].posting > secondaryPostings[j].posting)
                        UnionSet.Add(secondaryPostings[j]);
                    else if (currentPostings[i].posting == secondaryPostings[j].posting)
                        UnionSet.Add(currentPostings[i++]);
                    else
                    {
                        j--;
                        UnionSet.Add(currentPostings[i++]);
                    }
                }
                else
                    UnionSet.Add(secondaryPostings[j]);
            }
            return UnionSet;
        }

        private IEnumerable<Index> NegationFilterQuery(IEnumerable<Index> CurrentPostingsSubset, IEnumerable<Index> NegationSet)
        {
            List<Index> negationRemovedSet = new List<Index>();
            List<Index> currentPostingsSubset = (List<Index>)CurrentPostingsSubset;
            List<Index> negationSet = (List<Index>)NegationSet;
            int count = negationSet.Count;
            int negationSetLoopPointer = 0;
            bool matched = true;
            
            foreach (Index posting in currentPostingsSubset)
            {
                for (int j = negationSetLoopPointer; j < count; j++)
                {
                    negationSetLoopPointer = j;
                    if (posting.docId < negationSet[j].docId)
                    {
                        matched = false;
                        j--;
                        break;
                    }
                    else if (posting.docId == negationSet[j].docId)
                    {
                        --j;
                        matched = true;
                        break;
                    }
                }
                if (!matched)
                    negationRemovedSet.Add(posting);
            }
            return negationRemovedSet;
        }
        
        public IEnumerable<Index> ProcessBooleanQuery(BSTask bqTree, bool summary)
        {
            List<BSTask> Operands;
            IEnumerable<Index> FinalResults = null;
            IEnumerable<Index> CNFResult = null;
            IEnumerable<Index> oprandResult = null;  //temporary storage for result from an AND search
            IEnumerable<Index> oprandPResult = null;  //temporary storage for result from an AND search
            IEnumerable<Index> opratrPResult = null;  //temporary storage for outer union operation
            bool FirstOperand = true; 
            bool FirstOR = false;

            FirstOR = true;
            foreach (BSTask ChildTask in bqTree.Children)
            {
                foreach (BSTask gChildTask in ChildTask.Children)
                {
                    // process wildcard or exact phrase query
                    if (IsExactQuery(gChildTask) || (IsWildcardQuery(gChildTask)))
                    {
                        if (FirstOperand)
                            FirstOperand = false;
                        if (IsWildcardQuery(gChildTask))
                            oprandResult = WildcardQuery(gChildTask);
                        else
                            oprandResult = ExactQuery(gChildTask);
                        if (oprandPResult == null)
                        {
                            CNFResult = oprandResult;
                            oprandPResult = CNFResult;
                        }
                        else
                        {
                            if (!summary)
                                CNFResult = IntersectQuery(oprandResult, oprandPResult);
                            else
                                CNFResult = oprandResult.Intersect(CNFResult);
                        }
                    }
                    else
                    {
                        try
                        {
                            Operands = GetLiterals(gChildTask, false);
                            foreach (BSTask Operand in Operands)
                            {
                                this.TermQuery(Operand);
                                if (!Operand.Negated)
                                {
                                    oprandResult = this.Results;
                                    // perform intersection for CNF portion
                                    CNFResult = oprandResult;
                                    if (oprandResult != null)
                                    {
                                        if (FirstOperand)
                                        {
                                            FirstOperand = false;
                                            oprandPResult = oprandResult;
                                        }
                                        else
                                        {
                                            CNFResult = IntersectQuery(oprandResult, oprandPResult);
                                            oprandPResult = CNFResult; // save list for potential Union operation
                                            //CNFResult = null;
                                            //if (!summary)
                                            //else
                                            //    CNFResult = oprandResult.Intersect(oprandPResult);
                                        }
                                    }
                                    else
                                        break;  // if any null or empty results returned, the associated CNF will return null
                                }
                                else
                                {
                                    CNFResult = NegationFilterQuery(CNFResult, this.m_Result);
                                    oprandPResult = CNFResult;
                                }
                            }
                        }
                        catch
                        { CNFResult = null; }
                    }
                }

                oprandPResult = null;
                FirstOperand = true;
                if (CNFResult != null)
                {
                    if (FirstOR)
                    {
                        FirstOR = false;
                        opratrPResult = CNFResult;  // save list for potential Union operation
                        FinalResults = CNFResult;
                    }
                    else
                    {
                        if (summary)
                            FinalResults = UnionQuery(opratrPResult, CNFResult);
                        else
                            FinalResults = opratrPResult.Union(CNFResult);
                        opratrPResult = FinalResults;
                    }
                }
            }
            if (FinalResults != null)
                FinalResults = from finalResult in FinalResults orderby finalResult.docId ascending, finalResult.posting ascending select finalResult;
            if ((summary) && (FinalResults != null))
            {
                var groupedby = GroupedBy(FinalResults);
                FinalResults = (IEnumerable<Index>)groupedby;
            }

            return FinalResults;
        }

        private IEnumerable<Index> GroupedBy(IEnumerable<Index> ungroupedSet)
        {
            List<Index> groupedSet = new List<Index>();
            int sav_docID = -1;

            foreach (Index rec in ungroupedSet)
            { 
                if (rec.docId != sav_docID)
                {
                    groupedSet.Add(rec);
                    sav_docID = rec.docId;
                }
            }
            return groupedSet;
        }
 
        private bool IsExactQuery(BSTask cmdBranch)
        {
            try
            {
                if (cmdBranch.Name == FunctionalSymbol.FTOKEN_EXACT)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        private bool IsWildcardQuery(BSTask cmdBranch)
        {
            try
            {
                if (cmdBranch.Name == FunctionalSymbol.FTOKEN_WILDCARD_STRING)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        private List<BSTask> GetLiterals(BSTask CommandRoot, bool Exact)
        {
            List<BSTask> literals = new List<BSTask>();

            if (Exact)
            {
                foreach (BSTask ChildTask in CommandRoot.Children)
                {
                    literals.Add(ChildTask);
                }
            }
            else
                literals.Add(CommandRoot);

            return literals;
        }

        public bool includeWildcardSearch
        {
            get { return m_includeWildcardSearch; }
        }

        public IEnumerable<String> KgramsMatchedList
        {
            get { return m_kgramsSearchList; }
        }       
        
        public List<Index> Results
        {
            get
            {
                return m_Result;
            }
        }
    }

    public class Kgram
    {
        private string m_kgramstring;
        private List<String> m_postings;

        public Kgram(string kgramstring, List<String> postings)
        {
            m_kgramstring = kgramstring;
            m_postings = postings;
        }

        public string Kgramstring
        {
            get { return m_kgramstring; }
        }

        public List<String> Postings
        {
            get { return m_postings; }
        }
    }
    
    public class KgramIndexer
    {
        string m_kgramstring;
        private ArrayList m_IndexerList = new ArrayList();
        private Dictionary<int, List<String>> m_oneGramIndex;
        private Dictionary<int, List<String>> m_twoGramIndex;

        public KgramIndexer(string kgramstring, Dictionary<int, List<String>> oneGramIndex, Dictionary<int, List<String>> twoGramIndex)
        {
            m_kgramstring = kgramstring;
            m_oneGramIndex = oneGramIndex;
            m_twoGramIndex = twoGramIndex;
            FillIndexerList();
        }

        public ArrayList KgramIndexerList
        {
            get { return m_IndexerList; }
        }

        private void FillIndexerList()
        { 
            int length = m_kgramstring.Length;
            int hashval;

            if (length == 1)
            {
                //m_IndexerList.Add(new Kgram(m_kgramstring, ""));
                hashval = m_kgramstring.GetHashCode(); //Get the hashVal of the current Word
                foreach (KeyValuePair<int, List<String>> term in m_oneGramIndex)
                {
                    if (hashval == term.Key)
                        m_IndexerList.Add(new Kgram(m_kgramstring, term.Value));
                }
            }
            else
            {
                string tempKgramstr = "";
                for (int i = 0; i < length - 1; i++)
                {
                    tempKgramstr = m_kgramstring.Substring(i, 2);
                    hashval = tempKgramstr.GetHashCode(); //Get the hashVal of the current Word
                    foreach (KeyValuePair<int, List<String>> term in m_twoGramIndex)
                    {
                        if (hashval == term.Key)
                            m_IndexerList.Add(new Kgram(tempKgramstr, term.Value));
                    }
                }
            }
        }
    }
}
