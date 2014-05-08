using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobra {
    class Frequency {

        static public List<int> frqDist = new List<int>();
        static public int[] gapBarGraph;
        static List<int> gapSizes = new List<int>();

        static int currentPos = 0;
        static int gapSize = 0;
        static int frqCount = 0;

        public static List<int> calcFrqDist()
        {
            foreach (KeyValuePair<int, List<InterpreterNIndexer.Index>> x in IndexData.parser.invertedIndex)
            {
                int prevPos = 0;
                frqCount = x.Value.Count;
                frqDist.Add(frqCount);

                for (int ii = 0; ii < frqCount - 1; ii++)
                {
                    currentPos = x.Value[ii].getPosting;
                    gapSize = currentPos - prevPos;
                    gapSizes.Add(gapSize);
                    prevPos = currentPos;
                }
            }

            frqDist.Sort(new SortIntDescending());

            return frqDist;
        }

        public static int[] getGapBarGraph()
        {
            int largest = 0;
            foreach (int val in gapSizes)
            {
                if (val > largest)
                    largest = val;
            }

            gapBarGraph = new int[largest + 1];

            foreach (int val in gapSizes)
                gapBarGraph[val]++;

            return gapBarGraph;
        }

    }
}

public class SortIntDescending : IComparer<int> {
    int IComparer<int>.Compare(int a, int b) //implement Compare
    {
        if (a > b)
            return -1; //normally greater than = 1
        if (a < b)
            return 1; // normally smaller than = -1
        else
            return 0; // equal
    }
}
