using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobra.InterpreterNIndexer
{
    public class Index : IEquatable<Index>
    {
        public int docId;
        public int posting;
        public String stemWord;
        public int relativePosition;

        public Index(int docId, int posting, String stemWord, int relativePosition)
        {
            this.docId = docId;
            this.posting = posting;
            this.stemWord = stemWord;
            this.relativePosition = relativePosition;
        }

        public int getDocId
        {
            get { return docId; }
            set { this.docId = value; }
        }

        public int getRelativePosition
        {
            get { return relativePosition; }
        }
        public int getPosting
        {
            get { return posting; }
            set { this.posting = value; }
        }

        public bool Equals(Index other)
        {
            if (Object.ReferenceEquals(other, null)) return false;
            if (Object.ReferenceEquals(this, other)) return true;
            return docId.Equals(other.docId);
        }

        public override int GetHashCode()
        {

            //            int hashProductName = stemWord == null ? 0 : stemWord.GetHashCode();

            //Get hash code for the Code field.
            int hashProductCode = docId.GetHashCode();
            return hashProductCode;
            //Calculate the hash code for the product.
            //           return hashProductName ^ hashProductCode;
        }
    }
}
