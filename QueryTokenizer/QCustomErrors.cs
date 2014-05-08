using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cobra.CustomErrors
{
    
    [Serializable]
    public class SearchStringEmptyException : Exception
    {
        public SearchStringEmptyException()
            : base("Search string is blank.") { }

        public SearchStringEmptyException(string message)
            : base(message) { }
    }
    
    [Serializable]
    public class InvalidTokenSequenceException : Exception
    {
        public InvalidTokenSequenceException()
            : base() { }

        public InvalidTokenSequenceException(string message)
            : base(message) { }
    }

    [Serializable]
    public class NonDNFException : Exception
    {
        public NonDNFException()
            : base("Query not in proper DNF form." + Environment.NewLine + "One of the conjuctions lack a positive token or is missing") { }

        public NonDNFException(string message)
            : base(message) { }
    }

    [Serializable]
    public class UnMatchedEnclosureException : Exception
    {
        public UnMatchedEnclosureException()
            : base("Enclosure notation not properly terminated.") { }

        public UnMatchedEnclosureException(string message)
            : base(message) { }
    }

    [Serializable]
    public class DictionaryEmptyException : Exception
    {
        public DictionaryEmptyException()
            : base("Term dictionary is empty.") { }

        public DictionaryEmptyException(string message)
            : base(message) { }
    }

    [Serializable]
    public class EmptyEnclosureException : Exception
    {
        public EmptyEnclosureException()
            : base("Empty enclosures found.") { }

        public EmptyEnclosureException(string message)
            : base(message) { }
    }

}
