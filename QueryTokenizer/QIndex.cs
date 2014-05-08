using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobra.QTokenizer
{
    public class QIndex
    {
        int docId;
        int posting;
        //int frequency;

        public QIndex(int docId, int posting)
        {
            this.docId = docId;
            this.posting = posting;
        }

        public int getDocId
        {
            get { return docId; }
            set { this.docId = value; }
        }

        public int getPosting
        {
            get { return posting; }
            set { this.posting = value; }
        }

    }
}
